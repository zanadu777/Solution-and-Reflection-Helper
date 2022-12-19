using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolutionHelper.Core.Extensions;

namespace SolutionHelper.Core.Vs
{
  public class VsProjectNet:VsProject
  {
    

    public VsProjectNet(FileInfo projectFile) : base(projectFile)
    {
    }

    public VsProjectNet(string[] lines)
    {
      foreach (var line in lines)
      {
        if (line.TrimStart().StartsWith("<PackageReference"))
        {
          var quoted = line.AsSpan().QuotedList();
          var reference = new VsReference
          {
            Name = quoted[0],
            Version = quoted[1]
          };
          References.Add(reference);
        }
      }

    }
  }
}
