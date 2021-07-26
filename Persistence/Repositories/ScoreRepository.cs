using Application.Common.Interfaces.Repository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ScoreRepository : Repository<FilmComment>, IScoreRepository
    {
        private readonly MoviePhileDbContext _context;
        public ScoreRepository(MoviePhileDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<bool> setScore(Score score)
        {
            await _context.Scores.AddAsync(score);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
