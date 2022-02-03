using OracleDapperRepository.Repositories;
using OracleDapperRepository.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

string ConnectionString = builder.Configuration.GetConnectionString("OracleConnection");

// Add services to the container.
builder.Services.AddTransient<ISysmstafRepository>(x => new SysmstafRepository(ConnectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
