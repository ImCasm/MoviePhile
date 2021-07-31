using Application.Common.Interfaces.Repository;
using Domain.Entities;
using Moq;
using System.Threading.Tasks;

namespace Tests.UnitTests.Payments.Mocks
{
    public class PaymentsRepositoryMock : Mock<IPaymentsRepository>
    {
        public PaymentsRepositoryMock()
        {
            SetupCreatePayment();
        }

        public void SetupCreatePayment()
        {
            Setup(x => x.CreatePayment(It.IsAny<Payment>()))
            .Returns(Task.FromResult(1023));
        }
    }
}
