using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace N2.Contracts.UnitTests;

[TestClass]
public class ExceptionFactoryTests
{
    [TestMethod]
    public void ExceptionFactoryCanCreateExeptions()
    {
        var result = ExceptionFactory.NullValue("name");
        Assert.IsNotNull(result);
        Assert.AreEqual("Value cannot be null. (Parameter 'name')", result.Message);
    }
}