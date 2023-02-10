using Microsoft.EntityFrameworkCore;
using System.IO;
using WizFilmes.Domain.Models;

namespace WizFilmes.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmActor> FilmsActor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=127.0.0.1;Database=WizFilmes;User=sa;Password=Password12!;TrustServerCertificate=True",
                b => b.MigrationsAssembly("WizFilmes.Api")
            ).UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definindo os relacionamentos

            modelBuilder.Entity<User>()
                .HasMany(r => r.Reviews)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<Film>()
                .HasMany(r => r.Reviews)
                .WithOne(f => f.Film)
                .HasForeignKey(f => f.FilmId);

            modelBuilder.Entity<Director>()
                .HasMany(f => f.Films)
                .WithOne(u => u.Director)
                .HasForeignKey(f => f.DirectorId);

            modelBuilder.Entity<Category>()
                .HasMany(f => f.Films)
                .WithOne(u => u.Category)
                .HasForeignKey(f => f.CategoryId);

            modelBuilder.Entity<FilmActor>()
                .HasKey(af => new { af.FilmId, af.ActorId });

            modelBuilder.Entity<FilmActor>()
                .HasOne(af => af.Actor)
                .WithMany(a => a.Films)
                .HasForeignKey(af => af.FilmId);

            modelBuilder.Entity<FilmActor>()
                .HasOne(af => af.Film)
                .WithMany(f => f.Cast)
                .HasForeignKey(af => af.ActorId);

            // Populando o banco de dados
            modelBuilder.Entity<User>()
                .HasData(
                new User { Id = 1, Name = "Andre", Email = "andre@gmail.com", Password = "123456", ReviewId = 1 },
                new User { Id = 2, Name = "Angélica", Email = "angelica@gmail.com", Password = "123456", ReviewId = 2 }
                );

            modelBuilder.Entity<Category>()
                .HasData(
                new Category { Id = 1, Name = "Aventura" },
                new Category { Id = 2, Name = "Terror" },
                new Category { Id = 3, Name = "Ficção Científica" },
                new Category { Id = 4, Name = "Ação" },
                new Category { Id = 5, Name = "Comédia" }
                );

            modelBuilder.Entity<Film>()
                .HasData(
                new Film { Id = 1, Name = "Indiana Jones e a Caveira de Cristal", Description = "Filme do Indiana", CategoryId = 1, Year = 1980, DirectorId = 1 },
                new Film { Id = 2, Name = "Tomb Raider", Description = "Filme da Lara Croft", CategoryId = 1, Year = 2000, DirectorId = 2 },
                new Film { Id = 3, Name = "Mulher Maravilha", Description = "Filme da DC", CategoryId = 1, Year = 2020, DirectorId = 2 },
                new Film { Id = 4, Name = "ET", Description = "Filme do ET", CategoryId = 3, Year = 1980, DirectorId = 1 },
                new Film { Id = 5, Name = "Maverick", Description = "Filme do avião", CategoryId = 4, Year = 2023, DirectorId = 1 },
                new Film { Id = 6, Name = "Oito Mulheres e um segredo", Description = "Filme dos Ocean", CategoryId = 5, Year = 2018, DirectorId = 2 },
                new Film { Id = 7, Name = "Exorcista", Description = "Filme do capiroto", CategoryId = 2, Year = 1978, DirectorId = 1 }
            );

            modelBuilder.Entity<Director>()
            .HasData(
                new Director { Id = 1, Name = "Steven Spilberg" },
                new Director { Id = 2, Name = "Patty Jenkins" }
                );

            modelBuilder.Entity<Actor>()
                .HasData(
                new Actor { Id = 1, Name = "Harison Ford", Character = "Indiana Jones" },
                new Actor { Id = 2, Name = "Tom Cruise", Character = "Maverick" },
                new Actor { Id = 3, Name = "Tom Hanks", Character = " Capitão John H. Miller " },
                new Actor { Id = 4, Name = "Gal Gadot", Character = "Mulher Maravilha" },
                new Actor { Id = 5, Name = "Angelina Jolie", Character = "Lara Croft" },
                new Actor { Id = 6, Name = "Sandra Bullock", Character = "Debbie Ocean" }
                );

            modelBuilder.Entity<FilmActor>()
                .HasData(
                new FilmActor { FilmId = 1, ActorId = 1 },
                new FilmActor { FilmId = 2, ActorId = 5 },
                new FilmActor { FilmId = 3, ActorId = 4 },
                new FilmActor { FilmId = 4, ActorId = 3 },
                new FilmActor { FilmId = 5, ActorId = 2 },
                new FilmActor { FilmId = 6, ActorId = 6 }
                );

            modelBuilder.Entity<Review>()
                .HasData(
                new Review { Id = 1, Description = "Resenha sobre o filme Indiana Jones", Rating = 5, UserId = 1, FilmId = 1 },
                new Review { Id = 2, Description = "Resenha sobre o filme Tomb Rider", Rating = 4, UserId = 2, FilmId = 2 }
                );

        }

    }
}
