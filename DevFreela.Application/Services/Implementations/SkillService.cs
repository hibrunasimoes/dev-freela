using System;
using Dapper;
using DevFreela.Application.Services.Interface;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _dbcontext;
        private readonly string _connectionstring;

        public SkillService(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbcontext = dbContext;
            _connectionstring = configuration.GetConnectionString("DevFreelaCs");
        }
        public List<SkillViewModel> GetAll()
        {

            using (var sqlConnection = new SqlConnection(_connectionstring))
            {
                sqlConnection.Open();
                var script = "SELECT Id, Description FROM Skills";

                return sqlConnection.Query<SkillViewModel>(script).ToList();
            }
            //var skills = _dbcontext.Skills;
            //var skillsViewModel = skills
            //    .Select(s => new SkillViewModel(s.Id, s.Description))
            //    .ToList();

            //return skillsViewModel;
        }
    }
}

