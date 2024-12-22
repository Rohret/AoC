using System.Text.RegularExpressions;

static class Day03b
{
  public static void Run()
  {
    string filePath = @"Input\3.txt";

    string fileContents = File.ReadAllText(filePath);

    var result = 0;

    string patternFirst = @"^(.*?)(?=\bdo\(\)|\bdon't\(\))";
    var matchedMulFirst = Regex.Match(fileContents, patternFirst);

    result += GetAllMul(matchedMulFirst);

    string pattern = @"do\([^\)]*\)(.*?)((?=don't\(\))|$)";

    var matchedMul = Regex.Matches(fileContents, pattern, RegexOptions.Singleline);

    foreach (Match item in matchedMul)
    {
      result += GetAllMul(item);
    }

    Console.WriteLine($"Result: {result}");
  }

  private static int GetAllMul(Match mul)
  {
    var result = 0;
    string pattern = @"mul\((\d+),(\d+)\)";
    var matchedMul = Regex.Matches(mul.Value, pattern);
    foreach (Match item in matchedMul)
    {
      result += Calculate(item);
    }
    return result;
  }
  private static int Calculate(Match mul)
  {
    int firstNumber = Int32.Parse(mul.Groups[1].Value);
    int secondNumber = Int32.Parse(mul.Groups[2].Value);
    return firstNumber * secondNumber;
  }
}
