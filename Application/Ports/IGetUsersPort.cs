using users_api.Application.DTOs;

namespace users_api.Application.Ports
{
    public interface IGetUsersPort
    {
        IEnumerable<UserDTO> GetUsers();
    }
}
