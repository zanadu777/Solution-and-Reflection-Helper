using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionHelper.core.Extensions
{
  public static class TypeExtensions
  {
    private static Dictionary<string, string> simplifiedName = new Dictionary<string, string>
    {
      {"Int32","int" },
      {"Int64","long" },
    };

    public static string VsTypeName(this Type type)
    {
      if (type.IsArray)
      {
        var rawName = type.Name.Replace("[]", "");

        if (simplifiedName.ContainsKey(rawName))
          return $"{simplifiedName[rawName]}[]";

        return type.Name;
      }

      if (type.IsGenericType)
       {
        Type[] ga = type.GenericTypeArguments;
        var typeStart = type.Name.Split('`')[0]  ;

        if (typeStart == "Nullable")
        {
          var innerType = ga[0].VsTypeName();
          return $"{innerType}?";
        }
        else
        {
          var gps = (from a in ga
                     select a.VsTypeName()).ToList();
          var genericParams = string.Join(", ", gps);

          return $"{typeStart}<{genericParams}>";
        }
      }

      if (type == typeof(string))
        return "string";

      if (type == typeof(int))
        return "int";

      if (type == typeof(long))
        return "long";

      if (type == typeof(short))
        return "short";

      if (type == typeof(byte))
        return "byte";

      if (type == typeof(double))
        return "double";

      if (type == typeof(float))
        return "float";

      if (type == typeof(bool))
        return "bool";


      return type.Name;
    }
  }
}
