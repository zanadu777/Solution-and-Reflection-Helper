using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionHelper.Core.Extensions
{
  public static class ReadOnlySpanOfCharExtensions
  {
    public static List<string> QuotedList(this ReadOnlySpan<char> input)
    {
      var quoted = new List<string>();
      var doubleQuote = '"';
      var characterPositions = input.CharacterPositions(doubleQuote);
      var numberOfQuoted = characterPositions.Count / 2;

      for (int i = 0; i < numberOfQuoted ; i++)
      {
        var length = characterPositions[i*2 + 1] - characterPositions[i*2] -1;
        var charArray = new char[length];
        for (int j = 0; j < length; j++)
        {
          var charPos = characterPositions[i*2] + 1 + j ;
          charArray[j] = input[charPos];
        }
        quoted.Add(new string(charArray) );
      }

      return quoted;
    }

    public static List<int> CharacterPositions(this ReadOnlySpan<char> input, char c)
    {
      var positions = new List<int>();
      for (int i = 0; i < input.Length; i++)
        if (input[i] == c)
          positions.Add(i );
      return positions;
    }
  }
}
