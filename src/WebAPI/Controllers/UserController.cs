using GroceryBackend.src.Application.DTO;
using GroceryBackend.src.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GroceryBackend.src.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/profile/")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        // Services for products
        private readonly IProductService _productService;
        private readonly IUserProductsService _userProductsService;

        public UserController(
            IUserService userService,
            IProductService productService,
            IUserProductsService userProductsService
            )
        {
            _userService = userService;
            _productService = productService;
            _userProductsService = userProductsService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Profile()
        {
            try
            {
                // Take the id user from token
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize]
        [HttpGet("products")]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            try
            {
                // Take all the products available
                var products = await _productService.GetAllProductsAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("favorite_products")]
        public async Task<IActionResult> GetFavoriteProducts() 
        {
            try
            {
                // Collector for favorites products
                var dtoResponse = new List<UserProductDto>();

                // Take the id user from token
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId == null) return Ok(dtoResponse);
                dtoResponse = await _userProductsService.GetAllByUserSync( int.Parse(userId));
                return Ok(dtoResponse);
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }
    }
}
