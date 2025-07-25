using GroceryBackend.src.Application.DTO;

namespace GroceryBackend.src.Domain.Interfaces
{
    public interface IUserProductsService
    {
        Task<List<UserProductDto>> GetAllByUserSync(int IdUser);
    }
}
