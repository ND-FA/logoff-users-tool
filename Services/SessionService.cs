#nullable enable

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using LogoffUsersTool.Models;
using LogoffUsersTool.Utilities;

namespace LogoffUsersTool.Services
{
    public class SessionService
    {
        public List<Session> GetActiveSessions(string serverName)
        {
            var sessions = new List<Session>();
            var serverHandle = NativeMethods.WTSOpenServer(serverName);

            try
            {
                var sessionInfoPtr = IntPtr.Zero;
                var sessionCount = 0;
                if (NativeMethods.WTSEnumerateSessions(serverHandle, 0, 1, ref sessionInfoPtr, ref sessionCount))
                {
                    var sessionInfoSize = Marshal.SizeOf(typeof(WTS_SESSION_INFO));
                    var currentPtr = sessionInfoPtr;

                    for (var i = 0; i < sessionCount; i++)
                    {
                        var wtsSessionInfoObject = Marshal.PtrToStructure(currentPtr, typeof(WTS_SESSION_INFO));
                        currentPtr = (IntPtr)(currentPtr.ToInt64() + sessionInfoSize);

                        if (wtsSessionInfoObject != null)
                        {
                            var wtsSessionInfo = (WTS_SESSION_INFO)wtsSessionInfoObject;
                            if (wtsSessionInfo.State == WTS_CONNECTSTATE_CLASS.WTSActive)
                            {
                                string? userName = GetUserName(serverHandle, wtsSessionInfo.SessionID);
                                if (!string.IsNullOrEmpty(userName))
                                {
                                    sessions.Add(new Session { Id = wtsSessionInfo.SessionID, UserName = userName });
                                }
                            }
                        }
                    }
                    NativeMethods.WTSFreeMemory(sessionInfoPtr);
                }
            }
            finally
            {
                if (serverHandle != IntPtr.Zero)
                {
                    NativeMethods.WTSCloseServer(serverHandle);
                }
            }
            return sessions;
        }

        private string? GetUserName(IntPtr serverHandle, int sessionId)
        {
            var buffer = IntPtr.Zero;
            uint bytesReturned;
            if (NativeMethods.WTSQuerySessionInformation(serverHandle, sessionId, WTS_INFO_CLASS.WTSUserName, out buffer, out bytesReturned) && bytesReturned > 1)
            {
                var userName = Marshal.PtrToStringUni(buffer);
                NativeMethods.WTSFreeMemory(buffer);
                return userName;
            }
            return null;
        }

        public void LogoffSession(string serverName, int sessionId)
        {
            var serverHandle = NativeMethods.WTSOpenServer(serverName);
            try
            {
                NativeMethods.WTSLogoffSession(serverHandle, sessionId, true);
            }
            finally
            {
                if (serverHandle != IntPtr.Zero)
                {
                    NativeMethods.WTSCloseServer(serverHandle);
                }
            }
        }

        public void SendMessage(string serverName, int sessionId, string message, int timeout)
        {
            var serverHandle = NativeMethods.WTSOpenServer(serverName);
            try
            {
                int response;
                NativeMethods.WTSSendMessage(serverHandle, sessionId, "", 0, message, message.Length * 2, 0x40, timeout, out response, true);
            }
            finally
            {
                if (serverHandle != IntPtr.Zero)
                {
                    NativeMethods.WTSCloseServer(serverHandle);
                }
            }
        }
    }
}
