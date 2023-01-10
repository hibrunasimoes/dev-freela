using System;
using DevFreela.Domain.DTOs;

namespace DevFreela.Domain.Services
{
	public interface IPaymentService
	{
        void ProcessPayment(PaymentInfoDTO paymentInfoDTO);
    }
}

