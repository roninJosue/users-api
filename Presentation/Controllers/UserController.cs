using Microsoft.AspNetCore.Mvc;
using users_api.Application.DTOs;
using users_api.Application.Ports;

namespace users_api.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IGetUsersPort _getUsers;
        private readonly ISaveUserPort _saveUser;
        
        public UserController(IGetUsersPort getUsers, ISaveUserPort saveUser)
        {
            _getUsers = getUsers;
            _saveUser = saveUser;
        }
        
        // GET api/user
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _getUsers.GetUsers();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult SaveUser([FromBody] UserDTO userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdUser = _saveUser.SaveUser(userDto);

            return CreatedAtAction(nameof(GetUsers), new
            {
                id = createdUser.Id
            }, createdUser);
        }
    }
}
