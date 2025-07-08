using System.Windows;
using TodoApp;
namespace TodoUIApp;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var vm = new MainViewModel();
        vm.TaskAdded += OnTaskAdded;
        DataContext = vm;
    }

    private void OnTaskAdded(object? sender, TaskItem e)
    {
        MessageBox.Show($"New task added: {e.Title}", "Task Added");
    }
}