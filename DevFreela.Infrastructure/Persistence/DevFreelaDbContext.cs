using System;
using DevFreela.Domain.Entities;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project ("Meu projeto ASPNET Core 1", "Minha descricao do projeto 1", 1,1,1000),
                new Project ("Meu projeto ASPNET Core 3", "Minha descricao do projeto 2", 1,1,2000),
                new Project ("Meu projeto ASPNET Core 4 ", "Minha descricao do projeto 3", 1,1,3000)
            };

            Users = new List<User>
            {
                new User ("Luis Felipe", "luis@luisdev.com.br", new DateTime(1992,1,1)),
                new User ("Renato Felipe", "renato@luisdev.com.br", new DateTime(1993,1,1)),
                new User ("Rodrigo Felipe", "rodrigo@luisdev.com.br", new DateTime(1995,1,1))
            };

            Skills = new List<Skill>
            {
                new Skill (".NET Core"),
                new Skill (".NET Core"),
                new Skill (".NET Core")
            };
        }

        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
    }

}