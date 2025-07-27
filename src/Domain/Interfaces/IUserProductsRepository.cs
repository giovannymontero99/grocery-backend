using GroceryBackend.src.Domain.Entities;

namespace GroceryBackend.src.Domain.Interfaces
{
    public interface IUserProductsRepository
    {
        Task<List<UserProduct>> GetAllByUserSync(int IdUser);
        Task AddUserProductAsync(UserProduct userProduct);
        Task DeleteByKeyAsync(int IdKey);
        Task AddSave(int IdKey);
    }
}
