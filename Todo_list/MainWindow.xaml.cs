
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

namespace Todo_list
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            dateToDo.SelectedDate = new DateTime(2024, 01, 10);
            descriptionToDo.Text = "Описания нет";

            groupBoxToDo.Visibility = Visibility.Hidden;

            toDos = new List<ToDo>()
            {
                new ToDo("Приготовить покушать", new DateTime(2024, 01, 15), "Описания нет"),
                new ToDo("Поработать", new DateTime(2024, 01, 20), "Съездить на совещание в Москву"),
                new ToDo("Отдохнуть", new DateTime(2024, 02, 01), "Съездить в отпуск в Сочи")
            };
            listToDo.ItemsSource = toDos;
        }
        
        public List<ToDo> toDos;


        private void AddTaskMode_Checked(object sender, RoutedEventArgs e)
        {
            groupBoxToDo.Visibility = Visibility.Visible;
        }

        private void AddTaskMode_Unchecked(object sender, RoutedEventArgs e)
        {
            groupBoxToDo.Visibility = Visibility.Hidden;
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            DateTime? selectedDate = dateToDo.SelectedDate;
            toDos.Add(new ToDo(titleToDo.Text, selectedDate.Value, descriptionToDo.Text));
            titleToDo.Text = null;
            descriptionToDo.Text = "Описания нет";
            listToDo.ItemsSource = null;
            listToDo.ItemsSource = toDos;
        }

        private void RemoveTask_Click(object sender, RoutedEventArgs e)
        {
            toDos.Remove(listToDo.SelectedItem as ToDo);
            listToDo.ItemsSource = null;
            listToDo.ItemsSource = toDos;
        }
    }
}