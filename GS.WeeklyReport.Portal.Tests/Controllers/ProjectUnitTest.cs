using System;
using System.Linq;
using GS.WeeklyReport.IRepository;
using GS.WeeklyReport.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeeklyReport.Models;

namespace GS.WeeklyReport.Portal.Tests.Controllers
{
    [TestClass]
    public class ProjectUnitTest
    {
        private IProjectRepository _projectRepository = new ProjectRepository();
        private IUserRepository _userRepository = new UserRepository();
        [TestMethod]
        public void AddProjectRepositoryTestMethod1()
        {

            var user1 = new User()
            {
                
            };
            var user = _userRepository.LoadEntities(u => true).FirstOrDefault();
            Project model = new Project()
            {
                PorjectId = new Guid("CB5BB9AC-8E3F-DA04-268E-3A9766583FAE"),
                Name = "TestProject",
                LeaderId = user.UserId,
                Description = "TESTTESTTEST",
                Status = "1",
                Color = "red",
                StartDate = DateTime.Now
            };
            var project = _projectRepository.Add(model);
            Assert.IsNotNull(project);
            Assert.AreSame(project.Name, "TESTTESTTEST");
        }
    }
}
