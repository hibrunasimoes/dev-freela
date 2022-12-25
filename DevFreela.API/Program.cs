using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.LoginUser;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interface;
using DevFreela.Domain.Repositories;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DevFreelaCs");
builder.Services.AddDbContext<DevFreelaDbContext>(p => p.UseSqlServer(connectionString));
builder.Services.AddControllers();


builder.Services.AddMediatR(typeof(CreateCommentCommand));
builder.Services.AddMediatR(typeof(CreateProjectCommand));
builder.Services.AddMediatR(typeof(DeleteProjectCommand));
builder.Services.AddMediatR(typeof(FinishProjectCommand));
builder.Services.AddMediatR(typeof(StartProjectCommand));
builder.Services.AddMediatR(typeof(UpdateProjectCommand));
builder.Services.AddMediatR(typeof(LoginUserCommand));

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DevFreelaDbContext>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.Configure<OpeningTimeOption>(builder.Configuration.GetSection("OpeningTime"));
builder.Services.AddScoped(e => new ExampleClass { Name = "Initial Stage" });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

