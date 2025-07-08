using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using TodoApp;
using Task = TodoApp.Task;

namespace TodoUIApp;

public partial class MainViewModel : ObservableObject
{
    public ObservableCollection<Task> Tasks { get; } = new();

    private readonly Todo _todo;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddTaskCommand))]
    private string newTaskText = string.Empty;

    public MainViewModel()
    {
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

    [RelayCommand(CanExecute = nameof(CanAddTask))]
    private void AddTask()
    {
        _todo.AddTask(NewTaskText);
        NewTaskText = string.Empty;
        LoadTasks();
    }

    private bool CanAddTask() => !string.IsNullOrWhiteSpace(NewTaskText);
}
