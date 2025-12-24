using System;
using System.Collections.Generic;

namespace LogoffUsersTool.Models
{
    public class ApplicationSettings
    {
        public string Version { get; set; } = "1.0";
        public DateTime LastRun { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public List<string> KnownServers { get; set; } = new List<string>();
        public List<string> ManuallyAddedServers { get; set; } = new List<string>();
    }
}
