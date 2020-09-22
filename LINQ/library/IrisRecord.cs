using System;
using System.Collections.Generic;
using System.IO;

namespace LINQDataSources
{

    public class IrisRecord
    {
        public int ID{ get; set; }
        public float SepalLength{ get; set; }
        public float SepalWidth { get; set; }
        public float PetalLength { get; set; }
        public float PetalWidth { get; set; }
        public string IrisClassificationName { get; set; }

        public override string ToString()
        {
            return $"ID: {ID}\n" +
                   $"Class: {IrisClassificationName}\n" +
                   $"Sepal Length: {SepalLength}\t" + 
                   $"Sepal Width: {SepalWidth}\t" +
                   $"Petal Length: {PetalLength}\t" + 
                   $"Petal Width: {PetalWidth}\t";
        }
    }
}