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

    }
}
