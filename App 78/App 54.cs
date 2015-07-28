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
    public partial class App_54 : Form
    {
        public App_54()
        {
            InitializeComponent();
            this.notifyIcon1.Icon = this.Icon;
            this.notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Please Update your program";
            this.notifyIcon1.BalloonTipTitle = "Info Update";
            this.notifyIcon1.ShowBalloonTip(100000);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Powered By : Obada", "About", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void app13ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_13 app = new App_13();
            app.ShowDialog();
        }

        private void app26ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_26 app = new App_26();
            app.ShowDialog();
        }

        private void app39ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_39 app = new App_39();
            app.ShowDialog();
        }

        private void app54ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_54 app = new App_54();
            app.ShowDialog();
        }

        private void app78ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_78 app = new App_78();
            app.ShowDialog();
        }

        private void app56ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_56 app = new App_56();
            app.ShowDialog();
        }

        private void app58ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_58 app = new App_58();
            app.ShowDialog();
        }

        private void app60ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_60 app = new App_60();
            app.ShowDialog();
        }

        private void app61ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_61 app = new App_61();
            app.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            Button btn = new Button();
            btn.BackColor = button1.BackColor;
            button1.BackColor = button2.BackColor;
            button2.BackColor = btn.BackColor;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value += 1;
            }
            else
            {
                timer2.Enabled = false;
                this.notifyIcon1.Icon = this.Icon;
                this.notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                this.notifyIcon1.BalloonTipText = "Update Done";
                this.notifyIcon1.BalloonTipTitle = "Info Update";
                this.notifyIcon1.ShowBalloonTip(1000);
                MessageBox.Show("Done");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Powered By : Obada", "About", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void app66ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_66 app = new App_66();
            app.ShowDialog();
        }

        private void app68ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_68 app = new App_68();
            app.ShowDialog();
        }

        private void app70PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_70_Print app = new App_70_Print();
            //app.MdiParent = this;
            app.Show();
        }

        private void app72ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_72_IO app = new App_72_IO();
            //app.MdiParent = this;
            app.Show();
        }

        private void app79SQLLIBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_79_SQL_LIB app = new App_79_SQL_LIB();
            app.Show();
        }

        private void app83AddSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_83_Add_SQL app = new App_83_Add_SQL();
            app.Show();
        }

        private void app87DataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void app87DataToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            App_87_Data app = new App_87_Data();
            app.Show();
        }

        private void app88DataViewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_88_Data_Views app = new App_88_Data_Views();
            app.Show();
        }

        private void app89DataBindingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_89_DataBinding app = new App_89_DataBinding();
            app.Show();
        }

        private void app92StoredProceduresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_92_Stored_Procedures app = new App_92_Stored_Procedures();
            app.Show();
        }       

        private void appBackupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_98_Backup_Database app = new App_98_Backup_Database();
            app.Show();
        }

        private void app100XMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_100_XML app = new App_100_XML();
            app.Show();
        }

        private void app99TextToSpeechToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_99_TextToSpeech app = new App_99_TextToSpeech();
            app.Show();
        }

        //private void app102SendSMSMessageToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    App_102_SendSmsMessage app = new App_102_SendSmsMessage();
        //    app.Show();
        //}

        private void app103SMSWhatsAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_103_SmsWhatsApp app = new App_103_SmsWhatsApp();
            app.Show();
        }

        private void app104ReceiveSMSWhatsAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_104_Receive_SMS_WhatsApp app = new App_104_Receive_SMS_WhatsApp();
            app.Show();
        }

        private void app102SendSMSMessageToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            App_102_SendSmsMessage app = new App_102_SendSmsMessage();
            app.Show();
        }

        private void app105SendMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_105_Send_Mail app = new App_105_Send_Mail();
            app.Show();
        }

        private void task1EnumSelectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task_1_Enum_Selector app = new Task_1_Enum_Selector();
            app.Show();
        }       
    }
}
