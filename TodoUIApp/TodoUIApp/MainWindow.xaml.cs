namespace TodoUIApp;

using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Windows;
using TodoApp;
using Task = TodoApp.Task;

public partial class MainWindow : Window
{
    public ObservableCollection<Task> Tasks { get; set; } = new ObservableCollection<Task>();

    private readonly Todo _todo;

    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;

        var dbPath = @"Data Source=C:\Users\fws-t\workspace\personal\cs\TodoUIApp\TodoUIApp\todo.db";
        var connection = new SQLiteConnection(dbPath);
        _todo = new Todo(connection);

        LoadTasks();
    }

    private void LoadTasks()
    {
        Tasks.Clear();
        foreach (var task in _todo.GetAllTasks())
        {
            Tasks.Add(task);
        }
    }

    private void AddTask_Click(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(TaskInput.Text))
        {
            _todo.AddTask(TaskInput.Text);
            TaskInput.Clear();
            LoadTasks();
        }
    }
}
