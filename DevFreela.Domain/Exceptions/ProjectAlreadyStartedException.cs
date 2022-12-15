using System;
namespace DevFreela.Domain.Exceptions
{
    public class ProjectAlreadyStartedException : Exception
    {
        public ProjectAlreadyStartedException() : base("Project is already in Started status")
        {
        }
    }
}