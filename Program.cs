﻿public class Program
{
  public static void Main(string[] args)
  {
    /*Day01.Run();*/
    /*Day01b.Run();*/
    /*Day02.Run();*/
    /*Day02b.Run();*/
    /*Day03.Run();*/
    /*Day03b.Run();*/
    /*Day04.Run();*/
    /*Day04b.Run();*/
    /*Day05.Run();*/
    /*Day05b.Run();*/
    /*Day06.Run();*/
    var thread = new Thread(() =>
    {
      Day06b.Run();
    }, 16 * 1024 * 1024); // 16 MB stack

    thread.Start();
    thread.Join();


  }
}
