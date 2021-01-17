using Azylee.Core.WindowsUtils.InfoUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiHosts.Commons
{
    public static partial class R
    {
        internal static string AppName = "HiHosts";
        internal static string AppNameCH = "Hosts文件编辑器";
        internal static string AppNameCHShort = "Hosts工具";
        internal static string AppId = "";
        internal static DateTime StartTime = DateTime.Now;//程序启动时间
        internal static DateTime PowerTime = ComputerInfoTool.StartTime();//系统启动时间（存在误差，同systeminfo）
    }
}
