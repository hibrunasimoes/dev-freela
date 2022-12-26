using System;
namespace DevFreela.Domain.Services
{
	public interface IAuthService
	{
        string GenerateJwtToken(string email, string role);
    }
}

