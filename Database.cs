using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Database
    {
        public const string con = "server=127.0.0.1;port=3306;userid=root;password=root;database=ohta_park";

        public static string CreateCom_Ord(int client, int room, DateTime date, int status)
        {
            return $"INSERT INTO `orders` (`client-ID`, `room-ID`, `order-Date`, `status`) VALUES ({client}, {room}, '{date:yyyy-MM-dd}', {status})";
        }
        public static string ReadCom_Ord()
        {
            return "SELECT * FROM `orders`";
        }
        public static string ReadCom_Ord(int id)
        {
            return $"SELECT * FROM `orders` WHERE `ID`={id}";
        }
        public static string UptCom_Ord(int id, int client, int room, DateTime date, int status)
        {
            return $"UPDATE `orders` SET `client-ID`={client},`room-ID`={room},`order-Date`='{date:yyyy-MM-dd}',`status`={status} WHERE `ID` = {id}";
        }
        public static string DelCom_Ord(int id)
        {
            return $"DELETE FROM `orders` WHERE `ID`={id}";
        }
        public static string ReadCom_Room()
        {
            return "SELECT * FROM `rooms`";
        }

    }
}
