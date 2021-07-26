using Application.Common.Interfaces.Repository;
using Domain.Common.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class AdvertisingRepository : Repository<Advertising>, IAdvertisingRepository
    {
        private readonly MoviePhileDbContext _context;

        public AdvertisingRepository(MoviePhileDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> CreateAdvertising(Advertising advertising)
        {
            var result = await Insert(advertising);
            return result.Id;
        }

        public async Task<Advertising> GetAdvertisingById(int id)
        {
            return await GetById(id);
        }
    }
}
