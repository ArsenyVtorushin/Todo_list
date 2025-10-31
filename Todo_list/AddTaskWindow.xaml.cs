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
            DateTime date = DateTime.Parse(dateToDo.Text);
            string description = descriptionToDo.Text;
            MainWindow.ToDos.Add(new ToDo(title, date, description));

            (this.Owner as MainWindow).dataGridToDo.ItemsSource = MainWindow.ToDos;
            this.Close();
        }
    }
}
