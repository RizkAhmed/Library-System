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

namespace Demo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string constr = "Data Source=DESKTOP-4RHPT33\\SQLEXPRESS;Initial Catalog = BikeStores; Integrated Security = True";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand sqlComm;
        DataTable DT;
        SqlDataAdapter DA;
        BindingSource BS;

        private void Form1_Load(object sender, EventArgs e)
        {
            
            string sql = "select * from production.products";
            sqlComm = new SqlCommand(sql, con);
            DA = new SqlDataAdapter(sqlComm);
            DT = new DataTable();
            DA.Fill(DT);
            
            BS = new BindingSource(DT,"");
            comboBox1.DataSource = BS;
            comboBox1.DisplayMember= "product_name";
            comboBox1.ValueMember = "product_id";
            dataGridView.DataSource = BS;
            dataGridView.Columns["product_id"].Visible=false;
            dataGridView.Columns["product_name"].Width=400;
            textBox2.DataBindings.Add("Text",BS, "list_price");
            //-------------
            sql = "select brand_id as 'id' ,brand_name as 'name' from production.brands";
            sqlComm = new SqlCommand(sql, con);
            DA = new SqlDataAdapter(sqlComm);
            DataTable BDT = new DataTable();
            DA.Fill(BDT);
            DataGridViewComboBoxColumn DC = new DataGridViewComboBoxColumn();
            DC.HeaderText = "brandds";
            dataGridView.Columns.AddRange(DC);
            DC.DataSource = BDT;
            DC.DisplayMember = "name";
            DC.ValueMember = "id";
            DC.DataPropertyName = "brand_id";
            //----------------------
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from production.products where list_price>@PRICE;";
            sqlComm = new SqlCommand(sql, con);
            sqlComm.Parameters.AddWithValue("@PRICE", Convert.ToDecimal(textBox1.Text));
            DA = new SqlDataAdapter(sqlComm);
            DT = new DataTable();
            DA.Fill(DT);
            BS.DataSource = DT;
            dataGridView.DataSource = BS;
        }

        private void save_Click(object sender, EventArgs e)
        {
            string sql = "update production.products set list_price =@PRICE where product_id = @ID;";
            sqlComm = new SqlCommand(sql, con);
            sqlComm.Parameters.AddWithValue("@PRICE", Convert.ToDecimal(textBox2.Text));
            sqlComm.Parameters.AddWithValue("@ID", Convert.ToInt32(comboBox1.SelectedValue));
            con.Open();
            sqlComm.ExecuteNonQuery();
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void left_Click(object sender, EventArgs e)
        {
            BS.MovePrevious();
        }

        private void right_Click(object sender, EventArgs e)
        {
            BS.MoveNext();
        }

        private void first_Click(object sender, EventArgs e)
        {
            BS.MoveFirst();
        }

        private void last_Click(object sender, EventArgs e)
        {
            BS.MoveLast();
        }
    }
}
