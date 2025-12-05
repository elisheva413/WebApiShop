using Microsoft.AspNetCore.Mvc;
using Entities;
using System.Collections.Generic;
using Repositeries;
using Service;



namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserPasswordService _userPasswordService;

        public UsersController(IUserService userService, IUserPasswordService userPasswordService)
        {
            _userService = userService;
            _userPasswordService = userPasswordService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            var users = await _userService.GetUsers();
            if (users == null || !users.Any())
                return NoContent();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _userService.GetUserById(id);
            return user != null ? Ok(user) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody] User newUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int passwordScore = _userPasswordService.CheckPassword(newUser.Password);
            if (passwordScore < 2)
                return BadRequest("Password is too weak.");

            var user = await _userService.AddUser(newUser);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> LogIn([FromBody] User existUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userService.LogIn(existUser);
            if (user == null)
                return NotFound("Invalid credentials.");
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User updateUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int passwordScore = _userPasswordService.CheckPassword(updateUser.Password);
            if (passwordScore < 2)
                return BadRequest("Password is too weak.");

            await _userService.UpdateUser(id, updateUser);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Implement delete logic in your service/repository
            // await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}