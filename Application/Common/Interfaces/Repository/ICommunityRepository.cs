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
    }
}
