using System;
using System.Collections.Generic;
using System.IO;

namespace LINQDataSources
{

    /// <summary>
    /// Designed to work with the R. A. Fisher Iris Dataset: https://archive.ics.uci.edu/ml/datasets/Iris
    /// </summary>
    public class IrisDataSourceHelper
    {

        private static int count = 1;


        /// <summary>
        /// Accepts an Iris DataSet infile and produces an IEnumerable of IrisRecord objects
        /// </summary>
        /// <param name="filepath">iris data flatfile</param>
        /// <returns>IEnumerable of IrisRecords</returns>
        public static IEnumerable<IrisRecord> GetIrisRecordsFromFlatFile(string filepath)
        {

            //hold the data from reading the file
            string[] data;

            //hold the resulting IrisRecords
            List<IrisRecord> records = new List<IrisRecord>();

            try
            {
                data = File.ReadAllLines(filepath);

                foreach(string record in data)
                {
                    IrisRecord iris_datum = ParseIrisRecordFromString(record);
                    if(iris_datum != null)
                    {
                        records.Add(iris_datum);
                    }
                }
            }
            catch(FileLoadException exp)
            {
                Console.Error.WriteLine($" {exp.Message} cannot read {filepath}");
            }

            return records;
        }


        /// <summary>
        /// Parse the components of an Iris Record. See: https://archive.ics.uci.edu/ml/machine-learning-databases/iris/iris.names
        /// </summary>
        /// <param name="recordstring">line from the iris data file</param>
        /// <returns>IrisRecord object</returns>        
        private static IrisRecord ParseIrisRecordFromString(string recordstring)
        {

            string[] parts;

            if(recordstring.Length > 0)
            {
                parts = recordstring.Split(new char[]{','});

                return new IrisRecord
                { 
                    ID = count++, 
                    SepalWidth = Convert.ToSingle(parts[0]), 
                    SepalLength = Convert.ToSingle(parts[1]),
                    PetalWidth = Convert.ToSingle(parts[2]),
                    PetalLength = Convert.ToSingle(parts[3]),
                    IrisClassificationName = parts[4],
                };

            }
            else 
            {
                return null;
            }
        }
    }
}
