using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HiHosts.Helper
{
    public class WebBrowserTool
    {
        public static HtmlElement GetFirstElement(HtmlElementCollection collection)
        {
            if (collection != null && collection.Count > 0)
            {
                return collection[0];
            }
            return null;
        }
    }
}
