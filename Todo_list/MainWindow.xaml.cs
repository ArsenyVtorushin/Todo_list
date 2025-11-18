
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
        public int ItemsCount => listBoxToDo.Items?.Count ?? 0;
        public int CompletedItemsCount
        {
            get
            {
                if (listBoxToDo.Items == null) return 0;
                int completed = 0;
                foreach (var item in listBoxToDo.Items)
                {
                    if ((item as ToDo).Done) completed++;
                }
                return completed;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            toDos = new List<ToDo>();

            toDos.Add(new ToDo("Приготовить покушать", new DateTime(2024, 1, 15).ToString("dd.MM.yyyy"), "Нет описания"));
            toDos.Add(new ToDo("Поработать", new DateTime(2024, 1, 20).ToString("dd.MM.yyyy"), "Съездить на совещание в Москву"));
            toDos.Add(new ToDo("Отдохнуть", new DateTime(2024, 2, 1).ToString("dd.MM.yyyy"), "Съездить в отпуск в Сочи"));

            listBoxToDo.ItemsSource = toDos;
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
            toDos.Remove((sender as Button).DataContext as ToDo);
            listBoxToDo.ItemsSource = null;
            listBoxToDo.ItemsSource = toDos;

            EndToDo();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (listBoxToDo.SelectedItem != null)
            {
                int idx = toDos.IndexOf((sender as CheckBox).DataContext as ToDo);
                if (idx != -1) 
                    toDos[idx].Done = true;
            }
            EndToDo();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).DataContext as ToDo != null)
            {
                int idx = toDos.IndexOf((sender as CheckBox).DataContext as ToDo);
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