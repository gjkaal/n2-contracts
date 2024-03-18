using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace N2.UnitTests;

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

[TestClass]
public class ContractTests {

    [TestMethod]
    public void NotNullThrowsExceptionWhenValueIsNull()
    {
        string? value = null;
        Assert.ThrowsException<ContractException>(() => Contracts.Requires(value, "name"));
    }

    [TestMethod]
    public void NotNullThrowsExceptionWhenObjectIsNull()
    {
        TestClass? value = null;
        Assert.ThrowsException<ContractException>(() => Contracts.Requires(value, "name"));
    }

    [TestMethod]
    public void NotNullDoesNotThrowExceptionWhenObjectIsNotNull()
    {
        TestClass value = new TestClass();
        Contracts.Requires(value, "value");
        Assert.IsTrue(true);
    }

    [TestMethod]
    public void NotNullThrowsExceptionWhenValueIsEmpty()
    {
        Assert.ThrowsException<ContractException>(() => Contracts.Requires(string.Empty, "name"));
    }

    [TestMethod]
    public void NotNullDoesNotThrowExceptionWhenValueIsNotNull()
    {
        Contracts.Requires("value", "name");
        Assert.IsTrue(true);
    }

    [TestMethod]
    public void NotDefaultThrowsExceptionWhenValueIsDefault()
    {
        Assert.ThrowsException<ContractException>(() => Contracts.NotDefault(0, "name"));
    }

    [TestMethod]
    public void NotDefaultDoesNotThrowExceptionWhenValueIsNotNull()
    {
        Contracts.NotDefault(1, "name");
    }
}

internal class TestClass 
{
    public string Name { get; set; } = string.Empty;
}
