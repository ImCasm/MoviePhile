using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services
{
    public interface IPaymentsService
    {
        Task<int> CreatePayment(Payment payment);
    }
}
