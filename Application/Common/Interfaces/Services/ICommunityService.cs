using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services
{
    public interface ICommunityService
    {
        Task<IEnumerable<Community>> GetCommunities();
    }
}
