using Application.Common.Interfaces.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<FilmComment>> GetAllComment(int IdFilm)
        {
            return await _context.FilmComments
                .Include(c=> c.User)
                .ToListAsync();
        }
    }
}
