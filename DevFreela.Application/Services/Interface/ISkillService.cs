using System;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interface
{
	public interface ISkillService
	{
		List<SkillViewModel> GetAll();
	}
}

