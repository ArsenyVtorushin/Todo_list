
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