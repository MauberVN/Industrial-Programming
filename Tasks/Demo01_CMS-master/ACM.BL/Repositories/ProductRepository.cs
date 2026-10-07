namespace ACM.BL.Repositories
{
    public class ProductRepository
    {
        public Product Retrieve(int productId)
        {
            return new Product(productId);
        }

        public bool Save(Product product)
        {
            return true;
        }
    }
}