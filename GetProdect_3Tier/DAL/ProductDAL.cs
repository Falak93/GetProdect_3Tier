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

    internal class ProductDAL
    {
        private static string connectionString = "Server=DESKTOP-29SJ1T7; database=GetProduct; Integrated Security=true";

        private static readonly SqlConnection connection = new SqlConnection(connectionString);
        public static void CreateProdect(Product product)
        {
            string commandText = $"Insert into GProduct values('{product.ProductName}', '{product.Design}'," +
              $" {product.Color}, {product.ProductID} )";
            SqlCommand command = new SqlCommand(commandText, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateProdect(Product product)
        {

            string commandText = $"Update GProduct Set " +
              $"ProductName = '{product.ProductName}', " +
              $"Design = '{product.Design}', " +
              $"Color = '{product.Color}', " +
              $"ProductID = {product.ProductID} " +
              $"where ProductID = {product.ProductID}";

            SqlCommand command = new SqlCommand(commandText, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }
        public static DataTable GetAllProduct()
        {
            string command = String.Format("Select * from Gproducts");

            SqlCommand sqlCommand = new SqlCommand(command, connection);

            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        }
        public static Product GetProductById(int ProductID)
        {
            Product product = new Product();

            string commandText = $"Select * from  GProduct where ProductID={ProductID}";
            SqlCommand command = new SqlCommand(commandText, connection);

            connection.Open();

            SqlDataReader ProductReader = command.ExecuteReader();

            if (ProductReader.HasRows)
            {
                while (ProductReader.Read())
                {
                   product.ProductID= ProductReader.GetInt32(0);
                   product.ProductName = ProductReader.GetString(1);
                    product.Design = ProductReader.GetString(2);
                    product.Color = ProductReader.GetString(3);
                   
                }
            }

            connection.Close();
            return product;

        }

        public static void DeleteProdect(Product product)
        {

            string commandText = $"Delete from GProduct where ProdectID = {product.ProductID}";

            SqlCommand command = new SqlCommand(commandText, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

    }
}