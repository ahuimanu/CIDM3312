using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using LINQDataSources;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {

            IEnumerable<IrisRecord> records = LoadIrisData();
            IEnumerable<IrisRecord> filtered;

            if(records != null)
            {
                //print all
                // PrintRecords("unfiltered", records);

                // filter: all petal widths are at or above 4.0
                float boundary = 4.0f;
                // filtered = records.Where(n => n.PetalWidth >= boundary);
                // PrintRecords($"Petal Width at or above {boundary}", filtered);

                /*
                from num in numbers
                    where num % 2 == 0
                    orderby num
                    select num;
                */

                var otherfilter = 
                    from record in records
                    where record.PetalLength < boundary
                    select record;

                PrintRecords($"Petal Length at or below {boundary}", otherfilter);                    

                // complete all of the queries here

                /*
                Create and show a LINQ Query that lists all Sepal Widths that are above the average Sepal Width
                Create and show a LINQ Query that lists all Sepal Lengths that are below the average Sepal Length
                Create and show a LINQ Query that indicates which class of iris has the lowest average Petal Width
                Create and show a LINQ Query that indicates which class of iris has the highest average Petal Length
                Create and show a LINQ Query that indicates the widest Sepal Width for each class of iris
                Create and show a LINQ Query that indicates the shortest Sepal Length for each class of iris
                Create and show a LINQ Query that indicates the ranks the top 5 widest Petal Widths
                Create and show a LINQ Query that indicates the ranks the bottom 5 shortest Petal Lengths
                Create and show a LINQ Query that indicates the median Sepal Width for each class of iris
                Create and show a LINQ Query that indicates the mode Petal Length for each class of iris
                */
            }
        }

        static void PrintRecords(string message, IEnumerable<IrisRecord> records)
        {
            // simplest query shows all records
            Console.WriteLine(message);
            foreach(IrisRecord record in records)
            {
                Console.WriteLine(record);
            }
        }

        static IEnumerable<IrisRecord> LoadIrisData()
        {
            // this is somewhat "brittle" code as it only works when the project is
            // run within the client folder.
            Console.WriteLine($@"{Directory.GetCurrentDirectory()}\data\iris.data");
            FileInfo file = new FileInfo($@"{Directory.GetCurrentDirectory()}\data\iris.data");
            Console.WriteLine(file.FullName);
            
            IEnumerable<IrisRecord> records = null;

            try
            {
                records = IrisDataSourceHelper.GetIrisRecordsFromFlatFile(file.FullName);
            }catch (Exception exp)
            {
                Console.Error.WriteLine(exp.StackTrace);
            }
            return records;
        }
    }
}
