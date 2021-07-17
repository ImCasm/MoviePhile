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

        /// <summary>
        /// Permite obtener una comunidad por su nombre
        /// </summary>
        /// <param name="name">Nomrbe de la comunidad</param>
        /// <returns>Información de la comunidad</returns>
        Task<Community> GetCommunityByName(string name);

        /// <summary>
        /// Obtiene una lista de comunidades que coinciden con un nombre
        /// </summary>
        /// <param name="name">Nombre de la comunidad</param>
        /// <returns>Lista de comunidades que coinciden con el nombre buscado</returns>
        Task<IEnumerable<Community>> GetCommunitiesName(string name);

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


        Task<bool> CommunityExist(int communityId);

        ///<summary>
        /// registra un usuario a una comunidad 
        /// </summary>
        /// <returns>true o false</returns>
        Task<bool> SetRegisterUser(CommunityUserDto communityUserDto);

        ///<summary>
        /// registra un usuario a una comunidad 
        /// </summary>
        /// <returns>true o false</returns>
        Task<bool> SetDeleteUser(CommunityUserDto communityUserDto);

        Task<bool> UserExistInCommunity(CommunityUser communityUser);
    }
}
