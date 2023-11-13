using Microsoft.EntityFrameworkCore;
using UserAPI.Domain.Entities;

namespace UserAPI.Domain.Services;

public class UserService : IUserService
{
    private readonly HttpClient _client = new();
    private readonly UserContext _userContext;

    public UserService(UserContext userContext)
    {
        _userContext = userContext;
    }

    public async Task<List<User?>> GetAll()
    {
        return await _userContext.Users.ToListAsync();
    }

    public async ValueTask<User?> GetById(int id)
    {
        var user = await _userContext.Users.FindAsync(id);

        if (user != null) return user;

        // хардкодить плохо!
        var response = await _client.GetAsync($"https://jsonplaceholder.typicode.com/users/{id}");
        response.EnsureSuccessStatusCode();
        user = await response.Content.ReadAsAsync<User>();
        Add(user);

        return await _userContext.Users.FindAsync(id);
    }

    public void Add(User user)
    {
        _userContext.Users.Add(user); // хз как лучше
        _userContext.SaveChanges();
    }
}