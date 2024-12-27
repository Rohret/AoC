static class Day04b
{
  public static void Run()
  {
    string filePath = @"Input\4.txt";

    string[] fileContents = File.ReadAllLines(filePath);

    var result = 0;

    for (int i = 0; i < fileContents.Length; i++)
    {
      result += NumberOfDiagonal(fileContents, i);
    }

    Console.WriteLine($"Result: {result}");
  }

  private static int NumberOfDiagonal(string[] allRows, int currentIndex)
  {
    var result = 0;
    if (currentIndex >= 1 && currentIndex < allRows.Length - 1)
    {
      for (int i = 1; i < allRows[currentIndex].Length - 1; i++)
      {
        if (allRows[currentIndex][i] == 'A')
        {
          if (RightDiagonal(allRows, currentIndex, i) && LeftDiagonal(allRows, currentIndex, i))
          {
            result++;
          }
        }
      }
    }
    return result;
  }

  private static bool RightDiagonal(string[] allRows, int currentIndex, int i)
  {
    if (allRows[currentIndex - 1][i + 1] == 'S' && allRows[currentIndex + 1][i - 1] == 'M')
    {
      return true;
    }
    if (allRows[currentIndex - 1][i + 1] == 'M' && allRows[currentIndex + 1][i - 1] == 'S')
    {
      return true;
    }
    return false;
  }

  private static bool LeftDiagonal(string[] allRows, int currentIndex, int i)
  {
    if (allRows[currentIndex - 1][i - 1] == 'S' && allRows[currentIndex + 1][i + 1] == 'M')
    {
      return true;
    }
    if (allRows[currentIndex - 1][i - 1] == 'M' && allRows[currentIndex + 1][i + 1] == 'S')
    {
      return true;
    }
    return false;
  }
}
