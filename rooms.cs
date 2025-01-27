using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel
{
    class rooms
    {
        public int Number { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        

        public rooms(int id)
        {
            Number = id;
            MySqlConnection con = new(Database.con);
            try
            {
                con.Open();
                MySqlCommand cmd = new($"SELECT `status` FROM `orders` WHERE `room-ID`={id}", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    switch (dr.GetInt32(0))
                    {
                        case 1:
                            Status = "занята";
                            break;
                        case 2:
                            Status = "Свободна";
                            break;
                        case 3:
                            Status = "Занята";
                            break;
                        case 4:
                            Status = "Свободна";
                            break;
                        default:
                            Status = "Свободна";
                            break;
                    }
                }
                else Status = "Свободна";
                con.Close();

                con.Open();
                cmd = new($"SELECT `ppl-amount` FROM `rooms` WHERE `ID`={id}", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    switch (dr.GetInt32(0))
                    {
                        case 1:
                            Size = "SGL";
                            break;
                        case 2:
                            Size = "DBL";
                            break;
                        case 3:
                            Size = "TWN";
                            break;
                        case 4:
                            Size = "DBL + EXB";
                            break;
                        case 5:
                            Size = "TRPL";
                            break;
                        case 6:
                            Size = "QDPL";
                            break;
                        case 7:
                            Size = "5 ADL";
                            break;
                        default:
                            Size = "SGL";
                            break;
                    }
                }
                else Size = "UNKNOWN";
                con.Close();

                con.Open(); cmd = new($"SELECT `room-type` FROM `rooms` WHERE `ID` = {id}", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    switch (dr.GetInt32(0))
                    {
                        case 1:
                            Type = "Standard";
                            break;
                        case 2:
                            Type = "Superior";
                            break;
                        case 3:
                            Type = "De luxe";
                            break;
                        case 4:
                            Type = "President";
                            break;
                        default:
                            Type = "UNKNOWN";
                            break;
                    }
                }
                else Type = "UNKNOWN";
                con.Close();
            }
            catch
            {
                MessageBox.Show("Нет подключения к серверам.");
            }
        }
    }
}
