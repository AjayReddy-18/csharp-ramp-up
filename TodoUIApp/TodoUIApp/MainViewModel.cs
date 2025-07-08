using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using TodoApp;
using TaskItem = TodoApp.TaskItem;

namespace TodoUIApp;

public partial class MainViewModel : ObservableObject
{
    public ObservableCollection<TaskItem> Tasks { get; } = new();
    public event EventHandler<TaskItem>? TaskAdded;

    private readonly Todo _todo;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddTaskCommand))]
    private string newTaskText = string.Empty;

    public MainViewModel()
    {
        var dbPath = @"Data Source=C:\Users\fws-t\workspace\personal\cs\TodoUIApp\TodoUIApp\todo.db";
        var connection = new SQLiteConnection(dbPath);
        _todo = new Todo(connection);

        LoadTasksAsync();
    }

    private async Task LoadTasksAsync()
    {
        Tasks.Clear();
        foreach (var task in await _todo.GetAllTasksAsync())
        {
            Tasks.Add(task);
        }
    }

    [RelayCommand(CanExecute = nameof(CanAddTask))]
    private async Task AddTaskAsync()
    {
        await _todo.AddTaskAsync(NewTaskText);

        var allTasks = await _todo.GetAllTasksAsync();
        var newTask = allTasks.LastOrDefault();

        NewTaskText = string.Empty;
        await LoadTasksAsync();

        if (newTask is not null)
        {
            TaskAdded?.Invoke(this, newTask);
        }
    }


    private bool CanAddTask() => !string.IsNullOrWhiteSpace(NewTaskText);
}
