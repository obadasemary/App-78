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
    public partial class App_89_DataBinding : Form
    {
        SqlConnection cn = new SqlConnection(@"Server=.\SQLEXPRESS; DataBase=Lib_DB; Integrated Security =true");
        SqlDataAdapter sDa;
        DataSet Ds = new DataSet();
        DataTable Dt = new DataTable();
        CurrencyManager Cm;
        SqlCommandBuilder CmdB;
        public App_89_DataBinding()
        {
            InitializeComponent();
            sDa = new SqlDataAdapter("SELECT * FROM Books", cn);
            sDa.Fill(Dt);
            txtId.DataBindings.Add("Text", Dt, "ID");
            txtTitle.DataBindings.Add("Text", Dt, "Title");
            txtAuthor.DataBindings.Add("Text", Dt, "Author");
            txtPages.DataBindings.Add("Text", Dt, "Pages_Number");
            dateP.DataBindings.Add("Text", Dt, "Publish_Date");

            Cm = (CurrencyManager)this.BindingContext[Dt];
            lblPosition.Text = (Cm.Position + 1) + " / " + (Dt.Rows.Count);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cm.Position = 0;
            lblPosition.Text = (Cm.Position + 1) + " / " + (Dt.Rows.Count);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cm.Position -= 1;
            lblPosition.Text = (Cm.Position + 1) + " / " + (Dt.Rows.Count);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cm.Position += 1;
            lblPosition.Text = (Cm.Position + 1) + " / " + (Dt.Rows.Count);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cm.Position = Dt.Rows.Count - 1;
            lblPosition.Text = (Cm.Position + 1) + " / " + (Dt.Rows.Count);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Cm.AddNew();
            txtId.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Cm.EndCurrentEdit();
            CmdB = new SqlCommandBuilder(sDa);
            sDa.Update(Dt);
            MessageBox.Show("Added Done", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblPosition.Text = (Cm.Position + 1) + " / " + (Dt.Rows.Count);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Cm.RemoveAt(Cm.Position);
            Cm.EndCurrentEdit();
            CmdB = new SqlCommandBuilder(sDa);
            sDa.Update(Dt);
            MessageBox.Show("Delete Done", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            lblPosition.Text = (Cm.Position + 1) + " / " + (Dt.Rows.Count);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Cm.EndCurrentEdit();
            CmdB = new SqlCommandBuilder(sDa);
            sDa.Update(Dt);
            Cm.Refresh();
            MessageBox.Show("Update Done", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblPosition.Text = (Cm.Position + 1) + " / " + (Dt.Rows.Count);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
