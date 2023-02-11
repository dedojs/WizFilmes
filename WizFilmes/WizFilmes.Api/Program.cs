using Microsoft.EntityFrameworkCore;
using WizFilmes.Infra.Data.Context;
using WizFilmes.Infra.Data.Repository.DirectorRepository;
using WizFilmes.Infra.Data.Repository.ReviewRepository;
using WizFilmes.Infra.Data.Repository.UserRepository;
using WizFilmes.Infra.Services.DirectorServices;
using WizFilmes.Infra.Services.LoginServices;
using WizFilmes.Infra.Services.ReviewServices;
using WizFilmes.Infra.Services.UserServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Adicionando Context
builder.Services.AddDbContext<AppDbContext>();
//builder.Services.AddDbContext<WizFilmsContext>(opts => opts.UseSqlServer(@"Server=127.0.0.1;Database=WizFilmes;User=sa;Password=Password12!;TrustServerCertificate=True"));

// Add Repositorys
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IDirectorRepository, DirectorRepository>();


// Add Services
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IDirectorService, DirectorService>();



// Add Mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


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
