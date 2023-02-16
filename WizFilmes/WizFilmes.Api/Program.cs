using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WizFilmes.Infra.Data.Context;
using WizFilmes.Infra.Data.Repository.ActorRepository;
using WizFilmes.Infra.Data.Repository.DirectorRepository;
using WizFilmes.Infra.Data.Repository.FilmActorRepository;
using WizFilmes.Infra.Data.Repository.FilmRepositorys;
using WizFilmes.Infra.Data.Repository.ReviewRepository;
using WizFilmes.Infra.Data.Repository.UserRepository;
using WizFilmes.Infra.Services.ActorServices;
using WizFilmes.Infra.Services.CategoryServices;
using WizFilmes.Infra.Services.DirectorServices;
using WizFilmes.Infra.Services.FilmActorServices;
using WizFilmes.Infra.Services.FilmServices;
using WizFilmes.Infra.Services.LoginServices;
using WizFilmes.Infra.Services.ReviewServices;
using WizFilmes.Infra.Services.UserServices;
using WizFilmes.Infra.Utils;

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
builder.Services.AddScoped<IActorRepository, ActorRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IFilmRepository, FilmRepository>();
builder.Services.AddScoped<IFilmActorRepository, FilmActorRepository>();


// Add Services
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IDirectorService, DirectorService>();
builder.Services.AddScoped<IActorService, ActorService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IFilmService, FilmService>();
builder.Services.AddScoped<IFilmActorService, FilmActorService>();


// Add Mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Adicionando Autenticação e Autorização
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})

.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenConstants.Secret))
    };
});


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

// Adicionar uso de autenticação
app.UseAuthentication();

// Adicionar uso de autorização
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
