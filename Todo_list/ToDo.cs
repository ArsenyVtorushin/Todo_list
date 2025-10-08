using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Todo_list
{
    public class ToDo
    {
        private string _title;
        private DateTime _date;
        private string _description;

        public ToDo(string title, DateTime date, string description)
        {
            _title = title;
            _date = date;
            _description = description;
        }

        public string Title { get { return _title; } set { _title = value; } }
        public DateTime Date { get { return _date; } set { _date = value; } }
        public string Description { get { return _description;} set { _description = value; } }
    }
}
