using System.Reflection;
using FluentAssertions;
using ReflectionHelper.core.InfoData;
using TestShared;

namespace ReflectionHelper.Core.Tests.Extensions.InfoData
{
  [TestFixture]
  public class TypeInfoDataTests
  {
    [Test]
    public void WithPropertiesTest()
    {
      var withProperties = new WithProperties();

      var data =new TypeInfoData(typeof(WithProperties).GetTypeInfo());

      data.Visibility.Should().Be("public");

      data.Declaration.Should().Be("public class WithProperties");

    }

    [Test]
    public void WithPropertiesDescendentTest()
    {
       var data = new TypeInfoData(typeof(WithPropertiesDescendent).GetTypeInfo());
       data.Declaration.Should().Be("public class WithPropertiesDescendent:WithProperties");
    }


    [Test]
    public void SingleGenericTest()
    {
      var data = new TypeInfoData(typeof(SingleGeneric<string>).GetTypeInfo());

      data.Declaration.Should().Be("public class SingleGeneric<string>");


    }


    [Test]
    public void DoubleGenericTest()
    {
      var data = new TypeInfoData(typeof(DoubleGeneric<int, long>).GetTypeInfo());


      data.Declaration.Should().Be("public class DoubleGeneric<int, long>");


    }
  }
}
