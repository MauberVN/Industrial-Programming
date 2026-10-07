using System.Collections.Generic;

namespace ACM.BL.Repositories
{
    public class CustomerRepository
    {
        public Customer Retrieve(int customerId)
        {
            return new Customer(customerId);
        }

        public List<Customer> Retrieve()
        {
            return new List<Customer>();
        }

        public bool Save(Customer customer)
        {
            return true;
        }
    }
}