using System;
using DevFreela.Domain.DTOs;

namespace DevFreela.Domain.Services
{
	public interface IPaymentService
	{
        Task <bool> ProcessPayment(PaymentInfoDTO paymentInfoDTO);
    }
}

