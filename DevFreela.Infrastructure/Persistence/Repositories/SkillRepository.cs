using System;
using Dapper;
using DevFreela.Domain.DTOs;
using DevFreela.Domain.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly string _connectionString;

        public SkillRepository (IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }
        public async Task<List<SkillDTO>> GetAllAsync()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT Id, Description FROM Skills";

                var skills = await sqlConnection.QueryAsync<SkillDTO>(script);

                return skills.ToList();
            }
        }
    }
}

