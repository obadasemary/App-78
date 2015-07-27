using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_78
{
    public partial class App_102_SendSmsMessage : Form
    {
        public App_102_SendSmsMessage()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                try
                {
                    //i use this http://www.vianett.com/en/developers/sms-api-overview api
                    string url = "http://smsc.vianett.no/v3/send.ashx?" +
                        "src=" + txtPhoneNumber.Text + "&" +
                        "dst=" + txtPhoneNumber.Text + "&" +
                        "msg=" + System.Web.HttpUtility.UrlEncode(txtMessage.Text, System.Text.Encoding.GetEncoding("ISO-8859-1")) + "" +
                        "username=" + System.Web.HttpUtility.UrlEncode(txtUserName.Text) + "&" +
                        "password=" + System.Web.HttpUtility.UrlEncode(txtPassword.Text);
                    string result = client.DownloadString(url);
                    if (result.Contains("OK"))
                    {
                        MessageBox.Show("Your Message has been Succcessfull Sent.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Message Sent Failuer.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
