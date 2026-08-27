using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;
using DataRequestor;
using Encryption;
using System.Threading.Tasks;

namespace SQLConfigurator
{
    public partial class Form1 : Form
    {
        public  string regKey = @"SOFTWARE\NCR\EV360";
        static string ZipDir = System.Configuration.ConfigurationManager.AppSettings["ZipDir"];
        int appServerLeft = 0;
        int dbServerLeft = 0;
        ConnectionInitializer conn;
        public Form1()
        {
            InitializeComponent();
        }

        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
            try
            {
                string ConnectionK = string.Empty;
                string filePath = Encryption.Helper.GetValue(System.Configuration.ConfigurationManager.AppSettings["ZipDir"]);
                System.IO.Directory.CreateDirectory(filePath);
                Registry.LocalMachine.CreateSubKey(regKey).SetValue("MasterZip", System.Configuration.ConfigurationManager.AppSettings["MasterZipPass"]);
                Registry.LocalMachine.CreateSubKey(regKey).SetValue("ConnectionZip", System.Configuration.ConfigurationManager.AppSettings["ConnectionZipPass"]);
                Registry.LocalMachine.CreateSubKey(regKey).SetValue("ZipDir", System.Configuration.ConfigurationManager.AppSettings["ZipDir"]);
                Registry.LocalMachine.CreateSubKey(regKey).SetValue("CoreConnStrPath", System.Configuration.ConfigurationManager.AppSettings["CoreConnStrPath"]);

                Encryption.Cryptic.ConnectionZipFile = Path.Combine(Encryption.Helper.GetValue(ZipDir), "ConnectionZip.zip");
                Encryption.Cryptic.MasterZipFile = Path.Combine(Encryption.Helper.GetValue(ZipDir), "MasterZip.zip");
                try
                {
                    ConnectionK = Encryption.Helper.ConstractKey(false);
                }
                catch
                {
                    //MessageBox.Show("An error has occured while reading configuration, so continuing with the default values", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                conn = new ConnectionInitializer("CoreConnStrPath");
                List<string> temp = new List<string>();
                if (conn.DBServers[0].ServerName == string.Empty)
                    return;
                temp = Encryption.Cryptic.DecryptString(conn.DBServers[0].ServerConnection, ConnectionK).Split('=').ToList();
                coreDBserver.Text = temp[1].TrimEnd('\0').TrimEnd(';');
                temp = Encryption.Cryptic.DecryptString(conn.DBServers[0].ServerCredentials, ConnectionK).Split(';').ToList();
                coreDBname.Text = temp[0].Split('=')[1];
                coreDBUserId.Text = temp[1].Split('=')[1];
                coreDBPwd.Text = temp[2].Split('=')[1].TrimEnd(';');
                coreMaxPool.Text = conn.DBServers[0].MaxPoolSize;
                MaxATMs.Text = conn.DBServers[0].MaxATMs;
                AtmsNum.Text = conn.DBServers[0].AtmIds.Count.ToString();
                Button btn1 = new Button();
                groupBox1.Controls.Add(btn1);
                btn1.Text = "Test";
                btn1.Click += new EventHandler(TestDBServer_Click);
                btn1.Left = 360;
                btn1.Font = new Font(btn1.Font, FontStyle.Regular);
                btn1.ForeColor = Color.Green;
                btn1.Width = 50;

                //if (conn.DBServers.Count >= 2)
                //    dbServerLeft = 0;
                    //dbServerLeft = conn.DBServers.Count() - 1;
                string serverName; string dbName; string dsdbName; string user; string pass;
                for (int i = 1; i < conn.DBServers.Count; i++)
                {
                    temp = Encryption.Cryptic.DecryptString(conn.DBServers[i].ServerConnection, ConnectionK).Split('=').ToList();
                    serverName = temp[1].TrimEnd('\0').TrimEnd(';');
                    temp = Encryption.Cryptic.DecryptString(conn.DBServers[i].ServerCredentials, ConnectionK).Split(';').ToList();
                    dbName = temp[0].Split('=')[1];
                    user = temp[1].Split('=')[1];
                    pass = temp[2].Split('=')[1].TrimEnd(';');
                    AddDataBaseServer((i+1).ToString(), serverName, dbName, user, pass, conn.DBServers[i].MaxPoolSize,conn.DBServers[i].MaxATMs,conn.DBServers[i].AtmIds.Count.ToString());
                }

                //if (conn.AppServers.Count >= 1)
                //    appServerLeft = conn.AppServers.Count - 1;

                for (int i = 0; i < conn.AppServers.Count; i++)
                {
                    AddAppServer((i + 1).ToString(), conn.AppServers[i].ServerIP, conn.AppServers[i].ServerPort);
                }

                //string connStr = (string)Registry.LocalMachine.OpenSubKey(regKey, false).GetValue("ConnectionString", "");
                //if (connStr == "")
                //    throw new Exception("Connection string is not initialized");
                //else
                //{
                //    if (File.Exists(Encryption.Cryptic.ConnectionZipFile))
                //    {
                //        string ConnectionK = Encryption.Helper.ConstractKey(false);
                //        connStr = Encryption.Cryptic.DecryptString(connStr, ConnectionK);
                //    }
                //    else
                //        throw new Exception("Connection string is not initialized");
                //}

                //if (connStr.Length > 0)
                //{
                //    string[] parts = connStr.Split(';');
                //    coreDBserver.Text = parts[0].Split('=')[1];
                //    coreDBname.Text = parts[1].Split('=')[1];
                //    if (!connStr.ToLower().Contains("security"))
                //    {
                //        coreDBUserId.Text = parts[2].Split('=')[1];
                //        coreDBPwd.Text = parts[3].Split('=')[1];
                //    }
                //    else
                //        checkBox_WindowsAuth.Checked = true;

                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured while reading configuration from registry so continuing with the default values.Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                string result = string.Empty;
                string connStr = "Data Source=" + coreDBserver.Text;
                connStr += ";Initial Catalog=" + coreDBname.Text;
                if (!checkBox_WindowsAuth.Checked)
                {
                    connStr += ";User Id=" + coreDBUserId.Text;
                    connStr += ";Password=" + coreDBPwd.Text;
                }
                else
                {
                    connStr += ";Integrated Security=True";
                }
                //MessageBox.Show(this, "Connection has been successfully established.", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (ConnectionInitializer.IsDBServerConnected(connStr))
                    result += "DB Server 1 (Core): Connection has been successfully established\n";
                else
                    result += "DB Server 1 (Core): Failed to connect to the Database";

                var dbGroupBoxes = tabPage1.Controls.OfType<GroupBox>().OrderBy(x => x.Text).ToList();
                for (int i = 1; i < dbGroupBoxes.Count; i++)
                {
                    if (checkBox_WindowsAuth.Checked)
                        connStr = string.Format("data source={0}; initial catalog={1}; Integrated Security=True", dbGroupBoxes[i].Controls[1].Text, dbGroupBoxes[i].Controls[3].Text);
                    else
                        connStr = string.Format("data source={0}; initial catalog={1}; user id={2}; pwd={3};", dbGroupBoxes[i].Controls[1].Text, dbGroupBoxes[i].Controls[3].Text, dbGroupBoxes[i].Controls[5].Text, dbGroupBoxes[i].Controls[7].Text);
                    if (ConnectionInitializer.IsDBServerConnected(connStr))
                        result += "DB Server " + (i + 1).ToString() + ": Connection has been successfully established\n";
                    else
                        result += "DB Server " + (i + 1).ToString() + ": Failed to connect to the Database\n";

                }
                MessageBox.Show(this, result, "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Failed to connect to the Database. Detail :" + ex.Message, "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Registry.LocalMachine.CreateSubKey(regKey).SetValue("MasterZip", System.Configuration.ConfigurationManager.AppSettings["MasterZipPass"]);
                Registry.LocalMachine.CreateSubKey(regKey).SetValue("ConnectionZip", System.Configuration.ConfigurationManager.AppSettings["ConnectionZipPass"]);
                Registry.LocalMachine.CreateSubKey(regKey).SetValue("ZipDir", System.Configuration.ConfigurationManager.AppSettings["ZipDir"]);
                Registry.LocalMachine.CreateSubKey(regKey).SetValue("CoreConnStrPath", System.Configuration.ConfigurationManager.AppSettings["CoreConnStrPath"]);

                Encryption.Helper.CreateProtectedZipFile(System.Configuration.ConfigurationManager.AppSettings["MasterVal"], Encryption.Cryptic.MasterZipFile, Encryption.Helper.GetValue(System.Configuration.ConfigurationManager.AppSettings["MasterZipPass"]), 9);
                Encryption.Helper.CreateProtectedZipFile(System.Configuration.ConfigurationManager.AppSettings["ConnectionVal"], Encryption.Cryptic.ConnectionZipFile, Encryption.Helper.GetValue(System.Configuration.ConfigurationManager.AppSettings["ConnectionZipPass"]), 9);
                string connectionString = null;
                string TmpStr = "";
                string ConnectionK = Encryption.Helper.ConstractKey(false);
                var dbGroupBoxes = tabPage1.Controls.OfType<GroupBox>().OrderBy(x => x.Text).ToList();
                var appGroupBoxes = tabPage3.Controls.OfType<GroupBox>().OrderBy(x => x.Text).ToList();
                string filePath = Encryption.Cryptic.DecryptString(System.Configuration.ConfigurationManager.AppSettings["CoreConnStrPath"],ConnectionK).TrimEnd('\0');

                if (checkBox_WindowsAuth.Checked)
                {
                    if(string.IsNullOrEmpty(coreMaxPool.Text))
                        TmpStr = string.Format("data source={0}; initial catalog={1}; Integrated Security=True;Encrypt=False", coreDBserver.Text, coreDBname.Text);
                    else
                        TmpStr = string.Format("data source={0}; initial catalog={1}; Integrated Security=True; Max Pool Size={2};Encrypt=False", coreDBserver.Text, coreDBname.Text,coreMaxPool.Text);
                    using (StreamWriter file = File.CreateText(filePath))
                    {
                        file.Write(Encryption.Cryptic.EncryptString(TmpStr, ConnectionK));
                    }
                    conn = new ConnectionInitializer();
                    conn.DBServers[0].ServerName = coreDBserver.Text;
                    conn.DBServers[0].ServerConnection = Encryption.Cryptic.EncryptString(string.Format("data source={0};", coreDBserver.Text), ConnectionK);
                    conn.DBServers[0].ServerCredentials = Encryption.Cryptic.EncryptString(string.Format(" initial catalog={0}; Integrated Security=True",coreDBname.Text), ConnectionK);
                    conn.DBServers[0].MaxPoolSize = coreMaxPool.Text;
                    conn.DBServers[0].MaxATMs = MaxATMs.Text;

                    SaveDBServersInfo(ConnectionK, true);

                }
                else
                {
                    if (string.IsNullOrEmpty(coreMaxPool.Text))
                        TmpStr = string.Format("data source={0}; initial catalog={1}; user id={2}; pwd={3};Encrypt=False", coreDBserver.Text, coreDBname.Text, coreDBUserId.Text, coreDBPwd.Text);
                    else
                        TmpStr = string.Format("data source={0}; initial catalog={1}; user id={2}; pwd={3}; Max Pool Size={4};Encrypt=False", coreDBserver.Text, coreDBname.Text, coreDBUserId.Text, coreDBPwd.Text, coreMaxPool.Text);
                    using (StreamWriter file = File.CreateText(filePath))
                    {
                        file.Write(Encryption.Cryptic.EncryptString(TmpStr, ConnectionK));
                    }
                    conn = new ConnectionInitializer();
                    conn.DBServers[0].ServerName = coreDBserver.Text;
                    conn.DBServers[0].ServerConnection = Encryption.Cryptic.EncryptString(string.Format("data source={0};", coreDBserver.Text), ConnectionK);
                    conn.DBServers[0].ServerCredentials = Encryption.Cryptic.EncryptString(string.Format(" initial catalog={0}; user id={1}; pwd={2};", coreDBname.Text,
                        coreDBUserId.Text, coreDBPwd.Text), ConnectionK);
                    conn.DBServers[0].MaxPoolSize = coreMaxPool.Text;
                    conn.DBServers[0].MaxATMs = MaxATMs.Text;

                    SaveDBServersInfo(ConnectionK, false);
                }

                SaveAppServersInfo();
                //string checkMsg = CheckForInitDBAtmsInfo();
                //if (!string.IsNullOrEmpty(checkMsg))
                //{
                //    MessageBox.Show(this, checkMsg, "Save..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                string msg = conn.SaveServersInfo();
                connectionString = Encryption.Cryptic.EncryptString(TmpStr, ConnectionK);
                Registry.LocalMachine.CreateSubKey(regKey).SetValue("ConnectionString", connectionString);

                if (!string.IsNullOrEmpty(msg))
                    MessageBox.Show(this, msg, "Save..", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else if (MessageBox.Show(this, "Changes saved permanently. Do you want to close it now", "CCMS SQL Configurator", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Settings could not be saved\n" + ex.Message, "Save..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox_WindowsAuth_CheckedChanged(object sender, EventArgs e)
        {
            var groupBoxes = tabPage1.Controls.OfType<GroupBox>().OrderBy(x => x.Text).ToList();
            if (checkBox_WindowsAuth.Checked)
            {
                coreDBUserId.Enabled = coreDBPwd.Enabled = false;
                for (int i = 1; i < groupBoxes.Count; i++)
                {
                    groupBoxes[i].Controls[7].Enabled = false;
                    groupBoxes[i].Controls[9].Enabled = false;

                }
            }
            else
            {
                coreDBUserId.Enabled = coreDBPwd.Enabled = true;
                for (int i = 1; i < groupBoxes.Count; i++)
                {
                    groupBoxes[i].Controls[7].Enabled = true;
                    groupBoxes[i].Controls[9].Enabled = true;

                }
            }
        }
        private void AddNewAppServer_Click(object sender, EventArgs e)
        {
            var cntr = tabPage3.Controls;
            var mySortedList = tabPage3.Controls.OfType<GroupBox>().OrderBy(x => x.Text).ToList();

            GroupBox g1 = new GroupBox();
            this.tabPage3.Controls.Add(g1);
            g1.Top = appServerLeft * 105 + 50;
            g1.Left = 8;
            g1.Text = "App Server " + (this.appServerLeft + 1).ToString();
            appServerLeft = appServerLeft + 1;
            g1.Size = new Size(418, 99);
            g1.AutoSizeMode = AutoSizeMode.GrowOnly;
            g1.AutoSize = false;

            Label lbl = new Label();
            g1.Controls.Add(lbl);
            lbl.Text = "Server Name/IP";
            lbl.Font = new Font(lbl.Font, FontStyle.Regular);
            lbl.Location = new Point(22, 30);
            TextBox txt = new TextBox();
            g1.Controls.Add(txt);
            txt.Font = new Font(txt.Font, FontStyle.Regular);
            txt.Location = new Point(139, 30);
            txt.Size = new Size(270, 20);

            Label lbl2 = new Label();
            g1.Controls.Add(lbl2);
            lbl2.Text = "Server Port";
            lbl2.Font = new Font(lbl2.Font, FontStyle.Regular);
            lbl2.Location = new Point(22, 62);
            TextBox txt2 = new TextBox();
            g1.Controls.Add(txt2);
            txt2.Font = new Font(txt2.Font, FontStyle.Regular);
            txt2.Location = new Point(139, 62);
            txt2.Size = new Size(270, 20);

            Button btn = new Button();
            g1.Controls.Add(btn);
            btn.Text = "Test";
            btn.Click += new EventHandler(TestAppServer_Click);
            btn.Left = 300;
            btn.Font = new Font(btn.Font, FontStyle.Regular);
            btn.ForeColor = Color.Green;
            btn.Width = 50;

            Button btn1 = new Button();
            g1.Controls.Add(btn1);
            btn1.Text = "Delete";
            btn1.Click += new EventHandler(DeleteAppServerButton_Click);
            btn1.Left = 360;
            btn1.Font = new Font(btn1.Font, FontStyle.Regular);
            btn1.ForeColor = Color.Red;
            btn1.Width = 50;
        }
        private void DeleteAppServerButton_Click(object sender, EventArgs e) {
            var groupView = ((Control.ControlAccessibleObject)((Control)sender).AccessibilityObject).Owner.Parent;
            int ind = tabPage3.Controls.IndexOf(groupView);
            tabPage3.Controls.Remove(groupView);
            appServerLeft--;
            if(ind != -1)
            {
                for (int i = ind; i < tabPage3.Controls.Count; i++)
                {
                    tabPage3.Controls[i].Top -= 105;
                    tabPage3.Controls[i].Text = "App Server " + i;
                }
            }
        }
        private void DeleteDBServerButton_Click(object sender, EventArgs e)
        {
            var groupView = ((Control.ControlAccessibleObject)((Control)sender).AccessibilityObject).Owner.Parent;
            int ind = tabPage1.Controls.IndexOf(groupView);
            tabPage1.Controls.Remove(groupView);
            dbServerLeft--;
            if (ind != -1)
            {
                for (int i = ind; i < tabPage1.Controls.Count; i++)
                {
                    tabPage1.Controls[i].Top -= 250;
                    tabPage1.Controls[i].Text = "DB Server " + (i);
                }
            }
        }
        private void AddDBServer_Click(object sender, EventArgs e)
        {
            GroupBox g1 = new GroupBox();
            this.tabPage1.Controls.Add(g1);
            g1.Top = dbServerLeft * 230 + 270;
            g1.Left = 8;
            g1.Text = "DB Server " + (this.dbServerLeft + 2).ToString();
            dbServerLeft = dbServerLeft + 1;
            g1.Size = new Size(418, 220);
            g1.AutoSizeMode = AutoSizeMode.GrowOnly;
            g1.AutoSize = false;

            Label lbl = new Label();
            g1.Controls.Add(lbl);
            lbl.Text = "DB Server";
            lbl.Font = new Font(lbl.Font, FontStyle.Regular);
            lbl.Location = new Point(22, 30);
            TextBox txt = new TextBox();
            g1.Controls.Add(txt);
            txt.Location = new Point(139, 30);
            txt.Font = new Font(txt.Font, FontStyle.Regular);
            txt.Size = new Size(270, 20);

            Label lbl2 = new Label();
            g1.Controls.Add(lbl2);
            lbl2.Text = "DB Name";
            lbl2.Font = new Font(lbl2.Font, FontStyle.Regular);
            lbl2.Location = new Point(22, 62);
            TextBox txt2 = new TextBox();
            g1.Controls.Add(txt2);
            txt2.Location = new Point(139, 62);
            txt2.Font = new Font(txt2.Font, FontStyle.Regular);
            txt2.Size = new Size(270, 20);

            Label lbl4 = new Label();
            g1.Controls.Add(lbl4);
            lbl4.Text = "User Id";
            lbl4.Font = new Font(lbl4.Font, FontStyle.Regular);
            lbl4.Location = new Point(22, 90);
            TextBox txt4 = new TextBox();
            g1.Controls.Add(txt4);
            txt4.Location = new Point(139, 90);
            txt4.Font = new Font(txt4.Font, FontStyle.Regular);
            txt4.Size = new Size(270, 20);

            Label lbl5 = new Label();
            g1.Controls.Add(lbl5);
            lbl5.Text = "Password";
            lbl5.Font = new Font(lbl5.Font, FontStyle.Regular);
            lbl5.Location = new Point(22, 120);
            TextBox txt5 = new TextBox();
            g1.Controls.Add(txt5);
            txt5.Location = new Point(139, 120);
            txt5.Size = new Size(270, 20);
            txt5.Font = new Font(txt5.Font, FontStyle.Regular);
            txt5.PasswordChar = '*';

            Label lbl6 = new Label();
            g1.Controls.Add(lbl6);
            lbl6.Text = "Max Pool Size";
            lbl6.Font = new Font(lbl6.Font, FontStyle.Regular);
            lbl6.Location = new Point(22, 150);
            TextBox txt6 = new TextBox();
            g1.Controls.Add(txt6);
            txt6.Location = new Point(139, 150);
            txt6.Font = new Font(txt6.Font, FontStyle.Regular);
            txt6.Size = new Size(270, 20);

            Label lbl7 = new Label();
            g1.Controls.Add(lbl7);
            lbl7.Text = "Max ATMs";
            lbl7.Font = new Font(lbl7.Font, FontStyle.Regular);
            lbl7.Location = new Point(22, 180);
            TextBox txt7 = new TextBox();
            g1.Controls.Add(txt7);
            txt7.Location = new Point(139, 180);
            txt7.Size = new Size(85, 20);
            txt7.Font = new Font(txt7.Font, FontStyle.Regular);

            Label lbl8 = new Label();
            g1.Controls.Add(lbl8);
            lbl8.Text = "Current ATMs";
            lbl8.Font = new Font(lbl8.Font, FontStyle.Regular);
            lbl8.Location = new Point(275, 180);
            lbl8.Size = new Size(75, 20);
            Label lbl9 = new Label();
            g1.Controls.Add(lbl9);
            lbl9.Text = "   ";
            lbl9.Font = new Font(lbl9.Font, FontStyle.Regular);
            lbl9.Location = new Point(360, 180);
            lbl9.Size = new Size(50, 15);
            lbl9.BorderStyle = BorderStyle.Fixed3D;

            Button btn = new Button();
            g1.Controls.Add(btn);
            btn.Text = "Delete";
            btn.Click += new EventHandler(DeleteDBServerButton_Click);
            btn.Left = 360;
            btn.Font = new Font(btn.Font, FontStyle.Regular);
            btn.ForeColor = Color.Red;
            btn.Width = 50;

            Button btn1 = new Button();
            g1.Controls.Add(btn1);
            btn1.Text = "Test";
            btn1.Click += new EventHandler(TestDBServer_Click);
            btn1.Left = 300;
            btn1.Font = new Font(btn1.Font, FontStyle.Regular);
            btn1.ForeColor = Color.Green;
            btn1.Width = 50;
        }
        private void AddDataBaseServer(string groupId, string serverName, string dbName, string user, string pass, string poolSize, string maxAtms, string currentAtms)
        {
            GroupBox g1 = new GroupBox();
            this.tabPage1.Controls.Add(g1);
            g1.Top = dbServerLeft * 230 + 270;
            g1.Left = 8;
            g1.Text = "DB Server " + groupId;
            dbServerLeft = dbServerLeft + 1;
            g1.Size = new Size(418, 220);
            g1.AutoSizeMode = AutoSizeMode.GrowOnly;
            g1.AutoSize = false;

            Label lbl = new Label();
            g1.Controls.Add(lbl);
            lbl.Text = "DB Server";
            lbl.Font = new Font(lbl.Font, FontStyle.Regular);
            lbl.Location = new Point(22, 30);
            TextBox txt = new TextBox();
            g1.Controls.Add(txt);
            txt.Location = new Point(139, 30);
            txt.Size = new Size(270, 20);
            txt.Text = serverName;
            txt.Font = new Font(txt.Font, FontStyle.Regular);

            Label lbl2 = new Label();
            g1.Controls.Add(lbl2);
            lbl2.Text = "DB Name";
            lbl2.Font = new Font(lbl2.Font, FontStyle.Regular);
            lbl2.Location = new Point(22, 62);
            TextBox txt2 = new TextBox();
            g1.Controls.Add(txt2);
            txt2.Location = new Point(139, 62);
            txt2.Size = new Size(270, 20);
            txt2.Text = dbName;
            txt2.Font = new Font(txt2.Font, FontStyle.Regular);

            Label lbl4 = new Label();
            g1.Controls.Add(lbl4);
            lbl4.Text = "User Id";
            lbl4.Font = new Font(lbl4.Font, FontStyle.Regular);
            lbl4.Location = new Point(22, 90);
            TextBox txt4 = new TextBox();
            g1.Controls.Add(txt4);
            txt4.Location = new Point(139, 90);
            txt4.Size = new Size(270, 20);
            txt4.Text = user;
            txt4.Font = new Font(txt4.Font, FontStyle.Regular);

            Label lbl5 = new Label();
            g1.Controls.Add(lbl5);
            lbl5.Text = "Password";
            lbl5.Font = new Font(lbl5.Font, FontStyle.Regular);
            lbl5.Location = new Point(22, 120);
            TextBox txt5 = new TextBox();
            g1.Controls.Add(txt5);
            txt5.Location = new Point(139, 120);
            txt5.Size = new Size(270, 20);
            txt5.PasswordChar = '*';
            txt5.Text = pass;
            txt5.Font = new Font(txt5.Font, FontStyle.Regular);

            Label lbl6 = new Label();
            g1.Controls.Add(lbl6);
            lbl6.Text = "Max Pool Size";
            lbl6.Font = new Font(lbl6.Font, FontStyle.Regular);
            lbl6.Location = new Point(22, 150);
            TextBox txt6 = new TextBox();
            g1.Controls.Add(txt6);
            txt6.Location = new Point(139, 150);
            txt6.Size = new Size(270, 20);
            txt6.Text = poolSize;
            txt6.Font = new Font(txt6.Font, FontStyle.Regular);

            Label lbl7 = new Label();
            g1.Controls.Add(lbl7);
            lbl7.Text = "Max ATMs";
            lbl7.Font = new Font(lbl7.Font, FontStyle.Regular);
            lbl7.Location = new Point(22, 180);
            TextBox txt7 = new TextBox();
            g1.Controls.Add(txt7);
            txt7.Location = new Point(139, 180);
            txt7.Size = new Size(85, 20);
            txt7.Text = maxAtms;
            txt7.Font = new Font(txt7.Font, FontStyle.Regular);

            Label lbl8 = new Label();
            g1.Controls.Add(lbl8);
            lbl8.Text = "Current ATMs";
            lbl8.Font = new Font(lbl8.Font, FontStyle.Regular);
            lbl8.Location = new Point(275, 180);
            lbl8.Size = new Size(75, 20);
            Label lbl9 = new Label();
            g1.Controls.Add(lbl9);
            lbl9.Text = currentAtms;
            lbl9.Font = new Font(lbl9.Font, FontStyle.Regular);
            lbl9.Location = new Point(360, 180);
            lbl9.Size = new Size(50, 15);
            lbl9.BorderStyle = BorderStyle.Fixed3D;

            Button btn1 = new Button();
            g1.Controls.Add(btn1);
            btn1.Text = "Test";
            btn1.Click += new EventHandler(TestDBServer_Click);
            btn1.Left = 360;
            btn1.Font = new Font(btn1.Font, FontStyle.Regular);
            btn1.ForeColor = Color.Green;
            btn1.Width = 50;
        }
        private void AddAppServer(string gropuId ,string server, string port)
        {

            GroupBox g1 = new GroupBox();
            this.tabPage3.Controls.Add(g1);
            g1.Top = appServerLeft * 105 + 50;
            g1.Left = 8;
            g1.Text = "App Server " + gropuId;
            appServerLeft = appServerLeft + 1;
            g1.Size = new Size(418, 99);
            g1.AutoSizeMode = AutoSizeMode.GrowOnly;
            g1.AutoSize = false;

            Label lbl = new Label();
            g1.Controls.Add(lbl);
            lbl.Text = "Server Name/IP";
            lbl.Font = new Font(lbl.Font, FontStyle.Regular);
            lbl.Location = new Point(22, 30);
            TextBox txt = new TextBox();
            g1.Controls.Add(txt);
            txt.Location = new Point(139, 30);
            txt.Size = new Size(270, 20);
            txt.Text = server;
            txt.Font = new Font(txt.Font, FontStyle.Regular);

            Label lbl2 = new Label();
            g1.Controls.Add(lbl2);
            lbl2.Text = "Server Port";
            lbl2.Font = new Font(lbl2.Font, FontStyle.Regular);
            lbl2.Location = new Point(22, 62);
            TextBox txt2 = new TextBox();
            g1.Controls.Add(txt2);
            txt2.Location = new Point(139, 62);
            txt2.Size = new Size(270, 20);
            txt2.Text = port;
            txt2.Font = new Font(txt2.Font, FontStyle.Regular);

            Button btn = new Button();
            g1.Controls.Add(btn);
            btn.Text = "Test";
            btn.Click += new EventHandler(TestAppServer_Click);
            btn.Left = 360;
            btn.Font = new Font(btn.Font, FontStyle.Regular);
            btn.ForeColor = Color.Green;
            btn.Width = 50;

        }
        public void SaveDBServersInfo(string key, bool isWinAuth)
        {
            var dbGroupBoxes = tabPage1.Controls.OfType<GroupBox>().OrderBy(x => x.Text).ToList();
            int diff = dbGroupBoxes.Count - conn.DBServers.Count;
            for (int i = 0; i < diff; i++)
            {
                conn.DBServers.Add(new DBServerInfo());
            }
            if (isWinAuth)
            {
                for (int i = 1; i < dbGroupBoxes.Count; i++)
                {

                    conn.DBServers[i].ServerName = dbGroupBoxes[i].Controls[1].Text;
                    conn.DBServers[i].ServerConnection = Encryption.Cryptic.EncryptString(string.Format("data source={0};", dbGroupBoxes[i].Controls[1].Text), key);
                    conn.DBServers[i].ServerCredentials = Encryption.Cryptic.EncryptString(string.Format(" initial catalog={0}; Integrated Security=True", dbGroupBoxes[i].Controls[3].Text), key);
                    conn.DBServers[i].MaxPoolSize = dbGroupBoxes[i].Controls[9].Text;
                    conn.DBServers[i].MaxATMs = dbGroupBoxes[i].Controls[11].Text;
                }
            }
            else
            {
                for (int i = 1; i < dbGroupBoxes.Count; i++)
                {
                    conn.DBServers[i].ServerName = dbGroupBoxes[i].Controls[1].Text;
                    conn.DBServers[i].ServerConnection = Encryption.Cryptic.EncryptString(string.Format("data source={0};", dbGroupBoxes[i].Controls[1].Text), key);
                    conn.DBServers[i].ServerCredentials = Encryption.Cryptic.EncryptString(string.Format(" initial catalog={0}; user id={1}; pwd={2};", dbGroupBoxes[i].Controls[3].Text,
                        dbGroupBoxes[i].Controls[5].Text, dbGroupBoxes[i].Controls[7].Text), key);
                    conn.DBServers[i].MaxPoolSize = dbGroupBoxes[i].Controls[9].Text;
                    conn.DBServers[i].MaxATMs = dbGroupBoxes[i].Controls[11].Text;
                }
            }
        }
        public void SaveAppServersInfo()
        {
            var appGroupBoxes = tabPage3.Controls.OfType<GroupBox>().OrderBy(x => x.Text).ToList();
            int diff = appGroupBoxes.Count - conn.AppServers.Count;

            for (int i = 0; i < diff; i++)
            {
                conn.AppServers.Add(new AppServerInfo());
            }
            for (int i = 0; i < appGroupBoxes.Count; i++)
            {
                conn.AppServers[i].ServerIP = appGroupBoxes[i].Controls[1].Text;
                conn.AppServers[i].ServerPort = appGroupBoxes[i].Controls[3].Text;
            }
        }
        public void TestDBServer_Click(object sender, EventArgs e)
        {
            var groupView = ((Control.ControlAccessibleObject)((Control)sender).AccessibilityObject).Owner.Parent;
            string connStr = string.Empty;
            if (checkBox_WindowsAuth.Checked && groupView.Text.ToLower().Contains("core"))
                connStr = string.Format("data source={0}; initial catalog={1}; Integrated Security=True", groupView.Controls[9].Text, groupView.Controls[8].Text);
            else if(checkBox_WindowsAuth.Checked)
                connStr = string.Format("data source={0}; initial catalog={1}; Integrated Security=True", groupView.Controls[1].Text, groupView.Controls[3].Text);
            else if(groupView.Text.ToLower().Contains("core"))
                connStr = string.Format("data source={0}; initial catalog={1}; user id={2}; pwd={3};", groupView.Controls[9].Text, groupView.Controls[8].Text, groupView.Controls[7].Text, groupView.Controls[6].Text);
            else    
                connStr = string.Format("data source={0}; initial catalog={1}; user id={2}; pwd={3};", groupView.Controls[1].Text, groupView.Controls[3].Text, groupView.Controls[5].Text, groupView.Controls[7].Text);
            
            if(ConnectionInitializer.IsDBServerConnected(connStr))
                MessageBox.Show(this, "Connection has been successfully established.", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(this, "Failed to connect to the Database.", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public void TestAppServer_Click(object sender, EventArgs e)
        {
            var groupView = ((Control.ControlAccessibleObject)((Control)sender).AccessibilityObject).Owner.Parent;
            
            if (ConnectionInitializer.PingAppServer(groupView.Controls[1].Text,Convert.ToInt32(groupView.Controls[3].Text)))
                MessageBox.Show(this, "Connection has been successfully established.", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(this, "Failed to connect to the server.", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    
        public string CheckForInitDBAtmsInfo()
        {
            Task<DataTable> task = null;
            DataTable dt = null;
            string exceptionMsg = string.Empty;
            int OffsetRowCount = 0;
            bool AtmsExists = conn.DBServers.Any(db => db.AtmIds.Count > 0);
            if (AtmsExists)
                return "";
            if (string.IsNullOrEmpty(coreDBname.Text))
                return "Core DB Name is missing !";

            for (int i = 0; i < conn.DBServers.Count; i++)
            {
                int atmsCount = Convert.ToInt32(conn.DBServers[i].MaxATMs);
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter { ParameterName = "MaxAtms", SqlDbType = SqlDbType.Int, Value = atmsCount });
                sqlParams.Add(new SqlParameter { ParameterName = "CoreDB", SqlDbType = SqlDbType.VarChar, Value = coreDBname.Text });
                sqlParams.Add(new SqlParameter { ParameterName = "OffsetRows", SqlDbType = SqlDbType.Int, Value = OffsetRowCount });
                task = Executor.GetDataTable("", conn.DBServers[0],"GetAtmsInfo", sqlParams.ToArray());
                OffsetRowCount += atmsCount;

                if (task.Exception != null && string.IsNullOrEmpty(task.Exception.Message))
                    exceptionMsg += "DB server " + (i + 1).ToString() + " : " + task.Exception.Message + Environment.NewLine;
                else
                {
                    try
                    {
                        dt = task.Result;
                        if (conn.DBServers == null)
                            conn.DBServers = new List<DBServerInfo>();
                        if (conn.DBServers[i].AtmInfo == null)
                            conn.DBServers[i].AtmInfo = new Dictionary<string, string>();
                        if (conn.DBServers[i].AtmIds == null)
                            conn.DBServers[i].AtmIds = new List<string>();

                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            conn.DBServers[i].AtmIds.Add(dt.Rows[j][0].ToString());
                            conn.DBServers[i].AtmInfo.Add(dt.Rows[j][1].ToString(), dt.Rows[j][0].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        exceptionMsg += "DB server " + (i + 1).ToString() + " : " + ex.Message + Environment.NewLine;
                        continue;
                    }
                }
            }
            return exceptionMsg;
        }
    }
}