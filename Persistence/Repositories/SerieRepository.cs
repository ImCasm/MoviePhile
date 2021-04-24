using Application.Common.Interfaces.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class SerieRepository : Repository<TvShow>, ISerieRepository
    {
        private readonly MoviePhileDbContext _context;

        public SerieRepository(MoviePhileDbContext context) : base (context)
        {
            _context = context;
        }

        public async Task<TvShow> GetSerieById(int id)
        {
            return (TvShow) (await _context.Films
                .Include(f => f.Genre)
                .Include(f => f.Comments)
                .ThenInclude(c => c.User)
                .FirstOrDefaultAsync(f => f.Id == id));
        }

        public async Task<TvShow> InsertSerie(TvShow serie)
        {
            return await Insert(serie);
        }
    }
}
