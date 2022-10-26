//1. look through the source directory and find all the files matching with file name mask


//string[] filePaths = Directory.GetFiles(@"K:\msc transfer\Settlement\2022");

try
{
    // Only get files that begin with the letter "c".
    string[] dirs = Directory.GetFiles(@"K:\msc transfer\Settlement\2022", "merch_remit_data.d*");
    Console.WriteLine("The number of files matching the naming convention is {0}.", dirs.Length);
    foreach (string dir in dirs)
    {
        Console.WriteLine(dir);
    }
}
catch (Exception e)
{
    Console.WriteLine("The process failed: {0}", e.ToString());
}
//using System;
//using System.Text.RegularExpressions;

//var pathFiles = Directory.GetFiles(_appSettingsConnection.GetSection("FilePaths")["DownloadedFiles"], "*.csv");


//public class Test
//{
//    public static void Main()
//    {
//        // Define a regular expression for repeated words.
//        Regex rx = new Regex(@"\b(?<word>\w+)\s+(\k<word>)\b",
//          RegexOptions.Compiled | RegexOptions.IgnoreCase);

//        // Define a test string.
//        string text = "The the quick brown fox  fox jumps over the lazy dog dog.";

//        // Find matches.
//        MatchCollection matches = rx.Matches(text);

//        // Report the number of matches found.
//        Console.WriteLine("{0} matches found in:\n   {1}",
//                          matches.Count,
//                          text);

//        // Report on each match.
//        foreach (Match match in matches)
//        {
//            GroupCollection groups = match.Groups;
//            Console.WriteLine("'{0}' repeated at positions {1} and {2}",
//                              groups["word"].Value,
//                              groups[0].Index,
//                              groups[1].Index);
//        }
//    }
//}




//using System.Text.RegularExpressions;

//var regex = new Regex(@"^\d{6}_\d{8}_", RegexOptions.Compiled);

//string[] files = Directory.GetFiles(folderPath)
//                          .Where(path => regex.Match(Path.GetFileName(path)).Success)
//                          .ToArray();







//string[] filePaths = Directory.GetFiles(@"K:\msc transfer\Settlement\2022");

//foreach (string filePath in filePaths)
//{
//    Console.WriteLine(filePath);
//}

//1. another way
//var pathFiles = Directory.GetFiles(_appSettingsConnection.GetSection("FilePaths")["DownloadedFiles"], "*.csv");



//2. Insert the file name, data load time to the "Processing table"



//3. Loop through all the files from this run



//4. Parse the file



//5. Insert the file to the :"Raw Data table"