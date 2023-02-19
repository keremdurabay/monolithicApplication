using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService UserService;
        public UserController()
        {
            this.UserService = new UserService();
        }

        [HttpGet("{id}")]
        
        public IActionResult Get(int id)
        {
            User user =  this.UserService.GetUserById(id);
            if(user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{letter}")]
       
        public IActionResult Get(string letter)
        {
            List<User> users =  this.UserService.GetUserNamesStartsWith(letter);
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
        public IActionResult Get()
        {
            var users = this.UserService.AllUsers();
            if(users.Count> 0)
            {
                return Ok(users);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            var response = this.UserService.CreateUser(user);
            if (response)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] User user)
        {
            var response = this.UserService.UpdateUser(user);
            if (response)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = this.UserService.DeleteUser(id);
            if (response)
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
