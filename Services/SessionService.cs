#nullable enable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using LogoffUsersTool.Models;
using LogoffUsersTool.Utilities;

namespace LogoffUsersTool.Services
{
    public class SessionService
    {
        private const int IDTIMEOUT = 32000;

        public List<Session> GetActiveSessions(string serverName, bool excludedUsersEnabled, string excludedUsers)
        {
            var sessions = new List<Session>();
            IntPtr serverHandle = IntPtr.Zero;
            IntPtr sessionInfoPtr = IntPtr.Zero;

            try
            {
                serverHandle = NativeMethods.WTSOpenServer(serverName);
                if (serverHandle == IntPtr.Zero)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error(), $"Не удалось подключиться к серверу: {serverName}");
                }

                var sessionCount = 0;
                if (!NativeMethods.WTSEnumerateSessions(serverHandle, 0, 1, ref sessionInfoPtr, ref sessionCount))
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error(), $"Не удалось получить список сессий на сервере: {serverName}");
                }

                var sessionInfoSize = Marshal.SizeOf(typeof(WTS_SESSION_INFO));
                var currentPtr = sessionInfoPtr;

                for (var i = 0; i < sessionCount; i++)
                {
                    var wtsSessionInfoObject = Marshal.PtrToStructure(currentPtr, typeof(WTS_SESSION_INFO));
                    currentPtr = (IntPtr)(currentPtr.ToInt64() + sessionInfoSize);

                    if (wtsSessionInfoObject is WTS_SESSION_INFO wtsSessionInfo && wtsSessionInfo.State == WTS_CONNECTSTATE_CLASS.WTSActive)
                    {
                        string? userName = GetUserName(serverHandle, wtsSessionInfo.SessionID);
                        if (!string.IsNullOrEmpty(userName))
                        {
                            if (excludedUsersEnabled && !string.IsNullOrEmpty(excludedUsers) && IsUserExcluded(userName, excludedUsers))
                            {
                                continue;
                            }
                            sessions.Add(new Session { Id = wtsSessionInfo.SessionID, UserName = userName });
                        }
                    }
                }
            }
            finally
            {
                if (sessionInfoPtr != IntPtr.Zero) NativeMethods.WTSFreeMemory(sessionInfoPtr);
                if (serverHandle != IntPtr.Zero) NativeMethods.WTSCloseServer(serverHandle);
            }
            return sessions;
        }

        private bool IsUserExcluded(string userName, string excludedUsers)
        {
            var patterns = excludedUsers.Split(',').Select(p => p.Trim().Replace(".", "\\.").Replace("*", ".*"));
            return patterns.Any(p => Regex.IsMatch(userName, p, RegexOptions.IgnoreCase));
        }

        private string? GetUserName(IntPtr serverHandle, int sessionId)
        {
            if (NativeMethods.WTSQuerySessionInformation(serverHandle, sessionId, WTS_INFO_CLASS.WTSUserName, out var buffer, out var bytesReturned) && bytesReturned > 1)
            {
                var userName = Marshal.PtrToStringUni(buffer);
                NativeMethods.WTSFreeMemory(buffer);
                return userName;
            }
            return null;
        }

        public void LogoffSession(string serverName, int sessionId)
        {
            IntPtr serverHandle = IntPtr.Zero;
            try
            {
                serverHandle = NativeMethods.WTSOpenServer(serverName);
                if (serverHandle == IntPtr.Zero)
                {
                     throw new Win32Exception(Marshal.GetLastWin32Error(), $"Не удалось подключиться к серверу: {serverName} для завершения сеанса {sessionId}.");
                }

                if (!NativeMethods.WTSLogoffSession(serverHandle, sessionId, true))
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error(), $"Не удалось завершить сеанс ID: {sessionId} на сервере {serverName}.");
                }
            }
            finally
            {
                if (serverHandle != IntPtr.Zero) NativeMethods.WTSCloseServer(serverHandle);
            }
        }

        public void SendMessage(string serverName, int sessionId, string message, int timeout)
        {
            IntPtr serverHandle = IntPtr.Zero;
            try
            {
                serverHandle = NativeMethods.WTSOpenServer(serverName);
                if (serverHandle == IntPtr.Zero)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error(), $"Не удалось подключиться к серверу: {serverName} для отправки сообщения.");
                }

                string title = "Внимание";
                int response;
                bool result = NativeMethods.WTSSendMessage(serverHandle, sessionId, title, title.Length * 2, message, message.Length * 2, 48, timeout, out response, true);

                if (!result && response != IDTIMEOUT)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error(), $"Не удалось отправить сообщение сеансу ID: {sessionId} на сервере {serverName}.");
                }
            }
            finally
            {
                if (serverHandle != IntPtr.Zero) NativeMethods.WTSCloseServer(serverHandle);
            }
        }
    }
}
