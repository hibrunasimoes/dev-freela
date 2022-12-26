using System;
using DevFreela.Domain.Entities;

namespace DevFreela.Domain.Repositories
{
	public interface IUserRepository
	{
        Task<User> GetByIdAsync(int id);
        Task<User> GetUserByEmailAndPasswordAssync(string email, string passwordHash);
        Task AddAsync(User user);
    }
}

