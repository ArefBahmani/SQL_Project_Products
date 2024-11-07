namespace SQL_Project_Products
{
    public static class ProductQueres
    {
        public static string Create = "INSERT INTO dbo.[Products](Name,CategoryId,Price) VALUES (@Name,@CategoryId,@Price);";
        public static string GetByUserName = "SELECT * FROM dbo.[Products] WHERE Name = @Name";
        public static string GetAll = "SELECT * FROM Products";
        public static string Delete = "Delete dbo.[Products] WHERE Name = @Name";
        public static string Update = "UPDATE dbo.[Products] SET  Name = @Name , CategoryId = @CategoryId , Price = @Price WHERE Id = @Id";

    }
}
