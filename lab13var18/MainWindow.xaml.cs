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

namespace lab13var18
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        TrainsEntities db = new TrainsEntities();

        public MainWindow()
        {
            InitializeComponent();

            dgTrains.ItemsSource = db.TrainTime.ToList();
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            DateTime choosenDate = Convert.ToDateTime(dateTrain.Text);
            dgTrains.ItemsSource = null;
            dgTrains.ItemsSource = db.TrainTime.Where(x => x.Date == choosenDate.Date).ToList();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            dgTrains.ItemsSource = null;
            dgTrains.ItemsSource = db.TrainTime.ToList();
        }

        private void btnTrains_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Всего проходит {dgTrains.Items.Count} поездов.");
        }

        private void addPosition_Click(object sender, RoutedEventArgs e)
        {
            WindowAddPosition window = new WindowAddPosition(db);
            window.ShowDialog();
            dgTrains.ItemsSource = null;
            dgTrains.ItemsSource = db.TrainTime.ToList();
        }
    }
}
