using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Ord
    {
        public int id { get; set; }
        public int client {  get; set; }
        public int room { get; set; }
        public DateTime date { get; set; }
        public int status { get; set; }

        private string st_type(int st)
        {
            switch (st)
            {
                case 1:
                    return "активный";
                case 2:
                    return "заблокированный";
                case 3:
                    return "создан заранее";
                case 4:
                    return "завершенный";
                default:
                    return "активный";
            }
        }
        public override string ToString()
        {
            return $"Номер заказа: {id}     Статус заказа: {st_type(status)}\n\nКомната №: {room}\nДата создания: {date.ToShortDateString()}";
        }
    }
}
