using Application.Common.Interfaces.Repository;
using Application.Common.Interfaces.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CommunityService : ICommunityService
    {
        private readonly ICommunityRepository _repository;

        public CommunityService(ICommunityRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Community>> GetCommunities()
        {
            return await _repository.GetCommunities();
        }

        public async Task<Community> GetCommunityByName(string name)
        {
            return await _repository.GetCommunityByname(name);
          
        }

        public async Task<IEnumerable<Community>> GetCommunitiesName(string nameCommunity)
        {
            return await _repository.GetCommunitiesName(nameCommunity);
        }
    }
}
