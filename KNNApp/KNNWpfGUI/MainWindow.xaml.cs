using KNNBackgroundCalculations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
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
        public string Hello { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Button btn = new Button
            {
                Name = "GetAccuracyButton"
            };
            btn.Click += GetAccuracyButton_Click;
        }

        private void GetAccuracyButton_Click(object sender, RoutedEventArgs e)
        {
            LoadDataSet();
        }

        private void LoadDataSet()
        {
            string path = @"C:\Users\Zsolt Nagy\source\repos\Desktop app for KNN Visualization\datasets\IRIS.csv";
            string[] columnNames = new string[] { "Sepal Length", "Sepal Width", "Petal Length", "Petal Width", "Species" };
            KNNBackgroundCalculations.DataSet r = new KNNBackgroundCalculations.DataSet(path, 4, columnNames);
            this.DataContext = this;
            irisTrainDataBinding.ItemsSource = r.TrainingTable.DefaultView;
            irisTestDataBinding.ItemsSource = r.TestingTable.DefaultView;
            ScrappyKNN knn = new ScrappyKNN(r);
            AccuracyLabel.Content = "Accuracy: " + Math.Round(knn.MyAccuracy, 2).ToString() + "%";
        }

        private void IrisInfoButton_Click(object sender, RoutedEventArgs e)
        {
            IrisInfo irisInfo = new IrisInfo();
            irisInfo.Show();
        }
    }
}
