using System;
using System.Linq;
using Dapper;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interface;
using DevFreela.Application.ViewModels;
using DevFreela.Domain.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString; 

        public ProjectService (DevFreelaDbContext dbContext, IConfiguration configuration )
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }
        public int Create(NewProjectInputModel inputModel)
        {

            var project = new Project(
                inputModel.Title,
                inputModel.FreelancerId,
                inputModel.Description,
                inputModel.IdClient,
                inputModel.TotalCost);

            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();
            return project.Id;

        }

        public void CreateComente(CreateCommentInputModel inputModel)
        {
            var coment = new ProjectComment(
                inputModel.Content,
                inputModel.IdProject,
                inputModel.IdUser);

            _dbContext.ProjectComments.Add(coment);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
            project.Cancel();

            _dbContext.SaveChanges();
        }

        public void Finish(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
            project.Finish();

            _dbContext.SaveChanges();
        }

        public List<ProjectViewModel> GetAll(string quwery)
        {
            var projects = _dbContext.Projects;
            var projectsViewModel = projects
                .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
                .ToList();

            return projectsViewModel;
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            var project = _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefault(p => p.Id == id);

            if (project == null) return null;

            var projectDetailsViewModel = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt,
                project.Client.FullName,
                project.Freelancer.FullName);

            return projectDetailsViewModel;
        }

        public void Start(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            project.Start();

            //_dbContext.SaveChanges();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "UPDATE Projects SET Status = @status, StartedAt = @startedat WHERE Id = @Id";

                sqlConnection.Execute(script, new { status = project.Status, startedat = project.StartedAt, id });
            }
        }

        public void Update(UpdateProjectInputModel inputModel)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == inputModel.Id);

            project.Update(
                inputModel.Title,
                inputModel.Description,
                inputModel.TotalCost);

            _dbContext.SaveChanges();

        }
    }
}

