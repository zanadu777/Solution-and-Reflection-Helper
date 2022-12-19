using System.Reflection;
using FluentAssertions;
using ReflectionHelper.core.Extensions.InfoData;
using ReflectionHelper.core.InfoData;
using TestShared;

namespace ReflectionHelper.Core.Tests.Extensions.InfoData
{
  [TestFixture]
  public class PropertyInfoDataTests
  {
    [Test]
    public void PublicNameTest()
    {
      var withProperties = new WithProperties();

      var tid = new TypeInfoData(withProperties.GetType().GetTypeInfo());

      tid.Properties.Named("PublicName")[0].Declaration.Should().Be("public string PublicName { get; set; }");
      tid.Properties.Named("PublicNameOnlySet")[0].Declaration.Should().Be("public string PublicNameOnlySet { set; }");
      tid.Properties.Named("NullableInt")[0].Declaration.Should().Be("public int? NullableInt { get; set; }");

    }


    [Test]
    public void NullableProperties()
    {
      var withProperties = new WithProperties();
      var tid = new TypeInfoData(withProperties.GetType().GetTypeInfo());
      tid.Properties.Named("NullableInt")[0].Declaration.Should().Be("public int? NullableInt { get; set; }");

    }


    [Test]
    public void TypeNamesTest()
    {
      var t = new TypeNames();
      var tid = new TypeInfoData(t.GetType().GetTypeInfo());
    }
  }

}