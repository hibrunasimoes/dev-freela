using System;
using System.Text;
using System.Text.Json;
using DevFreela.Domain.IntegrationsEvents;
using DevFreela.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace DevFreela.Application.Consumers
{
    public class ApprovedPaymentsConsumer : BackgroundService
    {
        private const string APPROVED_PAYMENTS = "ApprovedPayments";
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;

        public ApprovedPaymentsConsumer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(
                queue: APPROVED_PAYMENTS,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (sender, eventArgs) =>
            {
                var byteArray = eventArgs.Body.ToArray();
                var paymentInfoJson = Encoding.UTF8.GetString(byteArray);

                var paymentInfo = JsonSerializer.Deserialize<ApprovedPaymentIntegrationEvent>(paymentInfoJson);

                FinishProject(paymentInfo.ProjectId);

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(APPROVED_PAYMENTS, false, consumer);

            return Task.CompletedTask;
        }

        private async Task FinishProject(int projectId)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var projectRepository = scope.ServiceProvider.GetRequiredService<IProjectRepository>();

                var project = await projectRepository.GetByIdAsync(projectId);

                project.Finish();

                await projectRepository.SaveChangesAsync();
            }
        }
    }
}

