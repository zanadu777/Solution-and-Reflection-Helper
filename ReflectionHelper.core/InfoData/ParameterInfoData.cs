using System.Reflection;

namespace ReflectionHelper.core.InfoData
{
  public class ParameterInfoData 
  {

    public ParameterInfoData()
    {
      
    }

    public string Name { get; set; } 

    public string ParameterTypeName { get; set; }

    public ParameterInfoData(ParameterInfo pInfo)
    {
      Name = pInfo.Name ?? "";
      ParameterTypeName = pInfo.ParameterType.Name;
    }


    public string Declaration  {

      get
      {
        return $"{ParameterTypeName} {Name}";

      }


    }
    
  }
}
