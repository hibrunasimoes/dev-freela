using System;
namespace DevFreela.Domain.Services
{
    public interface IMessageBusService
    {
        void Publish(string queue, byte[] message);
    }
}

