using System;
using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interface
{
	public interface IProjectService
	{
		//modelo de saida, porque é um retorno, por isso usa a viwemodel
		List<ProjectViewModel> GetAll(string quwery);
		ProjectDetailsViewModel GetById(int id);
		int Create(NewProjectInputModel inputModel);
		void Update(UpdateProjectInputModel inputModel);
		void Delete(int id);
		void Start(int id);
		void CreateComente(CreateCommentInputModel inputModel);
		void Finish(int id);
	}
}

