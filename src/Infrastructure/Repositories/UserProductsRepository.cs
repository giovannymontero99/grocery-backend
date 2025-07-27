using GroceryBackend.src.Domain.Entities;
using GroceryBackend.src.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GroceryBackend.src.Infrastructure.Repositories
{
    public class UserProductsRepository : IUserProductsRepository
    {
        readonly private AppDbContext _appDbContext;
        public UserProductsRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<List<UserProduct>> GetAllByUserSync(int IdUser)
        {
            return await _appDbContext.UserProduct
                .Where(up => up.User.UserId == IdUser)
                .Include(up => up.Products)
                .ToListAsync();
        }

        public async Task AddUserProductAsync(UserProduct userProduct) 
        {
            await _appDbContext.UserProduct.AddAsync(userProduct);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteByKeyAsync(int IdKey)
        {
            var userProduct = await _appDbContext.UserProduct.FindAsync(IdKey);
            if (userProduct != null) {
                _appDbContext.UserProduct.Remove(userProduct);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task AddSave(UserProduct userProduct)
        {
            if (userProduct != null)
            {
                UserProduct updateduserProduct = userProduct;
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
