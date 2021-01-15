namespace HiHosts.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ipAddressParsePart1 = new HiHosts.Parts.IpAddressParsePart();
            this.SuspendLayout();
            // 
            // ipAddressParsePart1
            // 
            this.ipAddressParsePart1.Location = new System.Drawing.Point(12, 12);
            this.ipAddressParsePart1.Name = "ipAddressParsePart1";
            this.ipAddressParsePart1.Size = new System.Drawing.Size(914, 509);
            this.ipAddressParsePart1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 533);
            this.Controls.Add(this.ipAddressParsePart1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Parts.IpAddressParsePart ipAddressParsePart1;
    }
}