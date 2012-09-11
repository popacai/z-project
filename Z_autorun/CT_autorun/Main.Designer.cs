namespace CT_autorun
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.TabControl = new System.Windows.Forms.TabControl();
            this.logon = new System.Windows.Forms.TabPage();
            this.IE_BHO = new System.Windows.Forms.TabPage();
            this.services = new System.Windows.Forms.TabPage();
            this.drivers = new System.Windows.Forms.TabPage();
            this.tasks = new System.Windows.Forms.TabPage();
            this.boot = new System.Windows.Forms.TabPage();
            this.DLLs = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.TabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.logon);
            this.TabControl.Controls.Add(this.IE_BHO);
            this.TabControl.Controls.Add(this.services);
            this.TabControl.Controls.Add(this.drivers);
            this.TabControl.Controls.Add(this.tasks);
            this.TabControl.Controls.Add(this.boot);
            this.TabControl.Controls.Add(this.DLLs);
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.Location = new System.Drawing.Point(25, 55);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(666, 19);
            this.TabControl.TabIndex = 0;
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // logon
            // 
            this.logon.Location = new System.Drawing.Point(4, 22);
            this.logon.Name = "logon";
            this.logon.Padding = new System.Windows.Forms.Padding(3);
            this.logon.Size = new System.Drawing.Size(658, 0);
            this.logon.TabIndex = 0;
            this.logon.Text = "Logon";
            this.logon.UseVisualStyleBackColor = true;
            this.logon.Click += new System.EventHandler(this.logon_Click);
            // 
            // IE_BHO
            // 
            this.IE_BHO.Location = new System.Drawing.Point(4, 22);
            this.IE_BHO.Name = "IE_BHO";
            this.IE_BHO.Padding = new System.Windows.Forms.Padding(3);
            this.IE_BHO.Size = new System.Drawing.Size(658, 297);
            this.IE_BHO.TabIndex = 1;
            this.IE_BHO.Text = "IE_BHO";
            this.IE_BHO.UseVisualStyleBackColor = true;
            this.IE_BHO.Click += new System.EventHandler(this.IE_BHO_Click);
            // 
            // services
            // 
            this.services.Location = new System.Drawing.Point(4, 22);
            this.services.Name = "services";
            this.services.Size = new System.Drawing.Size(658, 297);
            this.services.TabIndex = 2;
            this.services.Text = "Services";
            this.services.UseVisualStyleBackColor = true;
            this.services.Click += new System.EventHandler(this.services_Click);
            // 
            // drivers
            // 
            this.drivers.Location = new System.Drawing.Point(4, 22);
            this.drivers.Name = "drivers";
            this.drivers.Size = new System.Drawing.Size(658, 297);
            this.drivers.TabIndex = 3;
            this.drivers.Text = "Drivers";
            this.drivers.UseVisualStyleBackColor = true;
            this.drivers.Click += new System.EventHandler(this.drivers_Click);
            // 
            // tasks
            // 
            this.tasks.Location = new System.Drawing.Point(4, 22);
            this.tasks.Name = "tasks";
            this.tasks.Size = new System.Drawing.Size(658, 297);
            this.tasks.TabIndex = 4;
            this.tasks.Text = "Scheduled Tasks";
            this.tasks.UseVisualStyleBackColor = true;
            this.tasks.Click += new System.EventHandler(this.tasks_Click);
            // 
            // boot
            // 
            this.boot.Location = new System.Drawing.Point(4, 22);
            this.boot.Name = "boot";
            this.boot.Size = new System.Drawing.Size(658, 297);
            this.boot.TabIndex = 5;
            this.boot.Text = "Boot Execute";
            this.boot.UseVisualStyleBackColor = true;
            this.boot.Click += new System.EventHandler(this.boot_Click);
            // 
            // DLLs
            // 
            this.DLLs.Location = new System.Drawing.Point(4, 22);
            this.DLLs.Name = "DLLs";
            this.DLLs.Size = new System.Drawing.Size(658, 297);
            this.DLLs.TabIndex = 6;
            this.DLLs.Text = "Known DLLs";
            this.DLLs.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(658, 297);
            this.tabPage1.TabIndex = 7;
            this.tabPage1.Text = "TODO";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(275, 162);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(388, 148);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(25, 162);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(244, 148);
            this.listBox2.TabIndex = 4;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged_1);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(25, 80);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(638, 76);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(588, 316);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(431, 316);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 25);
            this.button2.TabIndex = 7;
            this.button2.Text = "About...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 371);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.TabControl);
            this.Name = "Main";
            this.Text = "CT_autorun";
            this.Load += new System.EventHandler(this.Main_Load);
            this.TabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage logon;
        private System.Windows.Forms.TabPage IE_BHO;
        private System.Windows.Forms.TabPage services;
        private System.Windows.Forms.TabPage drivers;
        private System.Windows.Forms.TabPage tasks;
        private System.Windows.Forms.TabPage boot;
        private System.Windows.Forms.TabPage DLLs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;

    }
}

