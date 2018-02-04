using KNNBackgroundCalculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace KNNWpfGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Hello {get; set;}

        public MainWindow()
        {
            InitializeComponent();
            
            Button btn = new Button();
            btn.Name = "GetAccuracyButton";
            btn.Click += GetAccuracyButton_Click;
        }

        private void GetAccuracyButton_Click(object sender, RoutedEventArgs e)
        {
            LoadDataSet();
        }

        private void LoadDataSet()
        {
            string path = @"C:\Users\Zsolt Nagy\source\repos\Desktop app for KNN Visualization\datasets\IRIS.csv";
            DataSet r = new DataSet(path);
            this.DataContext = this;
            irisTrainDataBinding.ItemsSource = r.TrainingDataset;
            irisTestDataBinding.ItemsSource = r.TestingDataset;
            ScrappyKNN knn = new ScrappyKNN(r);
            AccuracyLabel.Content = knn.MyAccuracy.ToString();
        }

    }
}
