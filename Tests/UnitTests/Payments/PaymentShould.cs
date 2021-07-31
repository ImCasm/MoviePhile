using Application.Common.Interfaces.Services;
using Application.Services;
using Domain.Entities;
using System;
using Tests.UnitTests.Payments.Mocks;
using Xunit;

namespace Tests.UnitTests.Payments
{
    public class PaymentShould
    {
        private readonly PaymentsRepositoryMock _paymentsRepository;
        private readonly IPaymentsService _paymentService;

        public PaymentShould()
        {
            _paymentsRepository = new PaymentsRepositoryMock();
            _paymentService = new PaymentsTestService(_paymentsRepository.Object);
        }

        [Fact]
        public async void CreatePayment()
        {
            // Arrange
            Payment payment = new Payment()
            {
                Amount = 3000,
                Date = DateTime.UtcNow,
            };

            // Act
            int id = await _paymentService.CreatePayment(payment);

            //Assert
            Assert.True(id > 0);
        }
    }
}
