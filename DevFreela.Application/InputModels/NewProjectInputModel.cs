using System;
namespace DevFreela.Application.InputModels
{
    public class NewProjectInputModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int IdClient { get; set; }
        public int FreelancerId { get; set; }
        public decimal TotalCost { get; set; }
    }
}