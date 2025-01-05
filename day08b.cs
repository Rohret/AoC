static class Day08
{
  private static long result;

  public static void Run()
  {
    string filePath = @"Input\8.txt";

    List<string> fileContents = File.ReadAllLines(filePath).ToList();
    List<string> antinodes = new List<string>();

    for (int i = 0; i < fileContents.Count; i++)
    {
      for (int j = 0; j < fileContents[i].Length; j++)
      {
        if (fileContents[i][j] != '.' && fileContents[i][j] != '#')
        {
          var currentAntenna = fileContents[i][j];

          var firstrow = j;

          for (int k = i; k < fileContents.Count; k++)
          {
            for (int l = firstrow + 1; l < fileContents[k].Length; l++)
            {
              if (currentAntenna == fileContents[k][l])
              {
                var firstIndex = Math.Abs(i - k);
                var secondIndex = Math.Abs(j - l);

                if (Math.Abs(firstIndex - i) < fileContents.Count && Math.Abs(secondIndex + j) < fileContents[i].Length)
                {
                  if (j > l)
                  {
                    var antinode = $"{Math.Abs(firstIndex - i)}, {Math.Abs(secondIndex + j)}";
                    if (!antinodes.Exists(a => a == antinode))
                    {
                      Console.WriteLine(antinode);
                      antinodes.Add(antinode);
                      result++;
                    }
                  }
                }
                if (Math.Abs(firstIndex - i) < fileContents.Count && Math.Abs(secondIndex - j) < fileContents[i].Length)
                {
                  if (j <= l)
                  {
                    var antinode = $"{Math.Abs(firstIndex - i)}, {Math.Abs(secondIndex - j)}";
                    if (!antinodes.Exists(a => a == antinode))
                    {
                      antinodes.Add(antinode);
                      result++;
                    }
                  }
                }
                if (Math.Abs(firstIndex + k) < fileContents.Count && Math.Abs(secondIndex + l) < fileContents[i].Length)
                {
                  if (j <= l)
                  {
                    var antinode = $"{Math.Abs(firstIndex + k)}, {Math.Abs(secondIndex + l)}";
                    if (!antinodes.Exists(a => a == antinode))
                    {
                      antinodes.Add(antinode);
                      result++;
                    }
                  }
                }
                if (Math.Abs(firstIndex + k) < fileContents.Count && Math.Abs(secondIndex - l) < fileContents[i].Length)
                {
                  if (j > l)
                  {
                    var antinode = $"{Math.Abs(firstIndex + k)}, {Math.Abs(secondIndex - l)}";
                    if (!antinodes.Exists(a => a == antinode))
                    {
                      antinodes.Add(antinode);
                      result++;
                    }
                  }
                }
              }
            }
            firstrow = 0;
          }
        }
      }
    }

    /*foreach (var item in antinodes)*/
    /*{*/
    /*  Console.WriteLine(item);*/
    /*}*/
    for (int i = 0; i < fileContents.Count; i++)
    {
      for (int j = 0; j < fileContents[i].Length; j++)
      {
        var antinode = $"{i}, {j}";
        if (!antinodes.Exists(a => a == antinode))
        {
          Console.Write('.');
        }
        else
        {
          Console.Write('#');
        }
      }
      Console.WriteLine("");
    }
    Console.WriteLine($"Result: {result}");
  }

}
