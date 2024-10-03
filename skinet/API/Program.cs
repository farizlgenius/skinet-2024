using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(opt =>
{
  opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//All Above this line is Service : Service is thing that we inject to software
var app = builder.Build();
//All Below this line is Middleware


// Configure the HTTP request pipeline.

app.MapControllers();

app.Run();
