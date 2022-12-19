using System.Text;
using ReflectionHelper.core.InfoData;

namespace ReflectionHelper.core.Extensions.InfoData
{
  public static class PropertyInfoDataExtensions
  {
    public static string  DeclarationReport(this IEnumerable<PropertyInfoData> data, int spaceCount = 0)
    {

      var sb = new StringBuilder();
      foreach (var info in data)
      {
        sb.AppendLine(info.Declaration);
        if (spaceCount <= 0) 
          continue;

        for (int i = 0; i < spaceCount; i++)
          sb.AppendLine();
      }
      
      return sb.ToString().Trim();
    }

    public static List<MethodInfoData> GetSetMethods(this IEnumerable<PropertyInfoData> data)
    {
      List<MethodInfoData> list = new List<MethodInfoData>();
      foreach (var p in data)
      {
        if (p.Get != null)
          list.Add(p.Get);

        if (p.Set != null)
          list.Add(p.Set);
      }
      return list;
    }


    public static List<PropertyInfoData> Named(this IEnumerable<PropertyInfoData> data, string name)
    {
      return data.Where(x => x.Name == name).ToList();
    }

  }
}
