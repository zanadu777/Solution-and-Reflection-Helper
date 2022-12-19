using System.Diagnostics;
using SolutionHelper.Core.Extensions;

namespace SolutionHelper.Core.Vs;

public class VsSolution
{
  public List<VsProject> Projects { get; set; } = new();
  public VsSolution(FileInfo solutionFile)
  {
    if (solutionFile == null) throw new ArgumentNullException();
    if (!solutionFile.Exists) throw new FileNotFoundException();

    var solutionDir = new FileInfo(solutionFile.FullName).Directory;
    if (solutionDir == null) throw new ArgumentNullException();

    using StreamReader reader = File.OpenText(solutionFile.FullName);

    while (reader.ReadLine() is { } line)
    {
      if (line.StartsWith("Global"))
        break;

      if (!line.StartsWith("Project")) 
        continue;

      var quoted = line.AsSpan().QuotedList() ;
      var relativepath = quoted[2];
      var path = solutionDir.AbsolutePathOf(relativepath);

      var projectInfo = new FileInfo(path);

      if (projectInfo.Exists)
      {
        var project = VsProject.ParseProjectFile(projectInfo);
        project.Name = quoted[1];
        Projects.Add(project);
      }
      else if(quoted[1] != quoted[2] )
        Debugger.Break();
    }
  }

  public List<VsProjectFramework> FrameworkProjects {
    get
    {
      var projects = (from VsProject project in Projects
                     where project is VsProjectFramework
                     select (VsProjectFramework)project).ToList();
      return projects;
    }
  }
}