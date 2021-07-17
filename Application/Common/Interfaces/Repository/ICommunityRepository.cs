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

        public Task<IEnumerable<Community>> GetCommunitiesName(string name);

        /// <summary>
        /// Se guarda la comunidad en la base de datos 
        /// </summary>
        /// <returns>true o false</returns>
        Task<bool> SetCommunity(Community community);

        /// <summary>
        /// Se obtiene que comunidades existen  
        /// </summary>
        /// <returns>Una comunidad</returns>
        public Task<Community> GetCommunityByName(string name);

        /// <summary>
        /// Permite buscar obtener la informacion de las comunidades registradas
        /// </summary>
        /// <param Id="IdcCommunity">Con este id se puede obtener la comunidad</param>
        /// <returns>Retorna la comunidad que esta registrada</returns>
        public Task<IEnumerable<Community>> GetInformationCommunity(int IdCommunity);
       
    }
}
