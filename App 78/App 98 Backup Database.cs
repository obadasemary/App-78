using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace App_78
{
    public partial class App_98_Backup_Database : Form
    {
        SqlConnection cn = new SqlConnection(@"Server=.\SQLEXPRESS; DataBase=Lib_DB; Integrated Security =true");
        SqlConnection CN = new SqlConnection(@"Server=.\SQLEXPRESS; DataBase=Master; Integrated Security =true");
        SqlCommand Cmd;
        public App_98_Backup_Database()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Backup Files (*.Bak) |*.bak";
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                Cmd = new SqlCommand("Backup Database Lib_DB To Disk ='" + SFD.FileName + "'", cn);
                cn.Open();
                Cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Backup Completed ", "Backup Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "Backup Files (*.Bak) |*.bak";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                Cmd = new SqlCommand("ALTER DATABASE Lib_DB SET OFFLINE WITH ROLLBACK IMMEDIATE; RESTORE DATABASE Lib_DB From Disk ='" + OFD.FileName + "' WITH REPLACE", CN);
                CN.Open();
                Cmd.ExecuteNonQuery();
                CN.Close();
                MessageBox.Show("Restore Completed ", "Restore Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //string query = "ALTER DATABASE Lib_DB SET OFFLINE WITH ROLLBACK IMMEDIATE; RESTORE DATABASE Lib_DB From Disk ='" + OFD.FileName + "' WITH REPLACE";
            //Cmd = new SqlCommand(query, CN);
            //CN.Open();
            //Cmd.ExecuteNonQuery();
            //CN.Close();
            //MessageBox.Show("Restore Completed ", "Restore Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }        
    }
}
