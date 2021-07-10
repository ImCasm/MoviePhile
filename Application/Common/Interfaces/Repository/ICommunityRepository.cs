using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repository
{
    public interface ICommunityRepository : IRepository<Community>
    {
        /// <summary>
        /// Obtiene la lista de comunidades desde la base de datos
        /// </summary>
        /// <returns>Lista de comunidades</returns>
        Task<IEnumerable<Community>> GetCommunities();
        Task<Community> GetCommunityByname(string name);

        Task<IEnumerable<Community>> GetCommunitiesName(string name);

        /// <summary>
        /// Se guarda la comunidad en la base de datos 
        /// </summary>
        /// <returns>true o false</returns>
        Task<bool> SetCommunity(Community community);

        /// <summary>
        /// Se obtiene que comunidades existen  
        /// </summary>
        /// <returns>Una comunidad</returns>
        Task<Community> GetCommunityByName(string name);
     

    }
}
