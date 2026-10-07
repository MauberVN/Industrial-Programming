namespace ACM.BL.Repositories
{
    public class OrderItemRepository
    {
        public OrderItem Retrieve(int orderItemId)
        {
            return new OrderItem(orderItemId);
        }

        public bool Save(OrderItem orderItem)
        {
            return true;
        }
    }
}