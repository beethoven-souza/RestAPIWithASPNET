using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestAPI_ASPNET.Model.Context;
using RestAPI_ASPNET.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();

//Conexão Banco de dados
//var conection = builder.Configuration["ConnectionStringsDefaultConnection"];
//builder.Services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(conection));

builder.Services.AddDbContext<SqlServerContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Injeção de dependencia
builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
