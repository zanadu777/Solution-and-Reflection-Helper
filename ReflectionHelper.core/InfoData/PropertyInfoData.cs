using System.Reflection;
using ReflectionHelper.core.Extensions;
using ReflectionHelper.core.Extensions.Info;

namespace ReflectionHelper.core.InfoData
{
  public class PropertyInfoData
  {
    public PropertyInfoData()
    {

    }

    public PropertyInfoData(PropertyInfo info)
    {
      Name = info.Name;
      Visibility = info.Visibility();
      TypeName = info.PropertyType.VsTypeName();
      GetSet = info.GetSet();
      if (info.SetMethod != null)
        Set = new MethodInfoData(info.SetMethod) {Property = this};

      if (info.GetMethod != null)
        Get = new MethodInfoData(info.GetMethod) {Property = this};
    }

    public string Name { get; set; }
    public string Visibility { get; set; }

    public string TypeName { get; set; }

    public string GetSet { get; set; }

    public String Declaration => $"{Visibility} {TypeName} {Name} {GetSet}";

    public MethodInfoData? Set { get; set; }
    public MethodInfoData? Get { get; set; }

    private TypeInfoData type;

    public TypeInfoData Type
    {
      get { return type; }
      set
      {
        type = value;
        if (Set != null)
          Set.Type = type;

        if (Get != null)
          Get.Type = type;
      }
    }
  }
}
