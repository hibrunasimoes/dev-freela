using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DevFreela.Domain.DTOs;
using DevFreela.Domain.Services;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Infrastructure.PaymentsService
{
    public class PaymentService : IPaymentService
    {
        private readonly IMessageBusService _messageBusService;
        private const string QUEUE_NAME = "Payments";

        public PaymentService(IMessageBusService messageBusService)
        {
            _messageBusService = messageBusService;
        }

        public void ProcessPayment(PaymentInfoDTO paymentInfoDTO)
        {
            var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDTO);
            var paymentInfoBytes = Encoding.UTF8.GetBytes(paymentInfoJson);

            _messageBusService.Publish(QUEUE_NAME, paymentInfoBytes);
        }
    }
}

