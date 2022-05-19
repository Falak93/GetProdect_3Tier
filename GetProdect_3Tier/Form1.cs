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

     
       Product currentProduct= new Product();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            RefreshItemGrid1();
          

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
           

        }



        private void txtColor_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow currentRow = new DataGridViewRow();
            currentRow = dataGridView1.Rows[e.RowIndex];

            currentProduct.ProductID = int.Parse(currentRow.Cells[0].Value.ToString());
            currentProduct.ProductName = currentRow.Cells[1].Value.ToString();
            currentProduct.Design = currentRow.Cells[2].Value.ToString();
            currentProduct.Color = currentRow.Cells[3].Value.ToString();
         

           txtProdectName.Text= currentProduct.ProductName;
           txtDesign.Text = currentProduct.Design;
            txtColor.Text = currentProduct.Color;
            


        }
        private void RefreshItemGrid1()
        {
            dataGridView1.DataSource = ProductDAL.GetAllProduct();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ProductDAL.DeleteProdect(currentProduct);

            RefreshItemGrid1();
        }
    }
}
