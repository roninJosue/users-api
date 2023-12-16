using users_api.Application.DTOs;
using users_api.Domain.Entities;

namespace users_api.Application.Mappers
{
    public class UserMapper
    {
        public UserDTO MapToDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Age = user.Age,
                CreatedAt = user.CreatedAt
            };
        }

        public User MapToEntity(UserDTO userDto)
        {
            return new User
            {
                Id = userDto.Id,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Age = userDto.Age,
                CreatedAt = userDto.CreatedAt
            };
        }
    }
}
