using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using GS.WeeklyReport.IRepository;
using GS.WeeklyReport.IService;
using GS.WeeklyReport.Repository;
using GS.WeeklyReport.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeeklyReport.Models;


namespace GS.WeeklyReport.Portal.Tests.Controllers
{
    [TestClass]
    public class RoleUnitTest
    {
        IRoleService service = new RoleService();
        IRoleRepository repository = new RoleRepository();
      [TestMethod]
        public void TestMethod1()
        {
            IRoleRepository service = new RoleRepository();
            var model= service.Add(new Role() { Name = "TestRole" });
            //var role = service.LoadEntities(r => r.Name == "TestRole").FirstOrDefault()
            Assert.IsNotNull(model);
            Assert.AreEqual(model.Name, "TestRole");

        }
      public void RoleRepositoryTestMethod()
      {
          IRoleRepository repository = new RoleRepository();
          var model = repository.Add(new Role() { Name = "TestRole" });
          Assert.IsNotNull(model);
          Assert.AreEqual(model.Name, "TestRole");

      }
    }
}
