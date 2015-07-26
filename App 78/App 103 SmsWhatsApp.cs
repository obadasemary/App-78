using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhatsAppApi;

namespace App_78
{
    public partial class App_103_SmsWhatsApp : Form
    {
        public App_103_SmsWhatsApp()
        {
            InitializeComponent();
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            WhatsApp wa = new WhatsApp(txtPhone.Text, txtPassword.Text, txtName.Text, true);
            wa.OnConnectSuccess += () => 
            {
                txtStatus.Text = "Connected...";
                wa.OnLoginSuccess += (phone, data) =>
                {
                    txtStatus.Text += "\r\nConnection Success !";
                    wa.SendMessage(txtTo.Text, txtMessage.Text);
                    txtStatus.Text += "\r\nMessage Sent !";
                };
                wa.OnLoginFailed += (data) =>
                {
                    txtStatus.Text += string.Format("\r\nLoginFailed {0}", data);
                };
                wa.Login();
            };
            wa.OnConnectFailed += (ex) => 
            {
                txtStatus.Text += string.Format("\r\nConnect Failed {0}", ex.StackTrace);
            };
            wa.Connect();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
