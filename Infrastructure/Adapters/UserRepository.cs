using users_api.Application.DTOs;
using users_api.Application.Mappers;
using users_api.Application.Ports;
using users_api.Domain.Entities;
using users_api.Infrastructure.Persistence;

namespace users_api.Infrastructure.Adapters
{
    public class UserRepository: IGetUsersPort, ISaveUserPort
    {
        private readonly DatabaseContext _dbContext;
        private readonly UserMapper _userMapper;

        public UserRepository(DatabaseContext dbContext, UserMapper userMapper)
        {
            _dbContext = dbContext;
            _userMapper = userMapper;
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            var users = _dbContext.Users.ToList();
            return users.Select(user => _userMapper.MapToDTO(user));
        }

        public UserDTO SaveUser(UserDTO userDto)
        {
            var user = _userMapper.MapToEntity(userDto);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return _userMapper.MapToDTO(user);
        }
    }
}
