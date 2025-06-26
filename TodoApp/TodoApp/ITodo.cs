namespace TodoApp
{
    internal interface ITodo
    {
        void AddTask(string title);
        List<Task> GetAllTasks();
        List<Task> SearchTasks(string keyword);
    }
};
