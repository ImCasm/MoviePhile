using Application.Common.Interfaces.Repository;
using Application.Dto;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CommunityRepository : Repository<Community>, ICommunityRepository
    {
        private readonly MoviePhileDbContext _context;

        public CommunityRepository(MoviePhileDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Community>> GetCommunities()
        {
            return await _context.Communities
                .Include(c => c.Publications)
                .ThenInclude(p => p.Comments)
                .ThenInclude(c => c.User)
                .Include(c => c.Users)
                .ThenInclude(u => u.Community)
                .Include(c => c.Users)
                .ThenInclude(u => u.User)
                .ToListAsync();
        }

        public async Task<Community> GetCommunityByname(string name)
        {
            return (await _context.Communities
                .Include(c => c.Publications)
                .ThenInclude(p => p.Comments)
                .ThenInclude(c => c.User)
                .Include(c => c.Users)
                .ThenInclude(u => u.Community)
                .Include(c => c.Users)
                .ThenInclude(u => u.User)
                .FirstOrDefaultAsync(f => f.Name == name));

        }

        public async Task<IEnumerable<Community>> GetCommunitiesName(string name)
        {

            return await _context.Communities
                .Include(c => c.Publications)
                .ThenInclude(p => p.Comments)
                .ThenInclude(c => c.User)
                .Include(c => c.Users)
                .ThenInclude(u => u.Community)
                .Include(c => c.Users)
                .ThenInclude(u => u.User)
                .Where(f => f.Name.ToUpper()
                    .Contains(name.ToUpper()) 
                )
                .ToListAsync();
        }

        public async Task<Community> GetCommunityByName(string name)
        {
            return (await _context.Communities
                .FirstOrDefaultAsync(f => f.Name == name));
        }

        /// <summary>
        /// Permite guardar una comunidad por medio del repositorio de datos
        /// </summary>
        /// <param Community="community">Comunidad que se va a guardar</param>
        /// <returns> Si guardo la comunidad con exito o no </returns>
        public async Task<bool> SetCommunity(Community community)
        {
            await _context.Communities.AddAsync(community);
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<Community> GetCommunityById(int communityId)
        {
            return (await _context.Communities
                .FirstOrDefaultAsync(f => f.Id == communityId));
        }

        public async Task<bool> SetRegisterUser(CommunityUser communityUser)
        {
            await _context.CommunityUsers.AddAsync(communityUser);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> SetDeleteUser(CommunityUser communityUser)
        {

            try
            {
                var query = (from y in _context.CommunityUsers where y.CommunityId == communityUser.CommunityId where y.CommunityId == communityUser.CommunityId select communityUser).First();

                _context.Attach(query);
                //DeleteObject is used to delete the entity object.  
                _context.Remove(query);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception )
            {
                return false;
            }

        }

        public async Task<CommunityUser> UserExistInCommunity(CommunityUser communityUser)
        {
            return (await _context.CommunityUsers.FirstOrDefaultAsync(f => f.CommunityId == communityUser.CommunityId && f.UserId == communityUser.UserId));
        }

        public async Task<IEnumerable<Community>> GetInformationCommunity(int IdCommunity)
        {
            return await _context.Communities
                .Include(c => c.Publications)
                .ThenInclude(p => p.Comments)
                .ThenInclude(c => c.User)
                .Include(c => c.Users)
                .ThenInclude(u => u.Community)
                .Include(c => c.Users)
                .ThenInclude(u => u.User)
                .Where(f => f.Id == IdCommunity)
                .ToListAsync();
        }

        public async Task<Community> GetInformationCommunityid(int IdCommunity)
        {
            return (await _context.Communities
                .Include(c => c.Publications)
                .ThenInclude(p => p.Comments)
                .ThenInclude(c => c.User)
                .Include(c => c.Users)
                .ThenInclude(u => u.Community)
                .Include(c => c.Users)
                .ThenInclude(u => u.User)
                .FirstOrDefaultAsync(f => f.Id == IdCommunity));

        }
    }
}
