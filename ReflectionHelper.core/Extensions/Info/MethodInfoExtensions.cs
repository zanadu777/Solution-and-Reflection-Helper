using System.Reflection;
using System.Text;
using ReflectionHelper.core.InfoData;

namespace ReflectionHelper.core.Extensions.Info
{
    public static class MethodInfoExtensions
    {

        public static string Visibility(this MethodInfo methodInfo)
        {
            if (methodInfo.IsPublic)
                return "public";

            if (methodInfo.IsFamily)
                return "protected";

            if (methodInfo.IsAssembly)
                return "internal";

            if (methodInfo.IsPrivate)
                return "private";

            return "";
        }

        public static List<ParameterInfo> Parameters(this MethodInfo methodInfo)
        {
          var mps = methodInfo.GetParameters();
          return mps.ToList();

        }

        public static string DeclarationReport(this IEnumerable<MethodInfoData> data, int spaceCount = 0)
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
    }
}
