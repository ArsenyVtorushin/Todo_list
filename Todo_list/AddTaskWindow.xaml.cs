using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var owner = (this.Owner as MainWindow);

            string title = titleToDo.Text;
            DateTime? date = dateToDo.SelectedDate;
            string description = descriptionToDo.Text;
            
            if (title == "")
                title = "Без названия";
            if (date == null)
                date = DateTime.Now.Date;
            if (description == "")
                description = "Описания нет";

            MainWindow.toDos.Add(new ToDo(title, date, description));
            owner.listBoxToDo.ItemsSource = null;
            owner.listBoxToDo.ItemsSource = MainWindow.toDos;

            titleToDo.Text = null;
            dateToDo.SelectedDate = null;
            descriptionToDo.Text = null;

            // stupid stuff btw
            owner.progressBarToDo.Maximum = owner.listBoxToDo.Items.Count;
            owner.value.Text = owner.progressBarToDo.Value.ToString();
            owner.maximum.Text = owner.progressBarToDo.Maximum.ToString();

            this.Close();
        }
    }
}
