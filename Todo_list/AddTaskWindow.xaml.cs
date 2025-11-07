using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Todo_list
{
    /// <summary>
    /// Interaction logic for AddTaskWindow.xaml
    /// </summary>
    public partial class AddTaskWindow : Window
    {
        public AddTaskWindow()
        {
            InitializeComponent();
        }

        private void SaveTask_Click(object sender, RoutedEventArgs e)
        {
            string title = titleToDo.Text;
            string date = dateToDo.Text;
            string description = descriptionToDo.Text;
            
            if (title == "")
                title = "Без названия";
            if (date == "")
                date = DateTime.Now.ToString("dd.MM.yyyy");
            if (description == "")
                description = "Описания нет";

            MainWindow.toDos.Add(new ToDo(title, date, description));
            (this.Owner as MainWindow).dataGridToDo.ItemsSource = null;
            (this.Owner as MainWindow).dataGridToDo.ItemsSource = MainWindow.toDos;

            titleToDo.Text = null;
            dateToDo.SelectedDate = null;
            descriptionToDo.Text = null;

            this.Close();
        }
    }
}
