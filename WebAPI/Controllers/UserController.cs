using BusinessLayer.Implemantation;
using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController()
    {
        _userService = new UserService();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<UserModel>> GetById(int id)
    {
        var user = await _userService.GetUserById(id);
        return Ok(user);
    }

    [HttpGet("{letter}")]
    public async Task<ActionResult<List<UserModel>>> GetStartsWith(string letter)
    {
        var users = await _userService.GetUserNamesStartsWith(letter);
        if (users.Count > 0)
            return Ok(users);
        return NotFound();
    }

    [HttpGet]
    public async Task<ActionResult<List<UserModel>>> GetAll()
    {
        var users = await _userService.AllUsers();
        if (users.Count > 0)
            return Ok(users);
        return NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _userService.DeleteUser(id);
        if (response > 0)
            return Ok();
        return BadRequest();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserModel user)
    {
        var response = await _userService.CreateUser(user);
        if (response > 0)
            return Ok();
        return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UserModel user)
    {
        var response = await _userService.UpdateUser(user);
        if (response > 0)
            return Ok();
        return BadRequest();
    }
}