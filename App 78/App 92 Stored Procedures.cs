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
    public partial class App_92_Stored_Procedures : Form
    {
        SqlConnection cn = new SqlConnection(@"Server=.\SQLEXPRESS; DataBase=Lib_DB; Integrated Security =true");
        SqlCommand Cmd;
        SqlDataAdapter sDa;
        DataTable Dt = new DataTable();
        DataTable Dt2 = new DataTable();
        public App_92_Stored_Procedures()
        {
            InitializeComponent();
            SELECTBOOKS();
            ComboBoxSelect();                        
        }

        public void ComboBoxSelect()
        {
            Dt.Clear();
            Cmd = new SqlCommand("SelectBooks", cn);
            Cmd.CommandType = CommandType.StoredProcedure;
            sDa = new SqlDataAdapter(Cmd);
            sDa.Fill(Dt);
            comboBox1.DataSource = Dt;
            comboBox1.DisplayMember = "ID";
            comboBox1.ValueMember = "ID";
        }

        public void SELECTBOOKS()
        {
            Dt.Clear();
            Cmd = new SqlCommand("SelectBooks", cn);
            Cmd.CommandType = CommandType.StoredProcedure;
            sDa = new SqlDataAdapter(Cmd);
            sDa.Fill(Dt);
            this.dataGridView1.DataSource = Dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cmd = new SqlCommand("InsertBook", cn);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter[] Param = new SqlParameter[5];
            Param[0] = new SqlParameter("@ID", SqlDbType.NVarChar, 50);
            Param[0].Value = txtId.Text;

            Param[1] = new SqlParameter("@Title", SqlDbType.NVarChar, 250);
            Param[1].Value = txtTitle.Text;

            Param[2] = new SqlParameter("@Author", SqlDbType.NVarChar, 50);
            Param[2].Value = txtAuthor.Text;
            
            Param[3] = new SqlParameter("@Pages_Number", SqlDbType.Int);
            Param[3].Value = txtPages.Text;
            
            Param[4] = new SqlParameter("@Publish_Date", SqlDbType.DateTime);
            Param[4].Value = dateP.Value;

            Cmd.Parameters.AddRange(Param);
            cn.Open();
            Cmd.ExecuteNonQuery();
            cn.Close();
                        
            MessageBox.Show("Add Done", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SELECTBOOKS();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cmd = new SqlCommand("DeleteBook", cn);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter Param = new SqlParameter();
            Param = new SqlParameter("@ID", SqlDbType.NVarChar, 50);
            Param.Value = txtId.Text;

            Cmd.Parameters.Add(Param);
            cn.Open();
            Cmd.ExecuteNonQuery();
            cn.Close();
            
            MessageBox.Show("Delete Done", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            SELECTBOOKS();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cmd = new SqlCommand("UpdateBook", cn);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter[] Param = new SqlParameter[5];
            Param[0] = new SqlParameter("@ID", SqlDbType.NVarChar, 50);
            Param[0].Value = txtId.Text;

            Param[1] = new SqlParameter("@Title", SqlDbType.NVarChar, 250);
            Param[1].Value = txtTitle.Text;

            Param[2] = new SqlParameter("@Author", SqlDbType.NVarChar, 50);
            Param[2].Value = txtAuthor.Text;

            Param[3] = new SqlParameter("@Pages_Number", SqlDbType.Int);
            Param[3].Value = txtPages.Text;

            Param[4] = new SqlParameter("@Publish_Date", SqlDbType.DateTime);
            Param[4].Value = dateP.Value;

            Cmd.Parameters.AddRange(Param);
            cn.Open();
            Cmd.ExecuteNonQuery();
            cn.Close();
            
            MessageBox.Show("Update Done", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SELECTBOOKS();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {            
            txtId.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            txtTitle.Text = dataGridView1.CurrentRow.Cells["Title"].Value.ToString();
            txtAuthor.Text = dataGridView1.CurrentRow.Cells["Author"].Value.ToString();
            txtPages.Text = dataGridView1.CurrentRow.Cells["Pages_Number"].Value.ToString();
            dateP.Text = dataGridView1.CurrentRow.Cells["Publish_Date"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            txtPages.Clear();
            dateP.ResetText();
            txtId.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Dt2.Clear();
                sDa = new SqlDataAdapter("Select * from Books where ID='" + comboBox1.Text + "'", cn);
                sDa.Fill(Dt2);
                DataRowCollection DRC = Dt2.Rows;
                txtId.Text = DRC[0]["ID"].ToString();
                txtTitle.Text = DRC[0]["Title"].ToString();
                txtAuthor.Text = DRC[0]["Author"].ToString();
                txtPages.Text = DRC[0]["Pages_Number"].ToString();
                dateP.Text = DRC[0]["Publish_Date"].ToString();                
            }
            catch 
            {
                return;
            }
        }
    }
}
