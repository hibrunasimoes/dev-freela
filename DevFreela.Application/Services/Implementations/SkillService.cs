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
    }
}

