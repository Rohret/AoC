static class Day05b
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

        CheckRow(tempRow, ruleMatrix, ref result);
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

  private static void CheckRow(string[] row, List<List<int>> ruleMatrix, ref int result, bool changed = false)
  {
    bool completlyDone = true;
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
              var temp = row[j];
              row[j] = row[i];
              row[i] = temp;
              completlyDone = false;
              CheckRow(row, ruleMatrix, ref result, true);
            }
          }
        }
      }
    }
    if (changed && completlyDone)
    {
      result += Int32.Parse(row[row.Length / 2]);
    }
  }

}
