using System;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interface;
using DevFreela.Domain.Repositories;
using DevFreela.Domain.Services;
using DevFreela.Infrastructure.AuthService;
using DevFreela.Infrastructure.MessageBus;
using DevFreela.Infrastructure.PaymentsService;
using DevFreela.Infrastructure.Persistence.Repositories;

namespace DevFreela.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IMessageBusService, MessageBusService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
