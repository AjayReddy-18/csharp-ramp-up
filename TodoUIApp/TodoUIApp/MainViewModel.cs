namespace TodoUIApp;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SQLite;
using System.Windows.Input;
using TodoApp;
using Task = TodoApp.Task;

public class MainViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Task> Tasks { get; } = new ObservableCollection<Task>();

    private readonly Todo _todo;
    private string _newTaskText;

    public string NewTaskText
    {
        get => _newTaskText;
        set
        {
            Console.WriteLine(value);
            if (_newTaskText != value)
            {
                _newTaskText = value;
                OnPropertyChanged(nameof(NewTaskText));
                ((RelayCommand)AddTaskCommand).RaiseCanExecuteChanged();
            }
        }
    }

    public ICommand AddTaskCommand { get; }

    public MainViewModel()
    {
        var dbPath = @"Data Source=C:\Users\fws-t\workspace\personal\cs\TodoUIApp\TodoUIApp\todo.db";
        var connection = new SQLiteConnection(dbPath);
        _todo = new Todo(connection);

        AddTaskCommand = new RelayCommand(AddTask, CanAddTask);

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

    private void AddTask()
    {
        _todo.AddTask(NewTaskText);
        NewTaskText = string.Empty;
        LoadTasks();
    }

    private bool CanAddTask()
    {
        Console.WriteLine("In can add task");
        return !string.IsNullOrWhiteSpace(NewTaskText);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
