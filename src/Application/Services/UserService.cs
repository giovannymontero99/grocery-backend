using GroceryBackend.src.Application.DTO;
using GroceryBackend.src.Domain.Entities;
using GroceryBackend.src.Domain.Interfaces;

namespace GroceryBackend.src.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUserAsync(UserDto userDto)
        {
            // Transform the password in a Hash password
            var passwordHashed = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            // Build the new register for store in DB
            var user = new User
            {
                UserName = userDto.Name,
                Email = userDto.Email,
                PasswordHash = passwordHashed,
                FullName = userDto.FullName
            };
            // Add the register in DB
            await _userRepository.AddAsync(user);
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            List<User> users = new();
            users = await _userRepository.GetAllAsync();
            return users.Select(u => new UserDto
            {
                Id = u.UserId,
                Name = u.UserName,
                Email = u.Email
            }).ToList();
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            UserDto userDto = new UserDto();
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null) 
            { 
                userDto = new UserDto
                {
                    Id = user.UserId,
                    Name = user.UserName,
                    Email = user.Email,
                    FullName = user.FullName
                };
            }
            return userDto;
        }

        public async Task<UserDto?> GetUserByName(string username) 
        {
            var user = await _userRepository.GetUserByName(username);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.UserId,
                Email = user.Email,
                Name = user.UserName,
                numberPhone = user.Phone,
                Password = user.PasswordHash
            };
        }
    }
}
