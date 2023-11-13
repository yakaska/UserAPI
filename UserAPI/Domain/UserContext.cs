using Microsoft.EntityFrameworkCore;
using UserAPI.Domain.Entities;

namespace UserAPI.Domain;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions options) : base(options) {}

    public DbSet<User?> Users { get; set; }
}