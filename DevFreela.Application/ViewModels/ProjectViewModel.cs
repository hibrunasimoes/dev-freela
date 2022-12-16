using System;
namespace DevFreela.Application.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(string title, DateTime createdAt)
        {
            Title = title;
            CreatedAt = createdAt;
        }

        public ProjectViewModel(int id, string title, string description, decimal totalCost, DateTime? startedAt, DateTime? finishedAt)
        {
            Id = id;
            Title = title;
            Description = description;
            TotalCost = totalCost;
            StartedAt = startedAt;
            FinishedAt = finishedAt;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public string Description { get; }
        public decimal TotalCost { get; }
        public DateTime? StartedAt { get; }
        public DateTime? FinishedAt { get; }
    }
}