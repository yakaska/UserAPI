using Microsoft.EntityFrameworkCore;
using UserAPI.Domain;
using UserAPI.Domain.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UserContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("user_db"));
    options.UseSnakeCaseNamingConvention();
});

builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();