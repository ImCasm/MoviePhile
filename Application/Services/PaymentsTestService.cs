using Application.Common.Interfaces.Repository;
using Application.Common.Interfaces.Services;
using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PaymentsTestService : IPaymentsService
    {
        private readonly IPaymentsRepository _paymentsRepository;

        public PaymentsTestService(IPaymentsRepository paymentsRepository)
        {
            _paymentsRepository = paymentsRepository;
        }

        public async Task<int> CreatePayment(Payment payment)
        {
            return await _paymentsRepository.CreatePayment(payment);
        }
    }
}
