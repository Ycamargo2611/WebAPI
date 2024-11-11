using Microsoft.EntityFrameworkCore;
using ShoppingAPI_Viernes2024I.DAL;
using WebAPI.ShoppingAPI_Viernes2024I.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//linea de codigo para configurar conexion a la base de datos
builder.Services.AddDbContext<DataBaseContext>( o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<SeederDB>();

//Contenedor de dependencias (Creando el servicio para poder ser ultizado en el controlador
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddTransient<ICountryService, CountryService>();
builder.Services.AddSingleton<ICountryService, CountryService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

SeederData();

void SeederData() //Así se configura el alimentador de la base de datos desde program
{
    IServiceScopeFactory? scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (IServiceScope? scope = scopedFactory.CreateScope())
    {
        SeederDB? service = scope.ServiceProvider.GetService<SeederDB>();
        service.SeederAsync().Wait();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
