using MySql.Data.MySqlClient;
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

namespace Hotel
{
    /// <summary>
    /// Логика взаимодействия для OrdWin.xaml
    /// </summary>
    public partial class OrdWin : Window
    {
        private List<string> temp = [];
        private List<int> temp2 = [];
        private List<string> temp3 = [];

        private int id = 0;
        private List<rooms> list = [];
        public OrdWin()
        {
            InitializeComponent();
            Refresh(ref list);
            ComboBoxRefresh();
            ActBut.Content = "Добавить";
        }
        public OrdWin(int ID)
        {
            InitializeComponent();
            id = ID;
            Refresh(ref list);
            ComboBoxRefresh();
            ActBut.Content = "Изменить";
        }
        private List<rooms> Refresh(ref List<rooms> list)
        {
            if (list.Count > 0 || RoomList.Items.Count > 0)
            {
                RoomList.ItemsSource = null;
                RoomList.Items.Clear();
                list.Clear();
            }
            try
            {
                MySqlConnection con = new(Database.con);

                con.Open();
                MySqlCommand cmd = new("SELECT `ID` FROM `rooms`", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                    list.Add(new rooms(dr.GetInt32(0)));
                con.Close();

                RoomList.ItemsSource = list;
            }
            catch
            {
                MessageBox.Show("Нет подключения к серверам.");
            }
            return list;
        }
        private void ComboBoxRefresh()
        {
            if (temp.Count > 0 && temp2.Count > 0 && temp3.Count > 0)
            {
                clientBox.ItemsSource = null;
                roomBox.ItemsSource = null;
                statusBox.ItemsSource = null;

                clientBox.Items.Clear();
                roomBox.Items.Clear();
                statusBox.Items.Clear();

                temp.Clear();
                temp2.Clear();
                temp3.Clear();
            }

            MySqlConnection con = new(Database.con);

            try
            {
                con.Open();
                MySqlCommand cmd = new($"SELECT `name` FROM `client`", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                    temp.Add(dr.GetString(0));
                con.Close();

                con.Open();
                cmd = new($"SELECT `ID` FROM `rooms`", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                    temp2.Add(dr.GetInt32(0));
                con.Close();

                con.Open();
                cmd = new($"SELECT `name` FROM `status`", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                    temp3.Add(dr.GetString(0));
                con.Close();
            }
            catch
            {
                MessageBox.Show("Нет подключения к серверам.");
            }

            if(id != 0)
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = new(Database.ReadCom_Ord(id), con);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        clientBox.SelectedIndex = dr.GetInt32(1)-1;
                        roomBox.SelectedIndex = dr.GetInt32(2)-1;
                        statusBox.SelectedIndex = dr.GetInt32(4)-1;
                    }
                    con.Close();
                }
                catch
                {
                    MessageBox.Show("Нет подключения к серверам.");
                }
            }

            clientBox.ItemsSource = temp;
            roomBox.ItemsSource = temp2;
            statusBox.ItemsSource = temp3;
        }

        private void WinClose()
        {
            clientBox.ItemsSource = null;
            roomBox.ItemsSource = null;
            statusBox.ItemsSource = null;

            clientBox.Items.Clear();
            roomBox.Items.Clear();
            statusBox.Items.Clear();

            temp.Clear();
            temp2.Clear();
            temp3.Clear();
        }

        private void ActBut_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection conn = new(Database.con);

            try
            {
                if (id > 0)
                {
                    conn.Open();
                    MySqlCommand cmd = new(Database.UptCom_Ord(id, clientBox.SelectedIndex + 1, roomBox.SelectedIndex + 1, DateTime.Now, statusBox.SelectedIndex + 1), conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    WinClose();
                    
                    MessageBox.Show("Изменено успешно.");
                    Close();
                }
                else
                {
                    conn.Open();
                    MySqlCommand cmd = new(Database.CreateCom_Ord(clientBox.SelectedIndex + 1, roomBox.SelectedIndex + 1, DateTime.Now, statusBox.SelectedIndex + 1), conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    WinClose();
                    
                    MessageBox.Show("Добавлено успешно.");
                    Close();
                }
            }
            catch
            {
                MessageBox.Show("Нет подключения к серверам.");
            }
        }

        private void BackBut_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
