using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using repository;

namespace Service
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            this._repository = repository;
        }

        public Order AddOrder(Order order)
        {
            return this._repository.AddOrder(order);
        }
    }
}
