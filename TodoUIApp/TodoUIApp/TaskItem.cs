namespace TodoApp
{
    public class TaskItem
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public int Done { get; set; }
        public bool IsCompleted
        {
            get => Done == 1;
            set => Done = value ? 1 : 0;
        }
    }
};
