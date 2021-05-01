using Application.Common.Interfaces.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        private readonly MoviePhileDbContext _context;

        public MovieRepository(MoviePhileDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Movie> GetMovieById(int id)
        {
            return (Movie) (await _context.Films
                .Include(f => f.Genre)
                .Include(f => f.Comments)
                .ThenInclude(c => c.User)
                .FirstOrDefaultAsync(f => f.Id == id));
        }

        public async Task<Movie> InsertMovie(Movie movie)
        {
            movie.Genre = null;
            return await Insert(movie);
        }
    }
}
