using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Hotel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Main : Window
    {
        List<Ord> ords = [];
        public Main()
        {
            InitializeComponent();
            Refresh(ref ords);
        }
        private List<Ord> Refresh(ref List<Ord> ords)
        {
            if (OrdList.Items.Count > 0 || ords.Count > 0)
            {
                OrdList.ItemsSource = null;
                ords.Clear();
                OrdList.Items.Clear();
            }

            try
            {
                MySqlConnection con = new(Database.con);

                con.Open();
                MySqlCommand com = new("SELECT * FROM `orders`", con);
                MySqlDataReader r = com.ExecuteReader();
                while (r.Read()) 
                    ords.Add(new Ord() { id = r.GetInt32(0), client = r.GetInt32(1), room = r.GetInt32(2), date = r.GetDateTime(3), status = r.GetInt32(4) });
                con.Close();

                OrdList.ItemsSource = ords;
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к базе данных. Проверьте соединение и повторите попытку.");
            }

            return ords;
        }

        private void DelBut_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r = MessageBox.Show("Хотите удалить запись?", "Удалить заказ", MessageBoxButton.YesNo);
            if (r == MessageBoxResult.Yes)
            {
                MySqlConnection con = new(Database.con);

                con.Open();
                MySqlCommand com = new(Database.DelCom_Ord(ords[OrdList.SelectedIndex].id), con);
                com.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Запись удалена.");
                Refresh(ref ords);
            }
        }

        private void AddBut_Click(object sender, RoutedEventArgs e)
        {
            OrdWin ordWin = new OrdWin();
            Hide();
            ordWin.ShowDialog();
            Refresh(ref ords);
            ShowDialog();
        }

        private void OrdList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OrdWin ordWin = new OrdWin(ords[OrdList.SelectedIndex].id);
            Hide();
            ordWin.ShowDialog();
            Refresh(ref ords);
            ShowDialog();
        }
    }
}