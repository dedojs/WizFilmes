using Microsoft.EntityFrameworkCore;
using WizFilmes.Infra.Data.Context;
using WizFilmes.Infra.Data.Repository.UserRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Adicionando Context
builder.Services.AddDbContext<AppDbContext>();
//builder.Services.AddDbContext<WizFilmsContext>(opts => opts.UseSqlServer(@"Server=127.0.0.1;Database=WizFilmes;User=sa;Password=Password12!;TrustServerCertificate=True"));

builder.Services.AddScoped<IUserRepository, UserRepository>();


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
