using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionHelper.Core.Vs
{
  public class VsProjectFramework : VsProject
  {
    public VsProjectFramework(FileInfo projectFile) : base(projectFile)
    {
    }

    public VsProjectFramework(string[] lines)
    {
      VsReference currentReference = new VsReference();

      var hintPathLegth = "<HintPath>".Length;

      for (int i = 0; i < lines.Length; i++)
      {
        if (lines[i].TrimStart().StartsWith("<Reference"))
        {
          var split = lines[i].Split(new char[] {'"', ',', '='});

          if (split.Length == 4)
          {

            currentReference = new VsReference {Name = split[2]};
            References.Add(currentReference);
          }
          else
          {
            currentReference = new VsReference
            {
              Name = split[2],
              Version = split[4]
            };
            References.Add(currentReference);
          }
          currentReference.LinesInProject.Add(i);
        }

        if (lines[i].TrimStart().StartsWith("<HintPath>"))
        {
          var index = hintPathLegth + 6;
          var length = lines[i].Length - hintPathLegth - 6 - 11;
          currentReference.HintPath = lines[i].Substring(index, length);
          currentReference.LinesInProject.Add(i);
        }

        if (lines[i].TrimStart().StartsWith("</Reference>"))
          currentReference.LinesInProject.Add(i);
      }
    }
  }
}
