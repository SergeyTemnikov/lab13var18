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
using System.Windows.Shapes;

namespace lab13var18
{
    /// <summary>
    /// Логика взаимодействия для WindowAddPosition.xaml
    /// </summary>
    public partial class WindowAddPosition : Window
    {

        TrainsEntities db = new TrainsEntities();

        public WindowAddPosition(TrainsEntities db)
        {
            InitializeComponent();
            this.db=db;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            TimeSpan departureTime = new TimeSpan();
            TimeSpan arrivalTime = new TimeSpan();
            try
            {
                departureTime = TimeSpan.Parse(txbDepartureTime.Text);
                arrivalTime = TimeSpan.Parse(txbArrivalTime.Text);
            } catch 
            {
                MessageBox.Show("Неправильный формат времени.");
                return;
            }

            TrainTime trainTime = new TrainTime() {
                Number = int.Parse(txbNumber.Text),
                Direction = txbDirection.Text,
                Date = DateTime.Parse(dpDate.Text).Date,
                DepartureTime = departureTime,
                ArrivalTime = arrivalTime
            };

            try
            {
                db.TrainTime.Add(trainTime);
                db.SaveChanges();
                this.Close();
            }
            catch 
            {
                MessageBox.Show("Не удалось добавить позицию в расписание.");
            }

        }
    }
}
