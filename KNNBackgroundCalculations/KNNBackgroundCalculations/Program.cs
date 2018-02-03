using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNNBackgroundCalculations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A");
            string path = @"C:\Users\Zsolt Nagy\source\repos\Desktop app for KNN Visualization\datasets\IRIS.csv";
            DataReader reader = new DataReader(path);

            Console.ReadKey();
        }
    }
}
