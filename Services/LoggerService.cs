using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using LogoffUsersTool.Models;

namespace LogoffUsersTool.Services
{
    public class LoggerService
    {
        private readonly TreeView _treeView;

        public LoggerService(TreeView treeView)
        {
            _treeView = treeView;
        }

        public void Log(LogMessage message)
        {
            // Ensure all UI updates are performed on the UI thread
            if (_treeView.InvokeRequired)
            {
                _treeView.Invoke(new Action(() => AppendLogEntry(message)));
            }
            else
            {
                AppendLogEntry(message);
            }
        }

        private void AppendLogEntry(LogMessage message)
        {
            var timestamp = DateTime.Now.ToString("HH:mm:ss");

            // Regex to extract server name like "[SERVER]" and the rest of the message.
            var match = Regex.Match(message.Message, @"^\s*\[(.*?)\]\s*(.*)");

            string serverName = null;
            string messageText;

            if (match.Success)
            {
                serverName = match.Groups[1].Value;
                messageText = match.Groups[2].Value;
            }
            else
            {
                // The message does not contain a server name (e.g., a general summary message).
                messageText = message.Message;
            }

            var (categoryName, color) = GetCategoryInfo(message.Level);

            // Create the final message node with its text and color.
            TreeNode messageNode = new TreeNode($"[{timestamp}] {messageText}")
            {
                ForeColor = color
            };

            if (string.IsNullOrEmpty(serverName))
            {
                // This is a general message, add it to the root of the TreeView.
                _treeView.Nodes.Add(messageNode);
            }
            else
            {
                // This is a server-specific message, so we build the hierarchy.
                var serverNode = FindOrCreateNode(_treeView.Nodes, serverName, serverName);
                var categoryNode = FindOrCreateNode(serverNode.Nodes, categoryName, $"{serverName}_{categoryName}");
                
                categoryNode.Nodes.Add(messageNode);

                // Update the category node's text to include the message count.
                categoryNode.Text = $"{categoryName} ({categoryNode.GetNodeCount(false)})";
                
                // Ensure the new message is visible to the user.
                serverNode.Expand();
                categoryNode.Expand();
            }

            messageNode.EnsureVisible();
        }

        private (string, Color) GetCategoryInfo(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Info:
                    return ("Информация", ThemeService.InfoColor);
                case LogLevel.Warning:
                    return ("Предупреждения", Color.Orange);
                case LogLevel.Error:
                    return ("Ошибки", Color.Red);
                case LogLevel.Success:
                    return ("Успешно", Color.Green);
                default:
                    return ("Прочее", ThemeService.ForeColor);
            }
        }

        private TreeNode FindOrCreateNode(TreeNodeCollection parentCollection, string text, string name)
        {
            // We use the node's Name property for a reliable lookup, 
            // because the Text property will change to include the message count.
            var foundNode = parentCollection[name];
            if (foundNode != null)
            {
                return foundNode;
            }

            // If the node doesn't exist, create it, add it to the parent collection, and return it.
            var newNode = new TreeNode(text)
            {
                Name = name
            };
            parentCollection.Add(newNode);
            return newNode;
        }
    }
}
