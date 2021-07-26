using Application.Common.Interfaces.Repository;
using Domain.Entities;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly MoviePhileDbContext _context;

        public PaymentsRepository(MoviePhileDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreatePayment(Payment payment)
        {
            var result = await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }
    }
}
