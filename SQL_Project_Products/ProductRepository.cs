using Dapper;
using System.Data;
using System.Data.SqlClient;
namespace SQL_Project_Products
{
    public class ProductRepository : IProductRepository
    {
        public void Add(Products product)
        {
            using (IDbConnection db = new SqlConnection(Counfiguration.ConnctionString))
            {
                db.Execute(ProductQueres.Create, new { product.Name,product.CategoryId,product.Price });
            }
        }

        public void Delete(string productName)
        {
            using (IDbConnection db = new SqlConnection(Counfiguration.ConnctionString))
                db.Execute(ProductQueres.Delete, new { Name = productName });
        }

        public Products Get(string productName)
        {
            using (IDbConnection db = new SqlConnection(Counfiguration.ConnctionString))
            {
                return db.QueryFirstOrDefault<Products>(ProductQueres.GetByUserName, new { Name = productName  });
            }
        }

        public List<Products> GetAll()
        {
            using (IDbConnection db = new SqlConnection(Counfiguration.ConnctionString))
            {
                return db.Query<Products>(ProductQueres.GetAll).ToList();
            }
        }

        public void Update(Products product)
        {
            using (IDbConnection db = new SqlConnection(Counfiguration.ConnctionString))
               db.Execute(ProductQueres.Update, new {Id = product.Id ,Name = product.Name,CategoryId = product.CategoryId, Price = product.Price });
           
        }
    }
}
