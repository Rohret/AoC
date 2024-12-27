static class Day04
{
  public static void Run()
  {
    string filePath = @"Input\4.txt";

    string[] fileContents = File.ReadAllLines(filePath);

    var result = 0;

    for (int i = 0; i < fileContents.Length; i++)
    {
      result += NumberOfHorizontal(fileContents[i]);
      result += NumberOfVertical(fileContents, i);
      result += NumberOfDiagonal(fileContents, i);
    }

    Console.WriteLine($"Result: {result}");
  }

  private static int NumberOfDiagonal(string[] allRows, int currentIndex)
  {
    var result = 0;
    if (currentIndex >= 3 && currentIndex < allRows.Length - 3)
    {
      for (int i = 0; i < allRows[currentIndex].Length; i++)
      {

        if (i < allRows[currentIndex].Length - 3 && allRows[currentIndex][i] == 'X' && allRows[currentIndex - 1][i + 1] == 'M' && allRows[currentIndex - 2][i + 2] == 'A' && allRows[currentIndex - 3][i + 3] == 'S')
        {
          /*Console.WriteLine($"Current row: {currentIndex} and current location {i}");*/
          result++;
        }
        if (i >= 3 && allRows[currentIndex][i] == 'X' && allRows[currentIndex - 1][i - 1] == 'M' && allRows[currentIndex - 2][i - 2] == 'A'
            && allRows[currentIndex - 3][i - 3] == 'S')
        {
          /*Console.WriteLine($"Current row: {currentIndex} and current location {i}");*/
          result++;
        }
        if (i < allRows[currentIndex].Length - 3 && allRows[currentIndex][i] == 'X' && allRows[currentIndex + 1][i + 1] == 'M' && allRows[currentIndex + 2][i + 2] == 'A' && allRows[currentIndex + 3][i + 3] == 'S')
        {
          /*Console.WriteLine($"Current row: {currentIndex} and current location {i}");*/
          result++;
        }
        if (i >= 3 && allRows[currentIndex][i] == 'X' && allRows[currentIndex + 1][i - 1] == 'M' && allRows[currentIndex + 2][i - 2] == 'A'
            && allRows[currentIndex + 3][i - 3] == 'S')
        {
          /*Console.WriteLine($"Current row: {currentIndex} and current location {i}");*/
          result++;
        }
      }
    }

    if (currentIndex > allRows.Length - 4)
    {

      for (int i = 0; i < allRows[currentIndex].Length; i++)
      {
        if (i < allRows[currentIndex].Length - 3 && allRows[currentIndex][i] == 'X' && allRows[currentIndex - 1][i + 1] == 'M' && allRows[currentIndex - 2][i + 2] == 'A' && allRows[currentIndex - 3][i + 3] == 'S')
        {
          /*Console.WriteLine($"Current row: {currentIndex} and current location {i}");*/
          result++;
        }
        if (i >= 3 && allRows[currentIndex][i] == 'X' && allRows[currentIndex - 1][i - 1] == 'M' && allRows[currentIndex - 2][i - 2] == 'A'
            && allRows[currentIndex - 3][i - 3] == 'S')
        {
          /*Console.WriteLine($"Current row: {currentIndex} and current location {i}");*/
          result++;
        }
      }
    }
    if (currentIndex < 3)
    {

      for (int i = 0; i < allRows[currentIndex].Length; i++)
      {
        if (i < allRows[currentIndex].Length - 3 && allRows[currentIndex][i] == 'X' && allRows[currentIndex + 1][i + 1] == 'M' && allRows[currentIndex + 2][i + 2] == 'A' && allRows[currentIndex + 3][i + 3] == 'S')
        {
          /*Console.WriteLine($"Current row: {currentIndex} and current location {i}");*/
          result++;
        }
        if (i >= 3 && allRows[currentIndex][i] == 'X' && allRows[currentIndex + 1][i - 1] == 'M' && allRows[currentIndex + 2][i - 2] == 'A'
            && allRows[currentIndex + 3][i - 3] == 'S')
        {
          /*Console.WriteLine($"Current row: {currentIndex} and current location {i}");*/
          result++;
        }

      }
    }
    return result;
  }

  private static int NumberOfVertical(string[] allRows, int currentIndex)
  {
    var result = 0;
    if (currentIndex >= 3 && currentIndex < allRows.Length - 3)
    {
      for (int i = 0; i < allRows[currentIndex].Length; i++)
      {
        if (allRows[currentIndex][i] == 'X' && allRows[currentIndex - 1][i] == 'M' && allRows[currentIndex - 2][i] == 'A'
            && allRows[currentIndex - 3][i] == 'S')
        {
          /*Console.WriteLine($"Current row: {currentIndex} and current location {i}");*/
          result++;
        }
        if (allRows[currentIndex][i] == 'X' && allRows[currentIndex + 1][i] == 'M' && allRows[currentIndex + 2][i] == 'A'
            && allRows[currentIndex + 3][i] == 'S')
        {
          /*Console.WriteLine($"Current row: {currentIndex} and current location {i}");*/
          result++;
        }
      }
    }
    if (currentIndex > allRows.Length - 4)
    {

      for (int i = 0; i < allRows[currentIndex].Length; i++)
      {
        if (allRows[currentIndex][i] == 'X' && allRows[currentIndex - 1][i] == 'M' && allRows[currentIndex - 2][i] == 'A'
            && allRows[currentIndex - 3][i] == 'S')
        {
          /*Console.WriteLine($"Current row: {currentIndex} and current location {i}");*/
          result++;
        }
      }
    }
    if (currentIndex < 3)
    {

      for (int i = 0; i < allRows[currentIndex].Length; i++)
      {
        if (allRows[currentIndex][i] == 'X' && allRows[currentIndex + 1][i] == 'M' && allRows[currentIndex + 2][i] == 'A'
            && allRows[currentIndex + 3][i] == 'S')
        {
          /*Console.WriteLine($"Current row: {currentIndex} and current location {i}");*/
          result++;
        }
      }
    }
    return result;
  }

  private static int NumberOfHorizontal(string row)
  {
    var result = 0;
    for (int i = 0; i < row.Length; i++)
    {

      if (row[i] == 'X' && i + 3 < row.Length && row[i + 1] == 'M' && row[i + 2] == 'A' && row[i + 3] == 'S')
      {
        /*Console.WriteLine($" row:{row} current location {i}");*/
        result++;

      }
      if (i - 3 >= 0 && row[i] == 'X' && row[i - 1] == 'M' && row[i - 2] == 'A' && row[i - 3] == 'S')
      {
        /*Console.WriteLine($"row:{row} current location {i}");*/
        result++;
      }

    }
    return result;
  }
}
