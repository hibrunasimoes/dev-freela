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
        public readonly IHttpClientFactory _httpClientFactory;
        public readonly string _paymentBaseUrl;

        public PaymentService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _paymentBaseUrl = configuration.GetSection("Services:Payments").Value;
        }

        public async Task<bool> ProcessPayment(PaymentInfoDTO paymentInfoDTO)
        {
            var url = $"{_paymentBaseUrl}/api/PaymentService";
            var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDTO);
            var paymentInfoContent = new StringContent(
                paymentInfoJson,
                Encoding.UTF8,
                "application/json"
                );
            var httpClient = _httpClientFactory.CreateClient("Payments");
            var response = await httpClient.PostAsync(url, paymentInfoContent);

            return response.IsSuccessStatusCode;

        }
    }
}

