using Azylee.Core.DataUtils.DateTimeUtils;
using Azylee.Core.IOUtils.DirUtils;
using Azylee.Core.IOUtils.FileUtils;
using HiHosts.Commons;
using HiHosts.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HiHosts
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 创建我的文档资料文件夹
            DirTool.Create(R.Paths.TapeHosts);
            DirTool.Create(R.Paths.TapeHostsBak);

            // 备份当前系统
            FileTool.Copy(R.Files.SystemHosts, DirTool.Combine(R.Paths.TapeHostsBak, DateTimeFormatter.Compact(DateTime.Now) + ".hosts"), true);

            Application.Run(new MainForm());
        }
    }
}
