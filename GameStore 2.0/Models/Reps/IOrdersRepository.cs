
namespace GameStore_2._0.Models.Reps
{
    public interface IOrdersRepository
    {
        void Add(OrderVM order);
        List<OrderVM> GetAll();
        OrderVM GetById(Guid id);
        List<OrderVM> GetByUserId(string id);
    }
}
