using System;
using DevFreela.Domain.Entities;
using DevFreela.Domain.Enums;

namespace DevFreela.UnitTests.Domain.Entities
{
	public class ProjectTests
	{
        [Fact]
        public void TestIfProjectStartWorks()
        {
            var project = new Project("Test Name", "Test Description", 1, 2, 10000);

            Assert.Equal(ProjectStatusEnum.Created, project.Status);
            Assert.Null(project.StartedAt);

            Assert.NotNull(project.Title);
            Assert.NotEmpty(project.Title);

            Assert.NotNull(project.Description);
            Assert.NotEmpty(project.Description);

            project.Start();

            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);
        }
    }
}

