using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repository
{
    public interface IPaymentsRepository
    {
        Task<int> CreatePayment(Payment payment);
    }
}
