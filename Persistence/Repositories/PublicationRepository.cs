using Application.Common.Interfaces.Repository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class PublicationRepository : Repository<FilmComment>, IPublicationRepository
    {
        private readonly MoviePhileDbContext _context;
        public PublicationRepository(MoviePhileDbContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Método que ingresa una publicación a la base de datos
        /// </summary>
        /// <param name="publication"></param>
        /// <returns></returns>
        public async Task<bool> SetPublication(Publication publication)
        {
            await _context.Publications.AddAsync(publication);

            //otra forma de hacer las cosas
            return await _context.SaveChangesAsync() > 0;

        }
    }
}
