using BusinessLayer.Implemantation;
using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController()
        {
            this._userService = new UserService();
        }

        [HttpGet("{id:int}")]
        
        public async Task<ActionResult<UserModel>> GetById(int id)
        {
            var user =  await this._userService.GetUserById(id);
            return Ok(user);
        }

        [HttpGet("{letter}")]
       
        public async  Task<ActionResult<List<UserModel>>> GetStartsWith(string letter)
        {
            var users =  await this._userService.GetUserNamesStartsWith(letter);
            if(users.Count> 0)
            {
                return Ok(users);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAll()
        {
            var users = await this._userService.AllUsers();
            if(users.Count > 0)
            {
                return Ok(users);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await this._userService.DeleteUser(id);
            if (response > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserModel user)
        {
            var response = await this._userService.CreateUser(user);
            if (response > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserModel user)
        {
            var response = await this._userService.UpdateUser(user);
            if (response > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        


    }
}
