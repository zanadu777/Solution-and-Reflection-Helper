using System.Reflection;
using System.Text;

namespace ReflectionHelper.core.Extensions.Info
{
  public static class TypeInfoExtensions
  {
    public static string DeclarationReport(this TypeInfo typeInfo)
    {
      var sb = new StringBuilder();

      foreach (var p in  typeInfo.DeclaredProperties)
      {
        sb.AppendLine($"{DeclarationVisibility(p)} {p.PropertyType} {p.Name} {GetSet(p)}");
        sb.AppendLine("");
      }

      return sb.ToString();
    }


    public static TypeInfo BaseClass(this TypeInfo typeInfo)
    {
      return  typeInfo.BaseType.GetTypeInfo();
    }
    public static string DeclarationVisibility(PropertyInfo p)
    {
      if (p.GetMethod== null && p.SetMethod == null)
        return "";

      if (p.GetMethod != null && p.SetMethod == null)
      {
        return p.GetMethod.Visibility();
      }

      if (p.GetMethod == null && p.SetMethod != null)
      {
        return p.SetMethod.Visibility();
      }

      if (p.GetMethod != null && p.SetMethod != null)
      {
        var getVisibility = p.GetMethod.Visibility();
        var setVisibility = p.SetMethod.Visibility();

        if (getVisibility == "public" || setVisibility == "public")
          return "public";

        if (p.GetMethod.IsFamily || p.SetMethod.IsFamily)
          return "protected";

        if (p.GetMethod.IsAssembly || p.SetMethod.IsAssembly)
          return "internal";

        if (p.GetMethod.IsPrivate || p.SetMethod.IsPrivate)
          return "private";
      }

      return "";
    }

    public static string Visibility(this TypeInfo info)
    {
      if (info.IsPublicType())
        return "public";

      if (info.IsInternalType())
        return "internal";

      if (info.IsProtectedType())
        return "protected";

      if (info.IsPrivateType())
        return "private";

      return "";
    }

    public static string GetSet(PropertyInfo p)
    {
      if (p.GetMethod != null && p.SetMethod == null)
        return "{get;}";

      if (p.GetMethod == null && p.SetMethod != null)
        return "{set;}";

      if (p.GetMethod != null && p.SetMethod != null)
      {
        var getVisibility = p.GetMethod.Visibility();
        var setVisibility = p.SetMethod.Visibility();

        if (getVisibility == setVisibility)
          return "{get; set;}";

        if (getVisibility== "public" && setVisibility == "protected")
          return "{get; protected set;}";
        if (getVisibility == "public" && setVisibility == "internal")
          return "{get; internal set;}";
        if (getVisibility == "public" && setVisibility == "private")
          return "{get; private set;}";


        if (setVisibility == "public" && getVisibility == "protected")
          return "{protected get; set;}";
        if (setVisibility == "public" && getVisibility == "internal")
          return "{internal get; set;}";
        if (setVisibility == "public" && getVisibility == "private")
          return "{private get; set;}";

        if (getVisibility == "private" && setVisibility== "internal")
          return "{private get;set;}";

        if (getVisibility == "protected" && setVisibility == "private")
          return "{get; private set;}";
        if (getVisibility == "internal" && setVisibility == "private")
          return "{get; private set;}";

        if (setVisibility == "protected" && getVisibility == "private")
          return "{private get;set;}";
        if (setVisibility == "private" && getVisibility == "internal")
          return "{private get; set;}";
      }

      return "";
    }

   static bool  IsPublicType(this TypeInfo t)
    {
      return
        t.IsVisible
        && t.IsPublic
        && !t.IsNotPublic
        && !t.IsNested
        && !t.IsNestedPublic
        && !t.IsNestedFamily
        && !t.IsNestedPrivate
        && !t.IsNestedAssembly
        && !t.IsNestedFamORAssem
        && !t.IsNestedFamANDAssem;
    }

   static bool IsInternalType(this TypeInfo t)
    {
      return
        !t.IsVisible
        && !t.IsPublic
        && t.IsNotPublic
        && !t.IsNested
        && !t.IsNestedPublic
        && !t.IsNestedFamily
        && !t.IsNestedPrivate
        && !t.IsNestedAssembly
        && !t.IsNestedFamORAssem
        && !t.IsNestedFamANDAssem;
    }

    // only nested types can be declared "protected"
    static bool IsProtectedType(this TypeInfo t)
    {
      return
        !t.IsVisible
        && !t.IsPublic
        && !t.IsNotPublic
        && t.IsNested
        && !t.IsNestedPublic
        && t.IsNestedFamily
        && !t.IsNestedPrivate
        && !t.IsNestedAssembly
        && !t.IsNestedFamORAssem
        && !t.IsNestedFamANDAssem;
    }

    // only nested types can be declared "private"
    static bool IsPrivateType(this TypeInfo t)
    {
      return
        !t.IsVisible
        && !t.IsPublic
        && !t.IsNotPublic
        && t.IsNested
        && !t.IsNestedPublic
        && !t.IsNestedFamily
        && t.IsNestedPrivate
        && !t.IsNestedAssembly
        && !t.IsNestedFamORAssem
        && !t.IsNestedFamANDAssem;
    }

  }
}
