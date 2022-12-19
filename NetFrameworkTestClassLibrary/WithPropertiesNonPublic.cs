using System;
using System.Reflection;
using TestShared;

namespace NetFrameworkTestClassLibrary
{
  public static class WithPropertiesNonPublic
  {
    public static string Private_get_PrivateName(this WithProperties withProperties)
    {
      Type t = withProperties.GetType();
      var result = (string)t.GetProperty("PrivateName", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(withProperties ); ;
      return result;
    }

    public static void Private_set_PrivateName(this WithProperties withProperties, String value)
    {
      Type t = withProperties.GetType();
      var p = t.GetProperty("PrivateName", BindingFlags.NonPublic | BindingFlags.Instance);
      p.SetValue(withProperties,value);
    }
  }
}
