using GroceryBackend.src.Application.DTO;

namespace GroceryBackend.src.Domain.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductsDto>> GetAllProductsAsync();
    }
}
