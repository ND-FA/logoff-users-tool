using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace LogoffUsersTool.Services
{
    public class PowerShellService
    {
        public async Task<List<string>> GetServersAsync()
        {
            var servers = new List<string>();
            const string command = "Get-ADComputer -Filter 'OperatingSystem -like \"*Server*\" -and Name -like \"*TRTS*\"' -Properties Name | Select-Object -ExpandProperty Name | Sort-Object";

            try
            {
                var plainTextBytes = System.Text.Encoding.Unicode.GetBytes(command);
                var encodedCommand = System.Convert.ToBase64String(plainTextBytes);

                var processStartInfo = new ProcessStartInfo("powershell.exe")
                {
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -EncodedCommand {encodedCommand}",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    StandardOutputEncoding = Encoding.UTF8,
                    StandardErrorEncoding = Encoding.UTF8
                };

                using (var process = new Process { StartInfo = processStartInfo })
                {
                    var output = new StringBuilder();
                    var error = new StringBuilder();

                    var outputCloseEvent = new TaskCompletionSource<bool>();
                    process.OutputDataReceived += (s, e) => {
                        if (e.Data == null) {
                            outputCloseEvent.TrySetResult(true);
                        } else {
                            output.AppendLine(e.Data);
                        }
                    };

                    var errorCloseEvent = new TaskCompletionSource<bool>();
                    process.ErrorDataReceived += (s, e) => {
                        if (e.Data == null) {
                            errorCloseEvent.TrySetResult(true);
                        } else {
                            error.AppendLine(e.Data);
                        }
                    };

                    var processExitEvent = new TaskCompletionSource<bool>();
                    process.EnableRaisingEvents = true;
                    process.Exited += (s, e) => { processExitEvent.TrySetResult(true); };

                    if (!process.Start())
                    {
                        servers.Add("Error: The process did not start.");
                        return servers;
                    }

                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    await Task.WhenAll(processExitEvent.Task, outputCloseEvent.Task, errorCloseEvent.Task);

                    if (process.ExitCode == 0)
                    {
                        var lines = output.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                        servers.AddRange(lines);
                        if (servers.Count == 0)
                        {
                           servers.Add("No servers found matching the criteria.");
                        }
                    }
                    else
                    {
                        var errorMessage = error.ToString();
                        if (string.IsNullOrWhiteSpace(errorMessage))
                        {
                            errorMessage = $"PowerShell script failed with exit code {process.ExitCode}.";
                        }
                        servers.Add($"Error: {errorMessage.Trim()}");
                    }
                }
            }
            catch (Exception ex)
            {
                servers.Add($"Error: {ex.Message}");
            }
            
            return servers;
        }
    }
}
