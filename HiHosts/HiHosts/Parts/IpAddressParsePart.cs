using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HiHosts.Parts
{
    public partial class IpAddressParsePart : UserControl
    {
        WebBrowser webBrowser1;
        public IpAddressParsePart()
        {
            InitializeComponent();
        }

        private void IpAddressParsePart_Load(object sender, EventArgs e)
        {
            webBrowser1 = new WebBrowser();
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.Navigate(@"https://github.com.ipaddress.com/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            HtmlElementCollection hostInputList = webBrowser1.Document.GetElementsByTagName("input").GetElementsByName("host");
            if (hostInputList != null && hostInputList.Count > 0)
            {
                hostInputList[0].SetAttribute("value", text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
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
                        break;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = webBrowser1.Url.AbsoluteUri;

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
                                            string ips = "";
                                            HtmlElementCollection liList = td.GetElementsByTagName("li");
                                            if (liList != null && liList.Count > 0)
                                            {
                                                for (int k = 0; k < liList.Count; k++)
                                                {
                                                    ips += liList[k].InnerText + ",";
                                                }
                                            }
                                            label2.Text = ips;
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
