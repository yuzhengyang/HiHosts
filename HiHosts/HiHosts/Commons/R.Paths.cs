using Azylee.Core.IOUtils.DirUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiHosts.Commons
{
    public static partial class R
    {
        public static class Paths
        {

            public static string App = AppDomain.CurrentDomain.BaseDirectory;

            public static string Tape = DirTool.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HiHosts");
            public static string TapeHosts = DirTool.Combine(Tape, "Hosts");
            public static string TapeHostsBak = DirTool.Combine(Tape, "HostsBak");

            public static string Desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        }
    }
}
