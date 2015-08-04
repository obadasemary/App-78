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
    public partial class App_88_Data_Views : Form
    {
        SqlConnection cn = new SqlConnection(@"Server=.\SQLEXPRESS; DataBase=Lib_DB; Integrated Security =true");
        SqlDataAdapter sDa;
        DataSet Ds = new DataSet();
        DataTable Dt = new DataTable();
        public App_88_Data_Views()
        {
            InitializeComponent();
            sDa = new SqlDataAdapter("SELECT * FROM Books", cn);
            sDa.Fill(Dt);
            dataGridView1.DataSource = Dt;
        }
    }
}
