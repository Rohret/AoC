static class Day05
{
  public static void Run()
  {
    string filePath = @"Input\5.txt";

    string[] fileContents = File.ReadAllLines(filePath);

    var result = 0;
    var index = 0;
    var breakFlag = false;
    List<List<int>> ruleMatrix = new List<List<int>>();

    foreach (var row in fileContents)
    {

      if (row.Trim().Length == 0)
      {
        breakFlag = true;
        continue;
      }

      if (breakFlag)
      {
        var tempRow = row.Split(',');

        if (CheckRow(tempRow, ruleMatrix))
        {
          result += Int32.Parse(tempRow[tempRow.Length / 2]);
        }
      }
      else
      {
        var tempList = row.Split('|');

        ruleMatrix.Add(new List<int>());
        ruleMatrix[index].Add(Int32.Parse(tempList[0]));
        ruleMatrix[index].Add(Int32.Parse(tempList[1]));
      }

      index++;
    }

    Console.WriteLine($"Result: {result}");
  }

  private static bool CheckRow(string[] row, List<List<int>> ruleMatrix)
  {
    for (int i = 0; i < row.Length; i++)
    {
      foreach (var ruleItem in ruleMatrix)
      {
        if (ruleItem[0] == Int32.Parse(row[i]))
        {
          for (int j = i - 1; j >= 0; j--)
          {
            if (ruleItem[1] == Int32.Parse(row[j]))
            {
              return false;
            }
          }
        }
      }
    }
    return true;
  }

}
