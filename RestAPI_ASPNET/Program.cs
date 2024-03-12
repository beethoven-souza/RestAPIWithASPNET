using EvolveDb;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using RestAPI_ASPNET.Business;
using RestAPI_ASPNET.Business.Implementations;
using RestAPI_ASPNET.Hypermedia.Enricher;
using RestAPI_ASPNET.Hypermedia.Filters;
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


//============================================================================================================================
//Content Negociation
//Usando o Software PostMan, pare visualizar em XML, na aba Headers informar a Key = Accept; e; Value = application/xml
//e no final desse trecho de código descomentar o .AddXmlSerializerFormatters();
//No navegador tambem ira retornar o arquivo xml
builder.Services.AddMvc(Options =>
{
	Options.RespectBrowserAcceptHeader = true;

	Options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
	Options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
});
//.AddXmlSerializerFormatters();
//============================================================================================================================


var filterOptions = new HyperMediaFilterOptions();
filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());
filterOptions.ContentResponseEnricherList.Add(new BookEnricher());
builder.Services.AddSingleton(filterOptions);


builder.Services.AddSwaggerGen(c => {
	c.SwaggerDoc("v1",
				new OpenApiInfo
				{
					Title = "Rest API's ASP.NET.",
					Version = "v1",
					Description = "Criação de API REST com ASP.NET.",
					Contact = new OpenApiContact
					{
						Name = "Beethoven",
						Url = new Uri("https://github.com/beethoven-souza")
					}
				});
});

//Injeção de dependencia
builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
builder.Services.AddScoped<IBookBusiness, BookBusinessImplementation>();


builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();

app.UseSwaggerUI(c => {
	c.SwaggerEndpoint("/swagger/v1/swagger.json",
					"Rest API's ASP.NET - v1."); });

var option = new RewriteOptions();
option.AddRedirect("^$","swagger");
app.UseRewriter(option);

app.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");

app.Run();
