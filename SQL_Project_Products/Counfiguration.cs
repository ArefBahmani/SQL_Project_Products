namespace SQL_Project_Products
{
    public static class Counfiguration
    {
        public static string ConnctionString { get; set; }
        static Counfiguration()
        {
            ConnctionString = "Data Source = DESKTOP-J6I42F2\\SQLEXPRESS ;Initial Catalog = ShopDb ;User id = SA ;Password = 123456;TrustServerCertificate = True;";
        }

    }
}
