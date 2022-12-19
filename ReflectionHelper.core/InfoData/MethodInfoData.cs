using System.Reflection;
using ReflectionHelper.core.Extensions.Info;

namespace ReflectionHelper.core.InfoData
{
  public class MethodInfoData
  {
    public MethodInfoData()
    {
      
    }

    public MethodInfoData(MethodInfo info)
    {
      Name = info.Name;
      Visibility = info.Visibility();
      ReturnType = CleanedReturnType(info.ReturnType.Name);
      Parameters = new List<ParameterInfoData>();
      foreach (var parameter in info.Parameters())
        Parameters.Add(new ParameterInfoData(parameter));
    }

    private string CleanedReturnType(string returnedType)
    {
      switch (returnedType)
      {
        case "Void":
          return "void";
        case "String":
          return "string";
        default:
          return returnedType;
      }
    }

    public string Name { get; set; }
    public string Visibility { get; set; }

    public string ReturnType { get; set; }


    public String Declaration => $"{Name}";

    public TypeInfoData Type { get; set; }
    public PropertyInfoData Property { get; set; }

    public List<ParameterInfoData> Parameters { get; set; }

    public List<string> ParameterDeclarations()
    {
      var declarations = Parameters.Select(p => p.Declaration).ToList();
      return declarations;
    }
  }
}
