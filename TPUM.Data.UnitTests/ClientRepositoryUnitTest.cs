using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPUM.Data.Repositiories;

namespace TPUM.Data.UnitTests
{
    [TestClass]
    public class ClientRepositoryUnitTest
    {
        [TestMethod]
        public void Create()
        {
            ClientRepository ClientRepository = new ClientRepository();
            Assert.IsNotNull(ClientRepository);
        }

        [TestMethod]
        public void Get()
        {

        }
    }
}
