using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Interface;
using EFCoreWrapper;

namespace UnitTestWebApi
{
    [TestClass]
    public class UnitTestDBRoles: IRoles
    {
        [TestMethod]
        public void TestMethodReadDBValues()
        {
            var result = ReadDBValues(1);
            Assert.AreNotEqual(null, result);
        }


        public string ReadDBValues(int value)
        {
            Roles roles = new Roles();
            var result = roles.ReadDBValues(1);
            return result;
        }

        public string WriteDBValues(int id, string value)
        {
            Roles roles = new Roles();
            var result = roles.ReadDBValues(1);
            return result;
        }

        public string DeleteDBValues(int id)
        {
            Roles roles = new Roles();
            var result = roles.DeleteDBValues(id);
            return result;
        }
    }
}
