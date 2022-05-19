using GetProdect_3Tier.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetProdect_3Tier.DAL
{
    public static class ProductDAL
    {
        private static SqlConnection connection = new SqlConnection("server=DESKTOP-29SJ1T7; database=GetPro; Integrated Security=true");
        public static void CreateProdect(Product product)
        {
            string commandText = String.Format("Insert into Gproducts(ProductName,Design,Color)" +
                "values('{0}','{1}','{2}')", product.ProductName, product.Design, product.Color);
            SqlCommand command = new SqlCommand(commandText, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
          
        }
        public static void UpdateProdect(Product product)
        {

            string commandText = string.Format("Update Gproducts set ProductName='{1}',Design='{2}',Color='{3}'" + "where ProductID ={0}"
                 , product.ProductID, product.ProductName, product.Design, product.Color);

            SqlCommand cmd = new SqlCommand(commandText, connection);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

        }
       
        public static void DeleteProdect(Product product)
        {

            string commandText = String.Format("Delete from Gproducts where ProductID = {0}", product.ProductID);

            SqlCommand command = new SqlCommand(commandText, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
          
        }
        public static DataTable GetAllProduct()
        {
           // string command = String.Format();

            SqlCommand sqlCommand = new SqlCommand("Select * from Gproducts", connection);

            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        }
    }
}