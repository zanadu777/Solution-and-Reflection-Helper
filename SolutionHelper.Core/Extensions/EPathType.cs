using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionHelper.Core.Extensions
{
  public enum EPathType
  {
    Unknown,
    AbsoluteLocal,
    NetworkShare,
    SubPath,
    BacktrackingSubPath
  }
}
