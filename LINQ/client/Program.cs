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
                //PrintRecords("unfiltered", records);

                // filter: all petal widths are at or above 4.0
                float boundary = 4.0f;
                filtered = records.Where(n => n.PetalWidth >= boundary);
                PrintRecords($"Petal Length at or above {boundary}", filtered);

            }
        }

        static void PrintRecords(string message, IEnumerable<IrisRecord> records)
        {
            // simplest query shows all records
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
