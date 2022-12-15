using System;
namespace DevFreela.Domain.Entities
{
    public class Skill : BaseEntity
    {
        public Skill(string description)
        {
            Description = description;
            CreateAt = DateTime.Now;
        }


        public string Description { get; internal set; }
        public DateTime CreateAt { get; internal set; }
    }
}