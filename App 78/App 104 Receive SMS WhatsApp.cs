using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhatsAppApi;

namespace App_78
{
    public partial class App_104_Receive_SMS_WhatsApp : Form
    {
        //i use this api https://github.com/mgp25/WART to get password 
        public App_104_Receive_SMS_WhatsApp()
        {
            InitializeComponent();
        }

        private delegate void UpdateTextBox(TextBox textbox, string value);
        private void UpdateDataTextBox(TextBox textbox, string value)
        {
            textbox.Text += value;
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            txtStatus.Clear();
            var thread = new Thread(t => 
            {
                UpdateTextBox textbox = UpdateDataTextBox;
                WhatsApp wa = new WhatsApp(txtPhoneNumber.Text, txtPassword.Text, txtUserName.Text, true);
                wa.OnConnectSuccess += () => 
                {
                    if (txtStatus.InvokeRequired)
                    {
                        Invoke(textbox, txtStatus, "Connected...");
                    }
                    wa.OnLoginSuccess += (phone, data) =>
                    {
                        if (txtStatus.InvokeRequired)
                        {
                            Invoke(textbox, txtStatus, "\r\nConnection Success !");
                            wa.pollMessage();
                        }
                    };
                    wa.OnGetMessage += (node, from, id, name, message, receipt_sent) =>
                    {
                        if (txtStatus.InvokeRequired)
                        {
                            Invoke(textbox, txtStatus, string.Format("\r\nName = {0}, Message = {1}", name, message));
                        }
                    };
                    wa.OnLoginFailed += (data) =>
                    {
                        if (txtStatus.InvokeRequired)
                        {
                            Invoke(textbox, txtStatus, string.Format("\r\nLogin Failed {0}", data));
                        }
                    };
                    wa.Login();
                };
                wa.OnConnectFailed += (ex) =>
                {
                    if (txtStatus.InvokeRequired)
                    {
                        Invoke(textbox, txtStatus, string.Format("\r\nConnect Failed {0}", ex.StackTrace));
                    }
                };
                wa.Connect();
            }) { IsBackground = true };
            thread.Start();
        }
    }
}
