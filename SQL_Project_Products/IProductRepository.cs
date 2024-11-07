namespace SQL_Project_Products
{
    public interface IProductRepository
    {
        public void Add(Products product);
        public List<Products> GetAll();
        public Products Get(string productName);
        public void Update(Products product);
        public void Delete(string productName);
    }
}
