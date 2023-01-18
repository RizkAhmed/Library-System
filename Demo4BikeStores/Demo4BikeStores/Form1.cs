using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo4BikeStores
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosed += (sender, e) => context?.Dispose();
        }
        BikeStoresContext context;
        BindingSource BS;
        private void Form1_Load(object sender, EventArgs e)
        {

            context = new BikeStoresContext();
            context.Products.Load();

            //var data = context.Products.ToList();

            var products = from p in context.Products
                               orderby p.ProductId descending
                               select new 
                               { 
                                   p.ProductId,
                                   p.ProductName,
                                   p.Brand.BrandName,
                                   p.Category.CategoryName,
                                   p.ModelYear,
                                   p.ListPrice 
                               };
                
                BS = new BindingSource(products.ToList(), "");
                DataView.DataSource =BS ;

            //DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            //col.FlatStyle = FlatStyle.Standard;
            //col.DefaultCellStyle.BackColor = Color.Red;
            //col.Text = "ADD";
            //col.Name = "MyButton";
            //DataView.Columns.Add(col);
            DataView.Columns["ProductId"].Visible = false;
                DataView.Columns["ProductName"].Width = 400;
            DataView.Columns["Delete"].Width = 70;
            DataView.Columns["Delete"].DefaultCellStyle.BackColor=Color.Red;
            DataView.Columns["Delete"].DefaultCellStyle.NullValue = "X";


            CatList.DataSource = context.Categories.ToList();
                CatList.DisplayMember = "CategoryName";
                CatList.ValueMember = "CategoryId";

                BrandList.DataSource = context.Brands.ToList();
                BrandList.DisplayMember = "BrandName";
                BrandList.ValueMember = "BrandId";
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            context = new BikeStoresContext();
            context.Products.Load();
            
                var proudect = new Product()
                {
                    ProductName = name.Text,
                    ListPrice = Convert.ToDecimal(price.Text),
                    CategoryId = Convert.ToInt32(CatList.SelectedValue),
                    BrandId = Convert.ToInt32(BrandList.SelectedValue),
                    ModelYear = (short)DateTime.Now.Year
                };
                context.Add(proudect);
                if(context.SaveChanges()>0)
                    MessageBox.Show("Successful Added");



            var products = from p in context.Products
                               orderby p.ProductId descending
                               select new
                               {
                                   p.ProductId,
                                   p.ProductName,
                                   p.Brand.BrandName,
                                   p.Category.CategoryName,
                                   p.ModelYear,
                                   p.ListPrice
                               };
                BS.DataSource = products.ToList();
            //DataView.DataSource = BS;

        }

        private void SaveAll_Click(object sender, EventArgs e)
        {
            DataView.EndEdit();
            if(context.SaveChanges()>0)
                MessageBox.Show("Successful Saved");
            ;

        }

        private void DataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var proID = DataView.Rows[e.RowIndex].Cells["ProductId"].Value;

                DialogResult result = MessageBox.Show("Delete Product", "Worning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var pro = context.Products.Single(e => e.ProductId == Convert.ToInt32(proID));
                    context.Products.Remove(pro);

                    if (context.SaveChanges() > 0)
                    {
                        DataView.Rows.RemoveAt(e.RowIndex);
                    }
                    else
                        MessageBox.Show("Not Deleted...Try again");

                }
                
            }
            catch
            {
                MessageBox.Show("Some thing happind !!\nPlease restart program ");
            }

        }
    }
}
