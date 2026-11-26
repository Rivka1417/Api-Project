using Entity;

namespace repository
{
    public interface IOrderRepository
    {
        Order AddOrder(Order order);
    }
}