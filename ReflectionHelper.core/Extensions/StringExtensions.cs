using System.Text;

namespace ReflectionHelper.core.Extensions
{
  public static class StringExtensions
  {
    public static string LineJoin(this IEnumerable<string> texts, int blankLineCount =1)
    {
      StringBuilder sb = new StringBuilder();

      foreach (string text in texts)
      {

        sb.AppendLine(text);

        if (blankLineCount <= 0) 
          continue;

        for (int i=0 ; i<blankLineCount; i++)
          sb.AppendLine();
      }

      return sb.ToString().Trim();
    }



    public static string StringJoin(this IEnumerable<string> texts, string delimiter)
    {
      StringBuilder sb = new StringBuilder();

      var textList = texts.ToList();

      if (textList.Count == 0)
        return "";

      if (textList.Count == 1)
        return textList[0];


      for (int i = 0 ; i < textList.Count -1; i++)
      {
        sb.Append(textList[i]);
        sb.Append(delimiter);
      }
      sb.Append(textList.Last());

      return sb.ToString().Trim();
    }

    public static string LowerFirst(this string text)
    {
      return  text.Substring(0,1).ToLower() + text.Substring(1);
    }

    public static string UpperFirst(this string text)
    {
      return text.Substring(0, 1).ToUpper() + text.Substring(1);
    }
  }
}
