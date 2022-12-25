using System;
using DevFreela.Domain.DTOs;

namespace DevFreela.Domain.Repositories
{
	public interface ISkillRepository
	{
		Task<List<SkillDTO>> GetAllAsync();
	}
}

