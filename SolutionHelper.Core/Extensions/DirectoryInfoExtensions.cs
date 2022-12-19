using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SolutionHelper.Core.Extensions
{
  public static class DirectoryInfoExtensions
  {
    public static string AbsolutePathOf(this DirectoryInfo directoryInfo, string relativePath)
    {

      var pathType = EPathType.Unknown;

      if (relativePath.StartsWith(@"\\"))
        pathType = EPathType.NetworkShare;

      else if (relativePath.Substring(1).StartsWith(@":\"))
        pathType = EPathType.AbsoluteLocal;

      else if (relativePath.StartsWith(@"..\"))
        pathType = EPathType.BacktrackingSubPath;
      else
        pathType = EPathType.SubPath;


      var cleanDirectoryPath = directoryInfo.FullName.TrimEnd('\\');

      switch (pathType)
      {
        case EPathType.Unknown:
          break;
        case EPathType.AbsoluteLocal:
        case EPathType.NetworkShare:
          return relativePath;
        case EPathType.SubPath:
          var cleanedReleativePath = relativePath.TrimStart('\\');
          return $@"{cleanDirectoryPath}\{cleanedReleativePath}";
          break;
        case EPathType.BacktrackingSubPath:
          var trimedRelativePath = relativePath.TrimStart(new char[] { '.', '\\' });
          var backtrackCount = (relativePath.Length - trimedRelativePath.Length) / 3;
          var backslashPositions = cleanDirectoryPath.AsSpan().CharacterPositions('\\');
          var position = backslashPositions[backslashPositions.Count - backtrackCount ];
          var trimmedDirectoryName = cleanDirectoryPath.Substring(0, position);
          return $@"{trimmedDirectoryName}\{trimedRelativePath}";
          break;

      }




      return relativePath;
    }
  }
}
