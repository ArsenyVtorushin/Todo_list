
using System.Runtime.CompilerServices;
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
        public AddTaskWindow windowAdd;
        public static List<ToDo> toDos;

        public MainWindow()
        {
            InitializeComponent();
            toDos = new List<ToDo>();

            toDos.Add(new ToDo("Приготовить покушать", new DateTime(2024, 1, 15).ToString("dd.MM.yyyy"), "Нет описания"));
            toDos.Add(new ToDo("Поработать", new DateTime(2024, 1, 20).ToString("dd.MM.yyyy"), "Съездить на совещание в Москву"));
            toDos.Add(new ToDo("Отдохнуть", new DateTime(2024, 2, 1).ToString("dd.MM.yyyy"), "Съездить в отпуск в Сочи"));

            dataGridToDo.ItemsSource = toDos;
            EndToDo();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            AddTaskWindow windowAdd = new AddTaskWindow();
            windowAdd.Owner = this;
            windowAdd.Show();
        }
        
        public void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            toDos.Remove(dataGridToDo.SelectedItem as ToDo);
            dataGridToDo.ItemsSource = null;
            dataGridToDo.ItemsSource = toDos;
            EndToDo();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (dataGridToDo.SelectedItem != null)
            {
                int idx = toDos.IndexOf(dataGridToDo.SelectedItem as ToDo);
                if (idx != -1) 
                    toDos[idx].Done = true;
            }
            EndToDo();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (dataGridToDo.SelectedItem != null)
            {
                int idx = toDos.IndexOf(dataGridToDo.SelectedItem as ToDo);
                if (idx != -1)
                    toDos[idx].Done = false;
            }
            EndToDo();
        }

        public void EndToDo()
        {
            progressBarToDo.Minimum = 0;
            progressBarToDo.Maximum = toDos.Count;
            progressBarToDo.Value = toDos.Where(t => t.Done).Count();
            value.Text = progressBarToDo.Value.ToString();
            maximum.Text = progressBarToDo.Maximum.ToString();
        }
    }
}