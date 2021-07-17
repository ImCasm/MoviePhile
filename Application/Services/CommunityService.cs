using Application.Common.Interfaces.Auth;
using Application.Common.Interfaces.Repository;
using Application.Common.Interfaces.Services;
using Application.Dto;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CommunityService : ICommunityService
    {
        private readonly ICommunityRepository _repository;
        private readonly IUserRepository _userRepository;

        public CommunityService(ICommunityRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
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


        //------------------

        public async Task<bool> UserExistInCommunity(CommunityUser communityUser)
        {
            return await _repository.UserExistInCommunity(communityUser) == null;
        }

        public async Task<bool> CommunityExist(int communityId)
        {
            
            return await _repository.GetCommunityById(communityId) == null;
        }


        public async Task<bool> SetRegisterUser(CommunityUserDto communityUserDto)
        {
            var newRegisterUser = new CommunityUser() { CommunityId = communityUserDto.CommunityId, UserId = communityUserDto.UserId };
            if (!await UserExistInCommunity(newRegisterUser))
            {
                return false;
            }else if (!await _userRepository.UserIdExists(newRegisterUser.UserId))
            {
                return false;
            }/*else if(!await CommunityExist(newRegisterUser.CommunityId)){
                
                return false;
            }*/
            else
            {
              return await _repository.SetRegisterUser(newRegisterUser);
            }
        }

        public async Task<bool> SetDeleteUser(CommunityUserDto communityUserDto)
        {
            return await _repository.SetDeleteUser(new CommunityUser() { CommunityId = communityUserDto.CommunityId, UserId = communityUserDto.UserId });
        }
    }
}
