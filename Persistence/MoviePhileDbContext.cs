using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Persistence
{
    public class MoviePhileDbContext : IdentityDbContext<User>
    {

        public DbSet<Film> Films { get; set; }
        public DbSet<FilmComment> FilmComments { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<PublicationComment> PublicationComments { get; set; }
        public DbSet<Advertising> Advertisings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<CommunityUser> CommunityUsers { get; set; }

        public MoviePhileDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Film>().Property(f => f.Id).ValueGeneratedNever();
            builder.Entity<Genre>().Property(g => g.Id).ValueGeneratedNever();

            //Relaciona las  clases hijas con la clase padre para mapear con la DB
            builder.Entity<Movie>().HasBaseType<Film>();
            builder.Entity<TvShow>().HasBaseType<Film>();

            builder.Entity<CommunityUser>().HasKey(pk => new { pk.CommunityId, pk.UserId });

            // Conversión de tipo enum a string y viceversa para comunicación con la DB
            builder.Entity<FilmComment>()
            .Property(filmComment => filmComment.CommentType)
            .HasConversion(
                commentTypeEnum => commentTypeEnum.ToString(),
                commentTypeString => (CommentType)Enum.Parse(typeof(CommentType), commentTypeString)
            );
        }
    }
}
