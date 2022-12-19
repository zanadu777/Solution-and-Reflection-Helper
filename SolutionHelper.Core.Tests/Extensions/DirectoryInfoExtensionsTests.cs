using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using SolutionHelper.Core.Extensions;

namespace SolutionHelper.Core.Tests.Extensions
{
  [TestFixture]
  internal class DirectoryInfoExtensionsTests
  {
    [Test]
    public void AbsolutePathOfTest()
    {
      var dir = new DirectoryInfo(@"D:\Dev\Programming 2022\Structured\Wpf\Solutions\");
      dir.AbsolutePathOf(@"Nested\Nested.csproj").Should(). Be(@"D:\Dev\Programming 2022\Structured\Wpf\Solutions\Nested\Nested.csproj");
      dir.AbsolutePathOf(@"\Nested\Nested.csproj").Should().Be(@"D:\Dev\Programming 2022\Structured\Wpf\Solutions\Nested\Nested.csproj");
      dir.AbsolutePathOf(@"\\Share\Solution\project.csproj").Should().Be(@"\\Share\Solution\project.csproj");
      dir.AbsolutePathOf(@"C:\Temp\Solution\project.csproj").Should().Be(@"C:\Temp\Solution\project.csproj");
      dir.AbsolutePathOf(@"..\Wpf\Structured.Wpf.csproj").Should().Be(@"D:\Dev\Programming 2022\Structured\Wpf\Wpf\Structured.Wpf.csproj");

    }
  }
}
