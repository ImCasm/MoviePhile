using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repository
{
    public interface IAdvertisingRepository
    {
        Task<int> CreateAdvertising(Advertising advertising);
        Task<Advertising> GetAdvertisingById(int id);
    }
}
