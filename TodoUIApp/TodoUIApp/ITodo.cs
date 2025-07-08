namespace TodoApp
{
    internal interface ITodo
    {
        Task AddTaskAsync(string title);
        Task<List<TaskItem>> GetAllTasksAsync();
        Task<List<TaskItem>> SearchTasksAsync(string keyword);
    }
};
