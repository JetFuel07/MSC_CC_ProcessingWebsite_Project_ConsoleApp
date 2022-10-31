using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class Files
{
    private static IEnumerable<string> lines;


    //1. look through the source directory and find all the files matching with file name mask
    public static void Main()
    {
        var path = @"C:\Test";

        var regex = new Regex(@"^merch_remit_data.d\d{8}-u\d{6}.txt$", RegexOptions.Compiled);

        string[] files = Directory.GetFiles(path)
                                  .Where(path => regex.Match(Path.GetFileName(path)).Success)
                                  .ToArray();

        foreach (string filePath in files)
        {
            Console.WriteLine(filePath);
            ReadFiles(filePath);
        }

    }

    //2.Iterate through each file and parse data (merchantID, data, total)
    public static void ReadFiles(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);

        List<string> merchantIDList = new List<string>();
        List<string> dateList = new List<string>();
        List<string> totalList = new List<string>();
        List<string> currencyList = new List<string>();
        List<string> totalInUSDList = new List<string>();


        foreach (string line in lines)
        {
            Console.WriteLine(line);

            string merchantID = line.Substring(0, 4);
            merchantIDList.Add(merchantID);

            string date = line.Substring(5, 8);
            dateList.Add(date);


            string total = line.Substring(13, 10);
            totalList.Add(total);


            string currency = line.Substring(23, 3);
            currencyList.Add(currency);


            string totalInUSD = line.Substring(26, 10);
            totalInUSDList.Add(totalInUSD);
        }

        foreach (string merchantID in merchantIDList)
        {
            Console.WriteLine(merchantID);
        }

        foreach (string date in dateList)
        {
            Console.WriteLine(date);
        }

        foreach (string total in totalList)
        {
            Console.WriteLine(total);
        }

        foreach (string currency in currencyList)
        {
            Console.WriteLine(currency);
        }

        foreach (string totalInUSD in totalInUSDList)
        {
            Console.WriteLine(totalInUSD);
        }
    }




    //public class Post
    //{
    //    public int Id { get; set; }
    //    public DateTime DatePublished { get; set; }
    //    public string Title { get; set; }
    //    public string Body { get; set; }
    //}


 //3. Insert data into TransactionTable
    ///
    //public class Blog
    //{
    //    public int BlogId { get; set; }
    //    public string Name { get; set; }

    //    public virtual List<Post> Posts { get; set; }
    //}

    //public class Post
    //{
    //    public int PostId { get; set; }
    //    public string Title { get; set; }
    //    public string Content { get; set; }

    //    public int BlogId { get; set; }
    //    public virtual Blog Blog { get; set; }
    //}

    //public class BloggingContext : DbContext
    //{
    //    public DbSet<Blog> Blogs { get; set; }
    //    public DbSet<Post> Posts { get; set; }
    //}

    //class Program
    //{
    //    static void Main2(string[] args)
    //    {
    //        using (var db = new BloggingContext())
    //        {
    //            // Create and save a new Blog
    //            Console.Write("Enter a name for a new Blog: ");
    //            var name = Console.ReadLine();

    //            var blog = new Blog { Name = name };
    //            db.Blogs.Add(blog);
    //            db.SaveChanges();

    //            // Display all Blogs from the database
    //            var query = from b in db.Blogs
    //                        orderby b.Name
    //                        select b;

    //            Console.WriteLine("All blogs in the database:");
    //            foreach (var item in query)
    //            {
    //                Console.WriteLine(item.Name);
    //            }

    //            Console.WriteLine("Press any key to exit...");
    //            Console.ReadKey();
    //        }
    //    }
    //}
}






//    private static void OpenSqlConnection()
//    {
//        string connectionString = GetConnectionString();

//        using (SqlConnection connection = new SqlConnection())
//        {
//            connection.ConnectionString = connectionString;

//            connection.Open();

//            Console.WriteLine("State: {0}", connection.State);
//            Console.WriteLine("ConnectionString: {0}",
//                connection.ConnectionString);
//        }
//    }

//    static private string GetConnectionString()
//    {
//        // To avoid storing the connection string in your code,
//        // you can retrieve it from a configuration file.
//        return "Data Source=MSSQL1;Initial Catalog=AdventureWorks;"
//            + "Integrated Security=true;";
//    }
//    static void Main(string[] args)
//{
//    string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ComputerShop;Integrated Security=True";
//    SqlConnection connection = new SqlConnection(@connectionString);
//    string query = "INSERT INTO Person (Name,Salary) VALUES('Max','$1200')";
//    SqlCommand command = new SqlCommand(query, connection);
//    try
//    {
//        connection.Open();
//        command.ExecuteNonQuery();
//        Console.WriteLine("Records Inserted Successfully");
//    }
//    catch (SqlException e)
//    {
//        Console.WriteLine("Error Generated. Details: " + e.ToString());
//    }
//    finally
//    {
//        connection.Close();
//    }
//}





















//2b.Parse data (merchantID, data, total)
//public static void ParseFile(string line)
//{
//    foreach (string line in lines)
//    {
//        //merchantID: i=0-4
//        var merchantID = line.Substring(0, 4);
//        Console.WriteLine(merchantID);
//        //date: i=5-12
//        //total: i=13-22
//        //currency: i=23-24
//        //totalInUSD: i=25-34
//    }

//}








//string path = @"C:\Test\merch_remit_data.d20221026-u075843";

//using (var fileStream = new FileStream(filePath, FileAccess.Read))


//string path = @"C:\Test\merch_remit_data.d20221026-u075843";

//if (!File.Exists(path))
//{
//    //Create the file.
//    using (FileStream fs = File.Create(path))
//    {

//        Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");

//        //Add some information to the file.
//        fs.Write(info, 0, info.Length);
//    }
//}

////Open the stream and read it back.
//using (FileStream fs = File.OpenRead(path))
//{
//    byte[] b = new byte[1024];
//    UTF8Encoding temp = new UTF8Encoding(true);

//    while (fs.Read(b, 0, b.Length) > 0)
//    {
//        Console.WriteLine(temp.GetString(b));
//    }
//}

//string[] filePaths = Directory.GetFiles(@"K:\msc transfer\Settlement\2022");


//try
//{

//    string[] dirs = Directory.GetFiles(@"K:\msc transfer\Settlement\2022", "merch_remit_data.d*");
//    Console.WriteLine("The number of files matching the naming convention is {0}.", dirs.Length);
//    foreach (string dir in dirs)
//    {
//        Console.WriteLine(dir);
//    }
//}
//catch (Exception e)
//{
//    Console.WriteLine("The process failed: {0}", e.ToString());
//}
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