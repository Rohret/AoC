static class Day02
{
  public static void Run()
  {
    string filePath = @"Input\2.txt";

    string[] fileContents = File.ReadAllLines(filePath);

    var convertedLines = Converter(fileContents);

    var numberOfValidRows = 0;
    foreach (var row in convertedLines)
    {
      if (isRowValid(row))
      {
        numberOfValidRows++;
      }
    }
    Console.WriteLine($"Correct lines: {numberOfValidRows}");
  }

  private static bool isRowValid(List<int> row) => row.IsSorted() && row.IsCorrectDistance();


  private static List<List<int>> Converter(string[] allLines)
  {

    return allLines
            .Select(line => line.Split(' ')
                                .Select(int.Parse)
                                .ToList())
            .ToList();
  }


  private static bool IsSorted(this IEnumerable<int> source)
  {
    return source.Zip(source.Skip(1), (a, b) => a <= b).All(x => x) ||
           source.Zip(source.Skip(1), (a, b) => a >= b).All(x => x);
  }
  private static bool IsCorrectDistance(this IEnumerable<int> source)
  {
    return source.Zip(source.Skip(1), (a, b) => Math.Abs(a - b) >= 1 && Math.Abs(a - b) <= 3).All(x => x);
  }
}
