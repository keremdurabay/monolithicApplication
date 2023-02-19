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
        public User Get(int id)
        {
            return this.UserService.GetUserById(id);
        }

        [HttpGet]
        public List<User> Get()
        {
            return this.UserService.AllUsers();
        }

        [HttpPost]
        public bool Post([FromBody] User user) { 
            return this.UserService.CreateUser(user);
        }

        [HttpPut]
        public bool Put([FromBody] User user)
        {
            return this.UserService.UpdateUser(user);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return this.UserService.DeleteUser(id);
        }


    }
}
