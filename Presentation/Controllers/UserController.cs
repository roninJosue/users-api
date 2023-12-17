using Microsoft.AspNetCore.Mvc;
using users_api.Application.DTOs;
using users_api.Application.Interfaces;
using users_api.Application.Ports;

namespace users_api.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IGetUsersPort _getUsers;
        private readonly ISaveUserPort _saveUser;
        private readonly IEmailService _emailService;
        
        public UserController(IGetUsersPort getUsers, ISaveUserPort saveUser, IEmailService emailService)
        {
            _getUsers = getUsers;
            _saveUser = saveUser;
            _emailService = emailService;
        }
        
        // GET api/user
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _getUsers.GetUsers();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> SaveUser([FromBody] UserDTO userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdUser = _saveUser.SaveUser(userDto);

            string userEmail = createdUser.Email;
            string subject = "User created";
            string content = "Welcome to our app";

            await _emailService.SendEmailAsync(userEmail, subject, content);

            return CreatedAtAction(nameof(GetUsers), new
            {
                id = createdUser.Id
            }, createdUser);
        }
    }
}
