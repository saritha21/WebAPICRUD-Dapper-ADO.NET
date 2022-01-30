using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.DAL
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int CategoryId3 { get; set; }
    }

    public class ADONETDAL
    {
        string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DB_Name;Data Source=.";

        public IEnumerable<Product> GetAllProducts()
        {
            List<Product> lstProducts = new List<Product>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from Products", conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Product product = new Product();
                    product.Id = Convert.ToInt32(rdr["Id"]);
                    product.Name = rdr["Name"].ToString();
                    product.UnitPrice = Convert.ToDecimal(rdr["UnitPrice"]);
                    product.Description = rdr["Description"].ToString();
                    product.CategoryId = Convert.ToInt16(rdr["CategoryId"].ToString());


                    lstProducts.Add(product);
                }
                conn.Close();

            }
            return lstProducts;
        }
        public void CreateProduct(Product model)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand
                    ("insert into Products VALUES (@Name, @UnitPrice, @Description, @CategoryId)", conn);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@UnitPrice", model.UnitPrice);
                cmd.Parameters.AddWithValue("@Description", model.Description);
                cmd.Parameters.AddWithValue("@CategoryId", model.CategoryId);
                conn.Open();
                cmd.ExecuteNonQuery();

            }
        }
    }
}
