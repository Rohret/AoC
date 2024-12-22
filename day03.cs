using System.Text.RegularExpressions;

static class Day03
{
  public static void Run()
  {
    string filePath = @"Input\3.txt";

    string fileContents = File.ReadAllText(filePath);

    var result = 0;

    string pattern = @"mul\((\d+),(\d+)\)";

    var matchedMul = Regex.Matches(fileContents, pattern);

    foreach (Match item in matchedMul)
    {
      result += Calculate(item);
    }

    Console.WriteLine($"Result: {result}");
  }

  private static int Calculate(Match mul)
  {
    int firstNumber = Int32.Parse(mul.Groups[1].Value);
    int secondNumber = Int32.Parse(mul.Groups[2].Value);
    return firstNumber * secondNumber;
  }
}
