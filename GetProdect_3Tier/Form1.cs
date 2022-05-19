using GetProdect_3Tier.DAL;
using GetProdect_3Tier.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetProdect_3Tier
{
    public partial class Form1 : Form
    {
        Product currentproduct = new Product();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txtProductID.Enabled=false;
            dataGridView1.DataSource = ProductDAL.GetAllProduct();
            clearform();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Product product = new Product();    
            product.ProductName = txtProdectName.Text;
            product.Design = txtDesign.Text;
            product.Color = txtColor.Text;

            ProductDAL.CreateProdect(product);
            RefreshProductGrid1();
            clearform();
        }
        private void txtColor_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            currentproduct.ProductName = txtProdectName.Text;
            currentproduct.Design = txtDesign.Text;
            currentproduct.Color = txtColor.Text;

            ProductDAL.UpdateProdect(currentproduct);
            RefreshProductGrid1();
            clearform();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            ProductDAL.DeleteProdect(currentproduct);
            RefreshProductGrid1();
            clearform();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 
        }
        private void RefreshProductGrid1()
        {
            dataGridView1.DataSource = ProductDAL.GetAllProduct();
        }
        private void clearform()
        {
            txtColor.Text = "";
            txtDesign.Text = "";
            txtProdectName.Text = "";
            txtProductID.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentproduct = new Product();

            DataGridViewRow row = new DataGridViewRow();
            row = dataGridView1.Rows[e.RowIndex];

            currentproduct.ProductID = int.Parse(row.Cells[0].Value.ToString());
            currentproduct.ProductName = row.Cells[1].Value.ToString();
            currentproduct.Design = row.Cells[2].Value.ToString();
            currentproduct.Color = row.Cells[3].Value.ToString();

            txtProductID.Text = currentproduct.ProductID.ToString();
            txtProdectName.Text = currentproduct.ProductName;
            txtDesign.Text = currentproduct.Design;
            txtColor.Text = currentproduct.Color;
        }
    }
}
