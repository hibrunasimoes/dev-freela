using System;
using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interface
{
	public interface IProjectService
	{
		List<ProjectViewModel> GetAll(string quwery);
		ProjectDetailsViewModel GetById(int id);
	}
}

