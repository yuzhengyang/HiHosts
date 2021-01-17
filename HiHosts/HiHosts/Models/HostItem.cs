using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DataUtils.StringUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiHosts.Models
{
    public class HostItem
    {
        public string Ip { get; set; }
        public string Domain { get; set; }
        //public bool Enable { get; set; }
        //public string EnableSign { get { return Enable ? "#" : ""; } }
        public static HostItem Parse(string s)
        {
            if (Str.Ok(s))
            {
                // 处理字符创格式、清除前后空格、清除中间多余空格
                s = s.Trim();
                s = s.Replace("\t", "");
                while (s.Contains("  ")) s = s.Replace("  ", " ");

                // 获取相应数据
                bool enable = s.Substring(0, 1) != "#";
                if (enable)
                {
                    s = s.Replace("#", "");
                    string[] ipAndDomain = s.Split(' ');
                    ipAndDomain = ArrayTool.Formatter(ipAndDomain, 2);
                    string ip = ipAndDomain[0];
                    string domain = ipAndDomain[1];

                    if (Str.Ok(ip, domain))
                    {
                        HostItem model = new HostItem();
                        model.Ip = ip;
                        model.Domain = domain;
                        return model;
                    }
                }

            }
            return null;
        }
        public static List<HostItem> Parse(List<string> lines)
        {
            List<HostItem> result = new List<HostItem>();
            if (Ls.Ok(lines))
            {
                foreach (var s in lines)
                {
                    HostItem item = Parse(s);
                    if (item != null) result.Add(item);
                }
            }
            return result;
        }
        public override string ToString()
        {
            return $"{Ip} {Domain}";
        }
    }
}
