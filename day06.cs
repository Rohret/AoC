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

    AddPathUp(allLines);
    AddPathRight(allLines);
    AddPathDown(allLines);
    AddPathLeft(allLines);

    foreach (var row in allLines)
    {
      foreach (var item in row)
      {
        if (item == 'X')
        {
          result++;
        }
      }
    }

    Console.WriteLine($"Result: {result}");
  }

  private static void AddPathUp(List<List<char>> allLines)
  {
    var rowIndex = allLines.FindIndex(line => line.Contains('^'));
    if (rowIndex != -1)
    {
      var index = allLines[rowIndex]?.IndexOf('^') ?? -1;
      if (rowIndex <= 0)
      {
        allLines[rowIndex][index] = 'X';
        return;
      }

      if (allLines[rowIndex - 1][index] == '#')
      {
        allLines[rowIndex][index] = '>';
        AddPathRight(allLines);
        return;
      }
      allLines[rowIndex][index] = 'X';
      allLines[rowIndex - 1][index] = '^';

      AddPathUp(allLines);
    }
  }

  private static void AddPathRight(List<List<char>> allLines)
  {
    var rowIndex = allLines.FindIndex(line => line.Contains('>'));
    if (rowIndex != -1)
    {
      var index = allLines[rowIndex]?.IndexOf('>') ?? -1;

      if (index >= allLines[rowIndex].Count - 1)
      {
        allLines[rowIndex][index] = 'X';
        return;
      }

      if (allLines[rowIndex][index + 1] == '#')
      {
        allLines[rowIndex][index] = 'v';
        AddPathDown(allLines);
        return;
      }

      allLines[rowIndex][index] = 'X';
      allLines[rowIndex][index + 1] = '>';

      AddPathRight(allLines);
    }
  }
  private static void AddPathDown(List<List<char>> allLines)
  {
    var rowIndex = allLines.FindIndex(line => line.Contains('v'));
    if (rowIndex != -1)
    {
      var index = allLines[rowIndex]?.IndexOf('v') ?? -1;

      if (rowIndex >= allLines.Count - 1)
      {
        allLines[rowIndex][index] = 'X';
        return;
      }

      if (allLines[rowIndex + 1][index] == '#')
      {
        allLines[rowIndex][index] = '<';
        AddPathLeft(allLines);
        return;
      }

      allLines[rowIndex][index] = 'X';
      allLines[rowIndex + 1][index] = 'v';

      AddPathDown(allLines);
    }
  }

  private static void AddPathLeft(List<List<char>> allLines)
  {
    var rowIndex = allLines.FindIndex(line => line.Contains('<'));
    if (rowIndex != -1)
    {
      var index = allLines[rowIndex]?.IndexOf('<') ?? -1;

      if (index <= 0)
      {
        allLines[rowIndex][index] = 'X';
        return;
      }

      if (allLines[rowIndex][index - 1] == '#')
      {
        allLines[rowIndex][index] = '^';
        AddPathUp(allLines);
        return;
      }

      allLines[rowIndex][index] = 'X';
      allLines[rowIndex][index - 1] = '<';

      AddPathLeft(allLines);
    }
  }
}
