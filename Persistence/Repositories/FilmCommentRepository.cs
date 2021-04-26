using Application.Common.Interfaces.Repository;
using Application.Common.Interfaces.Services;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class FilmCommentRepository : Repository<FilmComment>, IFilmCommentRepository
    {
        private readonly MoviePhileDbContext _context;
        public FilmCommentRepository(MoviePhileDbContext context) : base(context)
        {
            _context = context;
        }



        public async Task<bool> SetFilmComment(FilmComment filmComment)
        {
            await _context.FilmComments.AddAsync(filmComment);

            //otra forma de hacer las cosas
            //base.Insert(filmComment);
            return await _context.SaveChangesAsync() > 0;


        }
        public async Task<IEnumerable<FilmComment>> GetAllComment(int IdFilm)
        {
            return await _context.FilmComments
                .Include(fc => fc.Film)
                .Include(fc=>fc.User)
                .ToListAsync();


        }
    }
}
