static class Day06b
{
  private static int result;
  private static List<string> savedPath = new List<string>();
  private static int counter;

  public static void Run()
  {
    string filePath = @"Input\6.txt";

    string[] fileContents = File.ReadAllLines(filePath);

    /*var savedPath = new List<string>();*/

    for (int i = 0; i < fileContents.Length; i++)
    {
      for (int j = 0; j < fileContents[0].Length; j++)
      {
        savedPath.Clear();

        List<List<char>> allLines = fileContents
            .Select(s => s.ToList())
            .ToList();

        if (allLines[i][j] != '#' && allLines[i][j] != '>' && allLines[i][j] != '<' && allLines[i][j] != '^' && allLines[i][j] != 'v')
        {
          allLines[i][j] = 'O';
        }


        /*PrintMatrix(allLines);*/
        AddPathUp(allLines);
        counter = 0;
        /*AddPathRight(allLines);*/
        /*AddPathDown(allLines);*/
        /*AddPathLeft(allLines);*/

      }
    }

    Console.WriteLine($"Result: {result}");

  }

  private static void AddPathUp(List<List<char>> allLines)
  {
    counter++;
    /*Console.WriteLine(counter);*/
    PrintMatrix(allLines);
    var rowIndex = allLines.FindIndex(line => line.Contains('^'));
    if (rowIndex != -1)
    {
      var index = allLines[rowIndex]?.IndexOf('^') ?? -1;
      if (rowIndex <= 0)
      {
        allLines[rowIndex][index] = 'X';
        return;
      }

      if (allLines[rowIndex - 1][index] == '#' || allLines[rowIndex - 1][index] == 'O')
      {

        var newPath = $"{rowIndex},{index},>";

        allLines[rowIndex][index] = '>';

        if (savedPath.Exists(i => i == newPath))
        {
          result++;
          /*PrintMatrix(allLines);*/
          return;
        }
        else
        {
          savedPath.Add(newPath);
        }


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
    counter++;
    /*Console.WriteLine(counter);*/
    PrintMatrix(allLines);
    var rowIndex = allLines.FindIndex(line => line.Contains('>'));
    if (rowIndex != -1)
    {
      var index = allLines[rowIndex]?.IndexOf('>') ?? -1;

      if (index >= allLines[rowIndex].Count - 1)
      {
        allLines[rowIndex][index] = 'X';
        return;
      }

      if (allLines[rowIndex][index + 1] == '#' || allLines[rowIndex][index + 1] == 'O')
      {

        var newPath = $"{rowIndex},{index},v";

        allLines[rowIndex][index] = 'v';

        if (savedPath.Exists(i => i == newPath))
        {
          result++;
          /*PrintMatrix(allLines);*/
          return;
        }
        else
        {
          savedPath.Add(newPath);
        }

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
    counter++;
    /*Console.WriteLine(counter);*/
    PrintMatrix(allLines);
    var rowIndex = allLines.FindIndex(line => line.Contains('v'));
    if (rowIndex != -1)
    {
      var index = allLines[rowIndex]?.IndexOf('v') ?? -1;

      if (rowIndex >= allLines.Count - 1)
      {
        allLines[rowIndex][index] = 'X';
        return;
      }

      if (allLines[rowIndex + 1][index] == '#' || allLines[rowIndex + 1][index] == 'O')
      {

        var newPath = $"{rowIndex},{index},<";

        if (savedPath.Exists(i => i == newPath))
        {
          result++;
          /*PrintMatrix(allLines);*/
          return;
        }
        else
        {
          savedPath.Add(newPath);
        }

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
    counter++;
    /*Console.WriteLine(counter);*/
    PrintMatrix(allLines);
    var rowIndex = allLines.FindIndex(line => line.Contains('<'));
    if (rowIndex != -1)
    {
      var index = allLines[rowIndex]?.IndexOf('<') ?? -1;

      if (index <= 0)
      {
        allLines[rowIndex][index] = 'X';
        return;
      }

      if (allLines[rowIndex][index - 1] == '#' || allLines[rowIndex][index - 1] == 'O')
      {

        var newPath = $"{rowIndex},{index},^";

        if (savedPath.Exists(i => i == newPath))
        {
          result++;
          /*PrintMatrix(allLines);*/
          return;
        }
        else
        {
          savedPath.Add(newPath);
        }

        allLines[rowIndex][index] = '^';
        AddPathUp(allLines);
        return;
      }

      allLines[rowIndex][index] = 'X';
      allLines[rowIndex][index - 1] = '<';

      AddPathLeft(allLines);
    }
  }

  private static void PrintMatrix(List<List<char>> allLines)
  {
    //if (counter > 4900)
    //{
    //  foreach (var row in allLines)
    //  {
    //    foreach (var item in row)
    //    {
    //      Console.Write($"{item}");
    //    }
    //    Console.WriteLine("");
    //  }
    //}
  }
}
