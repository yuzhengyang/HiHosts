using Azylee.Core.IOUtils.DirUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HiHosts.Commons
{
    public static partial class R
    {
        public static class Files
        {

            public static string App = Application.ExecutablePath;
            public static string SystemHosts = @"C:\Windows\System32\drivers\etc\hosts";
        }
    }
}
