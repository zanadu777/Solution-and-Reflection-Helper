using System.Reflection;
using ReflectionHelper.core.Extensions.Info;

namespace ReflectionHelper.core.InfoData
{
  public class TypeInfoData:InfoDataBase
  {
    public TypeInfoData()
    {
      
    }

    public TypeInfoData(TypeInfo info)
    {
      Name = info.Name;
      NameSpace = info.Namespace;
      Visibility = info.Visibility();

      foreach (var pInfo in info.DeclaredProperties)
        Properties.Add(new PropertyInfoData(pInfo) {Type = this});

      if (info.BaseType != null && info.BaseType.Name !="Object")
        BaseType = new TypeInfoData(info.BaseType.GetTypeInfo());

      IsGenericType = info.IsGenericType;
      if (IsGenericType)
       foreach (var t in  info.GenericTypeParameters )
         GenericTypeParameters.Add(t.Name);
    }


    public bool IsGenericType { get; set; }
    public List<object> GenericTypeParameters { get; set; } = new List<object>();

    public  TypeInfoData  BaseType { get; set; } 

    public List<PropertyInfoData> Properties { get; set; } = new List<PropertyInfoData>();

    public List<MethodInfoData> Methods { get; set; } = new List<MethodInfoData>();

    public List<FieldInfoData> Fileds { get; set; } = new List<FieldInfoData>();

    public override string Declaration
    {
      get
      {
        if (BaseType != null)
          return $"{Visibility} class {Name}:{BaseType.Name}";
        else
          return $"{Visibility} class {Name}";
      }
    }
  }
}
