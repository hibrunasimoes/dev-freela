using System;
using DevFreela.Application.ViewModels;
using DevFreela.Domain.DTOs;
using MediatR;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQuery : IRequest<List<SkillDTO>>
    {
    }
}