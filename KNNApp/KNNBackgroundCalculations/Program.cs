using System;

namespace KNNBackgroundCalculations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A");
            string path = @"C:\Users\Zsolt Nagy\source\repos\Desktop app for KNN Visualization\datasets\IRIS.csv";
            DataSet reader = new DataSet(path);
            ScrappyKNN knn = new ScrappyKNN(reader);
            Console.WriteLine("Accuracy: " + knn.MyAccuracy);
            for (int i = 0; i < 10; i++)
            {
                DataSet reader2 = new DataSet(path);
                ScrappyKNN knn2 = new ScrappyKNN(reader2);
                knn2.Predict();
                Console.WriteLine("Accuracy: " + knn2.MyAccuracy);
            }
            Console.ReadKey();
            
        }
    }
}
