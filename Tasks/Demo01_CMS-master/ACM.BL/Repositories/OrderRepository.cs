namespace ACM.BL.Repositories
{
    public class OrderRepository
    {
        public Order Retrieve(int orderId)
        {
            return new Order(orderId);
        }

        public bool Save(Order order)
        {
            return true;
        }
    }
}