namespace TodoApp
{
    internal class Task
    {
        public Task(int taskId, string title)
        {
            TaskId = taskId;
            Title = title;
            Done = false;
        }

        public int TaskId { get; }
        public string Title { get; }
        public bool Done { get; }
    }
};
