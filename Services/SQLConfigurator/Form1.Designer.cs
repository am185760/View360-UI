namespace SQLConfigurator
{
    partial class Form1
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.AddDBServer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AtmsNum = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.MaxATMs = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.coreMaxPool = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.coreDBPwd = new System.Windows.Forms.TextBox();
            this.coreDBUserId = new System.Windows.Forms.TextBox();
            this.coreDBname = new System.Windows.Forms.TextBox();
            this.coreDBserver = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_WindowsAuth = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.AddNewAppServer = new System.Windows.Forms.Button();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(485, 708);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(107, 28);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Close";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(355, 708);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 28);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(27, 708);
            this.btnTestConnection.Margin = new System.Windows.Forms.Padding(4);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(136, 28);
            this.btnTestConnection.TabIndex = 4;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.AutoScrollMargin = new System.Drawing.Size(5, 5);
            this.tabPage1.Controls.Add(this.AddDBServer);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(610, 618);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DB Servers";
            // 
            // AddDBServer
            // 
            this.AddDBServer.Location = new System.Drawing.Point(179, 17);
            this.AddDBServer.Name = "AddDBServer";
            this.AddDBServer.Size = new System.Drawing.Size(229, 29);
            this.AddDBServer.TabIndex = 6;
            this.AddDBServer.Text = "Add Server";
            this.AddDBServer.UseVisualStyleBackColor = true;
            this.AddDBServer.Click += new System.EventHandler(this.AddDBServer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AtmsNum);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.MaxATMs);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.coreMaxPool);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.coreDBPwd);
            this.groupBox1.Controls.Add(this.coreDBUserId);
            this.groupBox1.Controls.Add(this.coreDBname);
            this.groupBox1.Controls.Add(this.coreDBserver);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 64);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(559, 251);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DB Server 1 (Core)";
            // 
            // AtmsNum
            // 
            this.AtmsNum.AutoSize = true;
            this.AtmsNum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.AtmsNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AtmsNum.Location = new System.Drawing.Point(479, 206);
            this.AtmsNum.Name = "AtmsNum";
            this.AtmsNum.Size = new System.Drawing.Size(25, 18);
            this.AtmsNum.TabIndex = 15;
            this.AtmsNum.Text = "----";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(366, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Current ATMs";
            // 
            // MaxATMs
            // 
            this.MaxATMs.BackColor = System.Drawing.SystemColors.Window;
            this.MaxATMs.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxATMs.Location = new System.Drawing.Point(180, 206);
            this.MaxATMs.Margin = new System.Windows.Forms.Padding(4);
            this.MaxATMs.Name = "MaxATMs";
            this.MaxATMs.Size = new System.Drawing.Size(110, 22);
            this.MaxATMs.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Max ATMs";
            // 
            // coreMaxPool
            // 
            this.coreMaxPool.BackColor = System.Drawing.SystemColors.Window;
            this.coreMaxPool.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coreMaxPool.Location = new System.Drawing.Point(180, 174);
            this.coreMaxPool.Margin = new System.Windows.Forms.Padding(4);
            this.coreMaxPool.Name = "coreMaxPool";
            this.coreMaxPool.Size = new System.Drawing.Size(358, 22);
            this.coreMaxPool.TabIndex = 11;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(24, 174);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(90, 16);
            this.label31.TabIndex = 10;
            this.label31.Text = "Max Pool size";
            // 
            // coreDBPwd
            // 
            this.coreDBPwd.BackColor = System.Drawing.SystemColors.Window;
            this.coreDBPwd.Location = new System.Drawing.Point(180, 143);
            this.coreDBPwd.Margin = new System.Windows.Forms.Padding(4);
            this.coreDBPwd.Name = "coreDBPwd";
            this.coreDBPwd.PasswordChar = '*';
            this.coreDBPwd.Size = new System.Drawing.Size(358, 22);
            this.coreDBPwd.TabIndex = 7;
            // 
            // coreDBUserId
            // 
            this.coreDBUserId.BackColor = System.Drawing.SystemColors.Window;
            this.coreDBUserId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coreDBUserId.Location = new System.Drawing.Point(180, 111);
            this.coreDBUserId.Margin = new System.Windows.Forms.Padding(4);
            this.coreDBUserId.Name = "coreDBUserId";
            this.coreDBUserId.Size = new System.Drawing.Size(358, 23);
            this.coreDBUserId.TabIndex = 6;
            // 
            // coreDBname
            // 
            this.coreDBname.BackColor = System.Drawing.SystemColors.Window;
            this.coreDBname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coreDBname.Location = new System.Drawing.Point(180, 74);
            this.coreDBname.Margin = new System.Windows.Forms.Padding(4);
            this.coreDBname.Name = "coreDBname";
            this.coreDBname.Size = new System.Drawing.Size(358, 23);
            this.coreDBname.TabIndex = 5;
            // 
            // coreDBserver
            // 
            this.coreDBserver.BackColor = System.Drawing.SystemColors.Window;
            this.coreDBserver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coreDBserver.Location = new System.Drawing.Point(180, 38);
            this.coreDBserver.Margin = new System.Windows.Forms.Padding(4);
            this.coreDBserver.Name = "coreDBserver";
            this.coreDBserver.Size = new System.Drawing.Size(358, 23);
            this.coreDBserver.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 143);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 111);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "User Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Database Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database Server";
            // 
            // checkBox_WindowsAuth
            // 
            this.checkBox_WindowsAuth.AutoSize = true;
            this.checkBox_WindowsAuth.Location = new System.Drawing.Point(24, 670);
            this.checkBox_WindowsAuth.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_WindowsAuth.Name = "checkBox_WindowsAuth";
            this.checkBox_WindowsAuth.Size = new System.Drawing.Size(224, 20);
            this.checkBox_WindowsAuth.TabIndex = 5;
            this.checkBox_WindowsAuth.Text = "Windows Authentication Enabled";
            this.checkBox_WindowsAuth.UseVisualStyleBackColor = true;
            this.checkBox_WindowsAuth.CheckedChanged += new System.EventHandler(this.checkBox_WindowsAuth_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(19, 9);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(618, 647);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.AddNewAppServer);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(610, 618);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "App servers";
            // 
            // AddNewAppServer
            // 
            this.AddNewAppServer.Location = new System.Drawing.Point(196, 26);
            this.AddNewAppServer.Name = "AddNewAppServer";
            this.AddNewAppServer.Size = new System.Drawing.Size(229, 29);
            this.AddNewAppServer.TabIndex = 1;
            this.AddNewAppServer.Text = "Add Server";
            this.AddNewAppServer.UseVisualStyleBackColor = true;
            this.AddNewAppServer.Click += new System.EventHandler(this.AddNewAppServer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 752);
            this.Controls.Add(this.checkBox_WindowsAuth);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnTestConnection);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CCMS SQL Configurator";
            this.Load += new System.EventHandler(this.ConfigurationForm_Load);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox coreDBPwd;
        private System.Windows.Forms.TextBox coreDBUserId;
        private System.Windows.Forms.TextBox coreDBname;
        private System.Windows.Forms.TextBox coreDBserver;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_WindowsAuth;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button AddNewAppServer;
        private System.Windows.Forms.Button AddDBServer;
        private System.Windows.Forms.TextBox coreMaxPool;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label AtmsNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox MaxATMs;
        private System.Windows.Forms.Label label6;
    }
}

