using House.Financial.PaymentReminder.Data;
using House.Financial.PaymentReminder.Data.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace House.Financial.PaymentReminder.Application.Test.Repositories
{
    public class MockPaymentRepository
    {
        private readonly List<Payment> _payments;

        public MockPaymentRepository()
        {
            _payments = new List<Payment>
            {
                new Payment { Id = 1 , Name = string.Empty, Date = DateTime.Now}
            };
        }

        public IPaymentRepository Mock()
        { 
            var mockRepository = new Mock<IPaymentRepository>();

            mockRepository.Setup(p => p.GetAllAsync())
                .ReturnsAsync(_payments);

            mockRepository.Setup(p => p.GetById(It.IsAny<int>()))
                .ReturnsAsync((int id) => _payments.FirstOrDefault(x => x.Id == id));

            return mockRepository.Object;
        }
    }
}
