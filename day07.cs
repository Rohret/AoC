static class Day07
{
  private static long result;

  public static void Run()
  {
    string filePath = @"Input\7.txt";


    string[] fileContents = File.ReadAllLines(filePath);

    List<(long currSum, long[] values)> parsedLines = fileContents
        .Select(line =>
        {
          var parts = line.Split(':');

          long currSum = long.Parse(parts[0].Trim());

          long[] values = parts[1].Trim()
          .Split(' ')
          .Where(x => !string.IsNullOrEmpty(x))
          .Select(long.Parse)
          .ToArray();

          return (currSum, values);
        })
        .ToList();

    foreach (var (currSum, values) in parsedLines)
    {
      long tempRes = 0;
      var allOperations = GetAllCombinations(values.Length - 1);

      foreach (var operationRow in allOperations)
      {
        for (int i = 0; i < values.Length - 1; i++)
        {
          if (i == 0)
          {
            tempRes = PerformOperation(operationRow[i], values[i], values[i + 1]);
          }
          else
          {
            tempRes = PerformOperation(operationRow[i], tempRes, values[i + 1]);
          }
        }

        if (tempRes == currSum)
        {
          result += tempRes;
          tempRes = 0;
          break;
        }

        tempRes = 0;
      }
    }
    Console.WriteLine($"Result: {result}");
  }

  private static long PerformOperation(char op, long num1, long num2)
  {
    return op switch
    {
      '+' => num1 + num2,
      '*' => num1 * num2,
      _ => throw new ArgumentException("Invalid operation.")
    };
  }

  private static List<List<char>> GetAllCombinations(int numberofnumbers)
  {
    List<List<char>> allCombinations = new List<List<char>>();

    GetAllCombinationRecursive(new List<char>(), numberofnumbers, allCombinations);

    return allCombinations;
  }

  private static void GetAllCombinationRecursive(List<char> current, int n, List<List<char>> res)
  {
    if (current.Count >= n)
    {
      res.Add(new List<char>(current));
      return;
    }

    current.Add('+');
    GetAllCombinationRecursive(current, n, res);
    current.RemoveAt(current.Count - 1);

    current.Add('*');
    GetAllCombinationRecursive(current, n, res);
    current.RemoveAt(current.Count - 1);
  }
}
