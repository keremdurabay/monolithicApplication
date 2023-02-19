﻿using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService UserService;
        public UserController()
        {
            this.UserService = new UserService();
        }

        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetById(int id)
        {
            User user =  await this.UserService.GetUserById(id);
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
       
        public async  Task<IActionResult> GetStartsWith(string letter)
        {
            List<User> users =  await this.UserService.GetUserNamesStartsWith(letter);
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
        public async Task<IActionResult> GetAll()
        {
            var users = await this.UserService.AllUsers();
            if(users.Count > 0)
            {
                return Ok(users);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            var response = await this.UserService.CreateUser(user);
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
        public async Task<IActionResult> Update([FromBody] User user)
        {
            var response = await this.UserService.UpdateUser(user);
            if (response > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await this.UserService.DeleteUser(id);
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
