using GroceryBackend.src.Domain.Entities;

namespace GroceryBackend.src.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Products>> GetAllAsync();
    }
}
