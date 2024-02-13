using EvolveDb;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestAPI_ASPNET.Business;
using RestAPI_ASPNET.Business.Implementations;
using RestAPI_ASPNET.Model.Context;
using RestAPI_ASPNET.Repository;
using RestAPI_ASPNET.Repository.Generic;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();

//Conexão Banco de dados
//var conection = builder.Configuration["ConnectionStringsDefaultConnection"];
//builder.Services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(conection));

builder.Services.AddDbContext<SqlServerContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

if(builder.Environment.IsDevelopment())
{
	var conection = builder.Configuration.GetConnectionString("DefaultConnection");
    MigrationDataBase(conection);    
}

void MigrationDataBase(string conection)
{
	try
	{
		var evolveConenction = new SqlConnection(conection);
		var evolve = new Evolve(evolveConenction, Log.Information)
		{
			Locations = new List<string> { "db/migrations", "db/dataset" },
			IsEraseDisabled = true,

		};
		evolve.Migrate();
	}
	catch (Exception ex)
	{
		Log.Error("Database migration failed.", ex);
		throw;
	}
};


//Injeção de dependencia
builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
builder.Services.AddScoped<IBookBusiness, BookBusinessImplementation>();


builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
