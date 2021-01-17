using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.IOUtils.TxtUtils;
using HiHosts.Commons;
using HiHosts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HiHosts.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Str.Ok(textBox1.Text, textBox2.Text))
            {
                HostItem item = new HostItem() { Ip = textBox1.Text, Domain = textBox2.Text };
                bool flag = TxtTool.Append(R.Files.SystemHosts, item.ToString());
                Console.WriteLine("flag " + flag);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            List<string> lines = TxtTool.ReadLine(R.Files.SystemHosts);
            List<HostItem> hosts = HostItem.Parse(lines);

            dataGridView1.Rows.Clear();
            foreach (var item in hosts)
            {
                dataGridView1.Rows.Add(item.Ip, item.Domain);
            }
        }
    }
}
