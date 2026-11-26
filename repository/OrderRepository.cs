using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using repository.Entity;

namespace repository
{
    public class OrderRepository : IOrderRepository
    {
        MyStoreContext _dbContext;

        public OrderRepository(MyStoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Order AddOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return order;
        }
    }
}
