using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Interface;
using EFCoreWrapper;
using QFWebApiCore.Controllers;

namespace UnitTestWebApi
{
    [TestClass]
    public class UnitTestWebApi
    {
        [TestMethod]
        public void TestMethodGetRoles()
        {
            RolesController rolesController = new RolesController();
            var result = rolesController.Get();
            Assert.AreNotEqual(null, result);
        }
    }
}
