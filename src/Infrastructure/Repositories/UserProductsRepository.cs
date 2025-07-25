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
            return await _appDbContext.UserProduct.Where(up => up.User.UserId == IdUser).ToListAsync();
        }



    }
}
