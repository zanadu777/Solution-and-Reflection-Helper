using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using ReflectionHelper.core.Extensions;

namespace ReflectionHelper.Core.Tests.Extensions
{
  [TestFixture]
  public class TypeExtensionsTests
  {
    [Test]
    public void VsTypeName_Primitives()
    {
      int t1 = 1;
      t1.GetType().VsTypeName().Should().Be("int");

      Int32 t2 = 1;
      t2.GetType().VsTypeName().Should().Be("int");

      long t3 = 1;
      t3.GetType().VsTypeName().Should().Be("long");

      Int64 t4 = 1;
      t4.GetType().VsTypeName().Should().Be("long");

      short t5 = 1;
      t5.GetType().VsTypeName().Should().Be("short");

      Int16 t6 = 1;
      t6.GetType().VsTypeName().Should().Be("short");

      byte t7 = 1;
      t7.GetType().VsTypeName().Should().Be("byte");

      double t8 = 1;
      t8.GetType().VsTypeName().Should().Be("double");

      Double t9 = 1;
      t9.GetType().VsTypeName().Should().Be("double");

      float t10 = 1;
      t10.GetType().VsTypeName().Should().Be("float");

      Single t11 = 1;
      t10.GetType().VsTypeName().Should().Be("float");

    }

    [Test]
    public void VsTypeName_Generic_Primitives()
    {
      int[] t2 = {1};
      t2.GetType().VsTypeName().Should().Be("int[]");

      List<int> t3 = new List<int> { 1 };
      t3.GetType().VsTypeName().Should().Be("List<int>");


      Dictionary<int, bool> t4 = new Dictionary<int, bool>()  ;
      t4.GetType().VsTypeName().Should().Be("Dictionary<int, bool>");
    }


     

  }
}
