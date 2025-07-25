using GroceryBackend.src.Application.DTO;
using GroceryBackend.src.Domain.Interfaces;

namespace GroceryBackend.src.Application.Services
{
    public class UserProductsService : IUserProductsService
    {
        readonly private IUserProductsRepository _userProductsRepository;
        public UserProductsService(IUserProductsRepository userProductsRepository) 
        {
            _userProductsRepository = userProductsRepository;
        }
        public async Task<List<UserProductDto>> GetAllByUserSync(int IdUser)
        {


            var userProducts = await _userProductsRepository.GetAllByUserSync(IdUser);
            return userProducts.Select( up => new UserProductDto { 
                AddedAt = up.AddedAt,
                IdProduct = up.Products.ProductId,
                Quantity = up.Quantity,
                UserProductId = up.UserProductId,
            }).ToList();
        }
    }
}
