using GroceryBackend.src.Application.DTO;
using GroceryBackend.src.Domain.Entities;
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

        public async Task AddSave(int IdKey)
        {
            await _userProductsRepository.AddSave(IdKey);
        }

        public async Task AddUserProductAsync(UserProductDto userProductDto)
        {
            var userProduct = new UserProduct() {
                ProductId = userProductDto.IdProduct,
                UserId = userProductDto.IdUser
            };
            await _userProductsRepository.AddUserProductAsync(userProduct);

        }

        public async Task DeleteByKeyAsync(int IdKey)
        {
            await _userProductsRepository.DeleteByKeyAsync(IdKey);
        }

        public async Task<List<UserProductDto>> GetAllByUserSync(int IdUser)
        {


            var userProducts = await _userProductsRepository.GetAllByUserSync(IdUser);
            return userProducts.Select( up => new UserProductDto { 
                AddedAt = up.AddedAt,
                IdProduct = up.ProductId,
                Quantity = up.Quantity,
                UserProductId = up.UserProductId,
                IsSaved = up.IsSaved,
                Products = new ProductsDto { 
                    Category = up.Products.Category,
                    CreatedAt = up.Products.CreatedAt,
                    Description = up.Products.Description,
                    Id = up.ProductId,
                    IsActive = up.Products.IsActive,
                    Name = up.Products.Name,
                    Price = up.Products.Price
                }
            }).ToList();
        }
    }
}
