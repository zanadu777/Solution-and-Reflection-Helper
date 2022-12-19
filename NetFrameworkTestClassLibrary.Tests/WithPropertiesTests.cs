using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using TestShared;

namespace NetFrameworkTestClassLibrary.Tests
{
  [TestFixture]
    public class WithPropertiesTests
    {
      [Test]
      public void TestPrivateName()
      {
        var w = new WithProperties();
        w.Private_set_PrivateName("Test1");
        w.Private_get_PrivateName().Should().Be("Test1");
      }
    }
}
