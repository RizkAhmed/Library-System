using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string constr =
                "Data Source=DESKTOP-4RHPT33\\SQLEXPRESS;Initial Catalog=test;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            
            SqlCommand cmd = new SqlCommand("select *from data", con);
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataTable DT=new DataTable();
            DA.Fill(DT);

            dataGridView1.DataSource = DT;
            dataGridView2.DataSource = DT;
            dataGridView3.DataSource = DT;
            dataGridView4.DataSource = DT;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
