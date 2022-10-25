//1. look through the source directory and find all the files matching with file name mask

using System.IO;

string[] filePaths = Directory.GetFiles(@"K:\msc transfer\Settlement\2022");

foreach (string filePath in filePaths)
{
    Console.WriteLine(filePath);
}


//2. Insert the file name, data load time to the "Processing table"



//3. Loop through all the files from this run



//4. Parse the file



//5. Insert the file to the :"Raw Data table"