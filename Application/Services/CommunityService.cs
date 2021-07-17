using Application.Common.Interfaces.Repository;
using Application.Common.Interfaces.Services;
using Domain.Entities;
using System.Collections.Generic;
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
      
        public async Task<IEnumerable<Community>> GetInformationCommunity(int IdCommunity)
        {
            return await _repository.GetInformationCommunity(IdCommunity);
        }
        /// <summary>
        /// Permite registrar una comunidad por medio del repositorio de datos
        /// </summary>
        /// <param Community="community">Comunidad que se va a guardar</param>
        /// <returns>Retorna un true guardando la comunidad con exito</returns>
        public async Task<bool> SetCommunity(Community community)
        {
            if (!await ExistCommunity(community.Name))
            {
                return false;
            }
            else
            {
                return await _repository.SetCommunity(community);
            }
        }

        /// <summary>
        /// Permite buscar si la comunidad existe en la base de datos 
        /// </summary>
        /// <param string="name">Nombre la comunidad</param>
        /// <returns>Retorna un false si la comunidad no existe</returns>
        public async Task<bool> ExistCommunity(string name)
        {
            return await _repository.GetCommunityByname(name) == null;
        }
    }
}
