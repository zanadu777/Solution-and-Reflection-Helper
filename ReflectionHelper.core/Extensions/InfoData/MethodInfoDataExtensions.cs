using ReflectionHelper.core.InfoData;

namespace ReflectionHelper.core.Extensions.InfoData
{
    public static class MethodInfoDataExtensions
    {
        public static List<MethodInfoData> NonPublic(this IEnumerable<MethodInfoData> data)
        {
            return data.Where(item => item.Visibility != "public").ToList();
        }
    }
}
