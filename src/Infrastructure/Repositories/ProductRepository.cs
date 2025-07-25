using GroceryBackend.src.Domain.Entities;
using GroceryBackend.src.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GroceryBackend.src.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        readonly private AppDbContext _context;
        public ProductRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<List<Products>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
