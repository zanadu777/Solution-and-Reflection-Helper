using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionHelper.Core.Vs
{
  public  class VsReference
  {
    public string Name { get; set; }

    public string Version { get; set; }

    public string HintPath { get; set; }

    public List<int> LinesInProject { get; set; } = new();
  }
}
