using Application.Common.Interfaces.Repository;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {

        private readonly MoviePhileDbContext _context;

        public GenreRepository(MoviePhileDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<Genre>> GetGenres()
        {
            return (await GetAll()).ToList();
        }

        public async Task<Genre> InsertGenre(Genre genre)
        {
            return await Insert(genre);
        }
    }
}
