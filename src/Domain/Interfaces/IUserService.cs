using GroceryBackend.src.Application.DTO;

namespace GroceryBackend.src.Domain.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(int id);
        Task<List<UserDto>> GetAllUsersAsync();
        Task CreateUserAsync(UserDto userDto);

        Task<UserDto?> GetUserByName(string username);
    }
}
