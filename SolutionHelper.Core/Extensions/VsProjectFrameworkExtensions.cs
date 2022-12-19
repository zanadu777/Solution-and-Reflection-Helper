using SolutionHelper.Core.Vs;

namespace SolutionHelper.Core.Extensions
{
  public static class VsProjectFrameworkExtensions
  {

    public static List<VsReference> DistinctReferences(this IEnumerable<VsProjectFramework> projects)
    {
      var refDict = new Dictionary<string, VsReference>();

      foreach (var project in projects)
        foreach (var reference in project.References)
          if (!refDict.ContainsKey(reference.Name))
            refDict[reference.Name] = reference;

      return (from VsReference reference in refDict.Values
              select reference).ToList();
    }
  }
}
