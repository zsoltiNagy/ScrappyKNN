﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;

namespace KNNBackgroundCalculations
{
    class Program
    {
        static void Main(string[] args)
        {
            //string path = @"C:\Users\Zsolt Nagy\source\repos\Desktop app for KNN Visualization\datasets\IRIS.csv"; //4
            //string path = @"C:\Users\Zsolt Nagy\source\repos\Desktop app for KNN Visualization\datasets\Adult\adult.csv";
            string path = @"C:\Users\Zsolt Nagy\source\repos\Desktop app for KNN Visualization\datasets\Wine\Wine.csv"; //0
            //string path = @"C:\Users\Zsolt Nagy\source\repos\Desktop app for KNN Visualization\datasets\Hepatitis\Hepatitis.csv";
            //string path = @"C:\Users\Zsolt Nagy\source\repos\Desktop app for KNN Visualization\datasets\Seeds\SEEDS.csv"; //7
            Test();
            for (int i = 0; i < 10; i++)
            {
                CsvValidator val = new CsvValidator(path);
                DataTableCreator crt = new DataTableCreator(path);
                var Table = crt.MyDataTable;
                foreach (DataRow dataRow in Table.Rows)
                {
                    foreach (var item in dataRow.ItemArray)
                    {
                        Console.WriteLine(item);
                    }
                }
                if (!val.Result)
                {
                    DataSet reader = new DataSet(path, 3);
                    ScrappyKNN knn = new ScrappyKNN(reader);
                    Console.WriteLine("Accuracy: " + knn.MyAccuracy);
                }
            }
            Console.ReadKey();
        }

        private static void Test()
        {
            var x = new ExpandoObject() as IDictionary<string, Object>;
            x.Add("NewProp", "Ayeaye");
            Console.WriteLine(x);
        }
    }
}
