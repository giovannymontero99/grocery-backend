using GroceryBackend.src.Application.DTO;
using GroceryBackend.src.Domain.Interfaces;

namespace GroceryBackend.src.Application.Services
{
    public class ProductService: IProductService
    {
        readonly private IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductsDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select( product => new ProductsDto 
            {
                Category = product.Category,
                CreatedAt = product.CreatedAt,
                Description = product.Description,
                Id = product.ProductId,
                IsActive = product.IsActive,
                Name = product.Name,
                Price = product.Price,
            }).ToList();
        }
    }
}
