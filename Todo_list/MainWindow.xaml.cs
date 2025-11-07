
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
        public static List<ToDo> ToDos;

        public MainWindow()
        {
            InitializeComponent();
            ToDos = new List<ToDo>();

            ToDos.Add(new ToDo("Приготовить покушать", new DateTime(2024, 1, 15).ToString("d"), "Нет описания"));
            ToDos.Add(new ToDo("Поработать", new DateTime(2024, 1, 20).ToString("d"), "Съездить на совещание в Москву"));
            ToDos.Add(new ToDo("Отдохнуть", new DateTime(2024, 2, 1).ToString("d"), "Съездить в отпуск в Сочи"));

            dataGridToDo.ItemsSource = ToDos;
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            AddTaskWindow windowAdd = new AddTaskWindow();
            windowAdd.Owner = this;
            windowAdd.Show();
        }
                
    }
}