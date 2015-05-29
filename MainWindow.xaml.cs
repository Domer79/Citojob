using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using DevExpress.Data.XtraReports.Wizard.Native;
using DevExpress.Xpf.Core.DataSources;
using DevExpress.Xpf.Grid;

namespace Citojob
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ISourceData<TestData> _data;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _data = new TestSourceData();
            InitGridControl();
            _gridControl.ItemsSource = _data.GetObservableData();
        }

        private void InitGridControl()
        {
            var tableView = (TableView) _gridControl.View;
            tableView.ShowAutoFilterRow = true;
        }
    }

    public class TestData
    {
        [DisplayName(@"Идентификатор")]
        public int Id { get; set; }

       [DisplayName(@"Исполнитель")]
        public string Name { get; set; }
    }

    public class TestSourceData : ISourceData<TestData>
    {
        public ObservableCollection<TestData> GetObservableData()
        {
            return new ObservableCollection<TestData>(new List<TestData>
            {
                new TestData{Id = 1, Name = "Domer"}
            });
        }
    }

    internal interface ISourceData<T> where T : class
    {
        ObservableCollection<T> GetObservableData();
    }
}
