using System.Text;
using ReflectionHelper.core.Extensions;
using ReflectionHelper.core.InfoData;

namespace ReflectionHelper.core.Generators
{
    public class CallNonPublicGenerator
    {
      public string Generate(MethodInfoData info)
      {
        var sb = new StringBuilder();

        if (info.Parameters.Any())
        {
          var parameters = info.ParameterDeclarations().StringJoin(", ");
          sb.AppendLine($"public static {info.ReturnType} {info.Visibility.UpperFirst()}_{info.Name}(this {info.Type.Name} {info.Type.Name.Split('.').Last().LowerFirst()}, {parameters})");
        }
        else
          sb.AppendLine($"public static {info.ReturnType} {info.Visibility.UpperFirst()}_{info.Name}(this {info.Type.Name} {info.Type.Name.Split('.').Last().LowerFirst()})");
        sb.AppendLine("{");

        sb.AppendLine("}");
        return sb.ToString();


      }

      public List<string> Generate(IEnumerable<MethodInfoData> infos)
      {
        var generated = new List<string>();
        foreach (var info in infos)
          generated.Add(Generate(info));

        return generated;
      }
    }
}
