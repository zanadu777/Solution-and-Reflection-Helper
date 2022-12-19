using SolutionHelper.Core.Extensions;
using System.Diagnostics;

namespace SolutionHelper.Core.Vs
{
  public class VsProject
  {

    public string Name { get; set; }

    public List<VsReference> References { get; set; } = new();
    public VsProject(FileInfo projectFile)
    {
      using StreamReader reader = File.OpenText(projectFile.FullName);

      string line = String.Empty;
      while ((line = reader.ReadLine()) != null)
      {
        Debug.WriteLine(line);

      }
    }

    protected VsProject()
    {

    }

    public static VsProject ParseProjectFile(FileInfo projectFile)
    {

      var lines = File.ReadAllLines(projectFile.FullName);

      var firstLine = lines[0];
      if (firstLine == """
        <Project Sdk="Microsoft.NET.Sdk">
        """)
        return new VsProjectNet(lines);

      return new VsProjectFramework(lines);
    }
  }
}
