static class Day01b
{
  public static void Run()
  {
    string filePath = @"Input\1.txt";

    string[] fileContents = File.ReadAllLines(filePath);

    var convertedLines = Converter(fileContents);

    var sum = 0;

    var firstList = new List<int>();

    var secondList = new List<int>();

    AddToList(firstList, secondList, convertedLines);

    firstList.Sort();
    secondList.Sort();

    foreach (var firstItem in firstList)
    {
       foreach (var secondItem in secondList)
       {
          if (firstItem == secondItem)
          {
             sum += firstItem; 
          } 
       } 
    }

    Console.WriteLine($"Sum: {sum}");
  }

  private static List<List<int>> Converter(string[] allLines)
  {

    return allLines
            .Select(line => line.Split("   ")
                                .Select(int.Parse)
                                .ToList())
            .ToList();
  }

  private static void AddToList(List<int> firstList, List<int> secondList, List<List<int>> convertedLines)
  {
    foreach (var row in convertedLines)
    {
      firstList.Add(row[0]);
      secondList.Add(row[1]);
    }
  }
}
