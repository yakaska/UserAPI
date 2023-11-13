using UserAPI.Domain.Entities;

namespace UserAPI.Domain.Services;

public interface IUserService
{
    Task<List<User?>> GetAll();

    ValueTask<User?> GetById(int id);

    void Add(User user);
}