using System;
using DevFreela.Domain.Entities;

namespace DevFreela.Domain.IntegrationsEvents
{
    public class ApprovedPaymentIntegrationEvent
    {
        public ApprovedPaymentIntegrationEvent(int projectId)
        {
            ProjectId = projectId;
        }

        public int ProjectId { get; set; }
    }
}
