static class Day06
{
  public static void Run()
  {
    string filePath = @"Input\6.txt";

    string[] fileContents = File.ReadAllLines(filePath);

    List<List<char>> allLines = fileContents
        .Select(s => s.ToList())
        .ToList();

    var result = 0;

    AddPath(allLines);

    Console.WriteLine($"Result: {result}");
  }

  private static void AddPath(List<List<char>> allLines)
  {
    var rowIndex = allLines.FindIndex(line => line.Contains('^'));
    if (rowIndex != -1)
    {
      if (rowIndex <= 0)
      {
        // Its over 
      }
      var index = allLines[rowIndex]?.IndexOf('^') ?? -1;
      allLines[rowIndex][index] = 'X';
      allLines[rowIndex - 1][index] = '^';
      Console.WriteLine($"rowIndex: {rowIndex}, index: {index}");
    }
  }

}
