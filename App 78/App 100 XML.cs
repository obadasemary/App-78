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
    public partial class App_100_XML : Form
    {
        DataSet Ds = new DataSet();
        int Position;
        public App_100_XML()
        {
            InitializeComponent();
            SELECTBOOKS();
        }

        public void MoveData()
        {
            if (Position > Ds.Tables["Book"].Rows.Count - 1 || Position < 0)
            {
                Position = 0;
                return;
            }
            else
            {
                txtId.Text = Ds.Tables["Book"].Rows[Position]["ID"].ToString();
                txtTitle.Text = Ds.Tables["Book"].Rows[Position]["Title"].ToString();
                txtAuthor.Text = Ds.Tables["Book"].Rows[Position]["Author"].ToString();
                txtPages.Text = Ds.Tables["Book"].Rows[Position]["Pages_Number"].ToString();
                dateP.Text = Ds.Tables["Book"].Rows[Position]["Publish_Date"].ToString();
            }            
        }

        public void SELECTBOOKS()
        {
            Ds.Clear();
            Ds.ReadXml("XMLDATA.xml");
            dataGridView1.DataSource = Ds.Tables[0];
            Ds.Tables[0].TableName = "Book";            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRow Dr = Ds.Tables["Book"].NewRow();
            Dr[0] = txtId.Text;
            Dr[1] = txtTitle.Text;
            Dr[2] = txtAuthor.Text;
            Dr[3] = txtPages.Text;
            Dr[4] = dateP.Text;
            Ds.Tables["Book"].Rows.Add(Dr);
            Ds.WriteXml("XMLDATA.xml");
            MessageBox.Show("Add Done", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //SELECTBOOKS();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTitle.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtAuthor.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtPages.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateP.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= Ds.Tables["Book"].Rows.Count - 1; i++)
            {
                if (txtId.Text == Ds.Tables["Book"].Rows[i][0].ToString())
                {
                    Ds.Tables["Book"].Rows[i].Delete();
                    Ds.WriteXml("XMLDATA.xml");
                    MessageBox.Show("Delete Done", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= Ds.Tables["Book"].Rows.Count - 1; i++)
            {
                if (txtId.Text == Ds.Tables["Book"].Rows[i]["ID"].ToString())
                {
                    DataRow Dr = Ds.Tables["Book"].Rows[i];
                    Dr[0] = txtId.Text;
                    Dr[1] = txtTitle.Text;
                    Dr[2] = txtAuthor.Text;
                    Dr[3] = txtPages.Text;
                    Dr[4] = dateP.Text;
                    Ds.WriteXml("XMLDATA.xml");
                    MessageBox.Show("Update Done", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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

        private void button6_Click(object sender, EventArgs e)
        {
            Position = 0;
            MoveData();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Position = Position - 1;
            MoveData();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Position = Position + 1;
            MoveData();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Position = Ds.Tables["Book"].Rows.Count - 1;
            MoveData();
        }
    }
}
