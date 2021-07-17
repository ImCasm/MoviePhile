using Application.Dto;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services
{
    public interface ICommunityService
    {
        /// <summary>
        /// Obtiene la lista de comunidades
        /// </summary>
        /// <returns>Lista de comunidades</returns>
        Task<IEnumerable<Community>> GetCommunities();

        Task<Community> GetCommunityByName(string name);

        Task<IEnumerable<Community>> GetCommunitiesName(string nameCommunity);

        public Task<IEnumerable<Community>> GetInformationCommunity(int IdCommunity);
        /// <summary>
        /// Se crea la comunidad en la base de datos 
        /// </summary>
        /// <returns>True si guardo con exito o False que la comunidad ya existe</returns>
        Task<bool> SetCommunity(Community community);

        /// <summary>
        /// Obtiene si la comunidad existe 
        /// </summary>
        /// <returns>True o false</returns>
        Task<bool> ExistCommunity(string name);

    }
}
