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

        /// <summary>
        /// Permite obtener una comunidad por su nombre en la base de datos
        /// </summary>
        /// <param name="name">Nomrbe de la comunidad a buscar</param>
        /// <returns>Información de la comunidad</returns>
        Task<Community> GetCommunityByname(string name);

        /// <summary>
        /// Obtiene una lista de comunidades de la base de datos que coinciden con un nombre
        /// </summary>
        /// <param name="name">Nombre de la comunidad</param>
        /// <returns>Lista de comunidades que coinciden con el nombre buscado</returns>
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

        ///<summary>
        /// registra un usuario a una comunidad 
        /// </summary>
        /// <returns>true o false</returns>
        Task<bool> SetRegisterUser(CommunityUser communityUser);

        ///<summary>
        /// registra un usuario a una comunidad 
        /// </summary>
        /// <returns>true o false</returns>
        Task<bool> SetDeleteUser(CommunityUser communityUser);


        Task<CommunityUser> UserExistInCommunity(CommunityUser communityUser);



        Task<Community> GetCommunityById(int communityId);
    }
}
