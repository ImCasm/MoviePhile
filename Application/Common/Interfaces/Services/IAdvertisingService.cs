using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services
{
    public interface IAdvertisingService
    {
        Task<int> CreateAdvertising(Advertising advertising);
        Task<bool> AdvertisingExist(int id);
    }
}
