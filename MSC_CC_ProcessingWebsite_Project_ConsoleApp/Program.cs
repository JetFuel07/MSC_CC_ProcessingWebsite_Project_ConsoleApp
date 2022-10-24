using System.IO;

public static class Processor
{
    static void Main()
    {
        string[] list = Directory.GetFiles("C:\\Repos", "*.*", SearchOption.AllDirectories);

        foreach (string file in list)
        {
            Console.WriteLine(file);
        }
    }
}