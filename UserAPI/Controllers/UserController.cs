using Microsoft.AspNetCore.Mvc;
using UserAPI.Domain.Entities;
using UserAPI.Domain.Services;

namespace UserAPI.Controllers;

[Route("api/user")]
[Controller]
public class UserController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<List<User?>> GetUsers()
    {
        return await _userService.GetAll();
    }

    [HttpGet("{id:int}")]
    public async Task<User?> GetUserById(int id)
    {
        return await _userService.GetById(id);
    }
}