using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.DAL
{

    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }

    public class DapperDAL
    {
        string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DB_Name;Data Source=.";

        public IEnumerable<Product> GetAllProducts()
        {
            List<Product> lstProducts = new List<Product>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                //SqlCommand cmd = new SqlCommand("select * from Student", conn);
                //conn.Open();
                //SqlDataReader rdr = cmd.ExecuteReader();

                //while (rdr.Read())
                //{
                //    Product product = new Product();
                //    product.Id = Convert.ToInt32(rdr["Id"]);
                //    product.FirstName = rdr["FirstName"].ToString();
                //    product.LastName = rdr["LastName"].ToString();
                //    product.Email = rdr["Email"].ToString();
                //    product.Mobile = rdr["Mobile"].ToString();
                //    product.Address = rdr["Address"].ToString();

                //    lstStudents.Add(student);
                //}
                //conn.Close();
                lstProducts = db.Query<Product>("Select * From Products").ToList();
            }
            return lstProducts;
        }
        public void CreateProduct(Product model)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                //SqlCommand cmd = new SqlCommand
                //    ("insert into Student VALUES (@FirstName, @LastName, @Email, @Mobile, @Address)", conn);
                //cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                //cmd.Parameters.AddWithValue("@LastName", model.LastName);
                //cmd.Parameters.AddWithValue("@Email", model.Email);
                //cmd.Parameters.AddWithValue("@Mobile", model.Mobile);
                //cmd.Parameters.AddWithValue("@Address", model.Address);
                //conn.Open();
                //cmd.ExecuteNonQuery();
                string sqlQuery = "Insert Into Products Values(@Name, @UnitPrice, @Description, @CategoryID)";

                int rowsAffected = db.Execute(sqlQuery, model);
            }
        }
        public void UpdateProduct(Product model)
        {
            //using (SqlConnection conn = new SqlConnection(connectionString))
            //string spName = "spUpdateStudent";
            //var parameters = new { @Id = model.Id, @FirstName = model.FirstName, @LastName = model.LastName, 
            //    @Email = model.Email, @Mobile = model.Mobile, @Address = model.Address };

            //using(IDbConnection db = new SqlConnection(connectionString))
            //{
            //    string updateCommand = "UPDATE Student SET FirstName = @FirstName, " +
            //        "LastName = @LastName, Email = @Email, Mobile = @Mobile, Address = @Address " +
            //        "where Id = @Id";
            //    SqlCommand cmd = new SqlCommand(updateCommand, conn);
            //    cmd.Parameters.AddWithValue("@Id", model.Id);
            //    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
            //    cmd.Parameters.AddWithValue("@LastName", model.LastName);
            //    cmd.Parameters.AddWithValue("@Email", model.Email);
            //    cmd.Parameters.AddWithValue("@Mobile", model.Mobile);
            //    cmd.Parameters.AddWithValue("@Address", model.Address);
            //    conn.Open();
            //    cmd.ExecuteNonQuery();
            //    var affectedRows = db.Execute(spName, parameters, commandType: CommandType.StoredProcedure);
            //}

            using (SqlConnection conn = new SqlConnection(connectionString))
               
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string updateCommand = "UPDATE Student SET Name = @Name, " +
                    "UnitPrice = @UnitPrice, Description = @Description, CategoryId = @CategoryId" +
                    "where Id = @Id";
                var affectedRows = db.Execute(updateCommand, commandType: CommandType.Text);
            }

        }
        public Product GetProduct(int id)
        {
            Product product = new Product();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (IDbConnection db = new SqlConnection(connectionString))
            {
            //    string selectCommand = "select * from Student where Id = " + id;
            //    SqlCommand cmd = new SqlCommand(selectCommand, conn);
            //    conn.Open();
            //    SqlDataReader rdr = cmd.ExecuteReader();

            //    while (rdr.Read())
            //    {
            //        student.Id = Convert.ToInt32(rdr["Id"]);
            //        student.FirstName = rdr["FirstName"].ToString();
            //        student.LastName = rdr["LastName"].ToString();
            //        student.Email = rdr["Email"].ToString();
            //        student.Mobile = rdr["Mobile"].ToString();
            //        student.Address = rdr["Address"].ToString();
            //    }
            product = db.Query<Product>("Select * From products WHERE Id =" + id).SingleOrDefault();
            }
            return product;            
        }
        public void DeleteProduct(int id)
        {
            //using (SqlConnection conn = new SqlConnection(connectionString))
            //using (IDbConnection db = new SqlConnection(connectionString))
            //{
            //    //string deleteCommand = "delete from Student where Id = " + id;
            //    string deleteCommand = "spDeleteStudent";
            //    SqlCommand cmd = new SqlCommand(deleteCommand, conn);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@Id", id);
            //    conn.Open();
            //    cmd.ExecuteNonQuery();
            //    string sqlQuery = "Delete from Student where Id=" + id;
            //    int rowsAffected = db.Execute(sqlQuery);
            //}

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (IDbConnection db = new SqlConnection(connectionString))
            {

                string sqlQuery = "Delete from products where Id=" + id;
                int rowsAffected = db.Execute(sqlQuery);
            }
        }
    }
}
