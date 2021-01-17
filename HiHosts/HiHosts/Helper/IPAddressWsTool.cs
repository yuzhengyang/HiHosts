using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiHosts.Helper
{
    public class IPAddressWsTool
    {
        public static void GetIpAddesses(string url, WebBrowser webBrowser, Action<List<string>> callback)
        {
            Thread thread = new Thread(()=>{
                
                List<string> result = new List<string>();

                //WebBrowser webBrowser = Create();
                SetUrl(webBrowser, url);
                Submit(webBrowser);

                Thread.Sleep(5000);

                List<string> rsIps = GetIps(webBrowser);
                result.AddRange(rsIps);

                //label1.Text = webBrowser1.Url.AbsoluteUri;

                callback?.Invoke(result);

            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private static WebBrowser Create()
        {
            WebBrowser webBrowser1 = new WebBrowser();
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.Navigate(@"https://github.com.ipaddress.com/");
            return webBrowser1;
        }
        private static bool SetUrl(WebBrowser webBrowser1, string text)
        {
            HtmlElementCollection hostInputList = webBrowser1.Document.GetElementsByTagName("input").GetElementsByName("host");
            if (hostInputList != null && hostInputList.Count > 0)
            {
                hostInputList[0].SetAttribute("value", text);
                return true;
            }
            return false;
        }
        private static bool Submit(WebBrowser webBrowser1)
        {
            HtmlElementCollection buttonList = webBrowser1.Document.GetElementsByTagName("button");
            if (buttonList != null && buttonList.Count > 0)
            {
                for (int i = 0; i < buttonList.Count; i++)
                {
                    HtmlElement element = buttonList[i];
                    if (element != null && element.GetAttribute("type") == "submit")
                    {
                        element.InvokeMember("Click");
                        return true;
                    }
                }
            }
            return false;
        }
        private static List<string> GetIps(WebBrowser webBrowser1)
        {
            List<string> ips = new List<string>();

            // 查找结果区块中的h2标题
            HtmlElementCollection h2List = webBrowser1.Document.GetElementsByTagName("h2");
            if (h2List != null && h2List.Count > 0)
            {
                for (var i = 0; i < h2List.Count; i++)
                {
                    HtmlElement h2 = h2List[i];
                    if (h2 != null)
                    {
                        // 查找到目标标题的区块
                        if (h2.InnerHtml != null && h2.InnerHtml.Trim().Replace(" ", "").ToLower() == "domainsummary")
                        {
                            HtmlElementCollection thList = h2.NextSibling.GetElementsByTagName("th");
                            if (thList != null && thList.Count > 0)
                            {
                                for (int j = 0; j < thList.Count; j++)
                                {
                                    HtmlElement th = thList[j];
                                    // 找到ip地址所在位置
                                    if (th.InnerHtml != null && (th.InnerHtml.Trim().Replace(" ", "").ToLower() == "ipaddress" || th.InnerHtml.Trim().Replace(" ", "").ToLower() == "ipaddresses"))
                                    {
                                        HtmlElement td = th.NextSibling;
                                        if (td != null)
                                        {
                                            HtmlElementCollection liList = td.GetElementsByTagName("li");
                                            if (liList != null && liList.Count > 0)
                                            {
                                                for (int k = 0; k < liList.Count; k++)
                                                {
                                                    string _ip = liList[k].InnerText;
                                                    if (_ip != null && _ip != "")
                                                    {
                                                        ips.Add(_ip.Trim());
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return ips;
        }
    }
}
