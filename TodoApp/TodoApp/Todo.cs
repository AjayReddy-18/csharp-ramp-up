using Newtonsoft.Json;

namespace TodoApp
{
    internal class Todo
    {
        public List<Task> tasks = new List<Task>();
        private int nextTaskId;

        public Todo()
        {
            nextTaskId = 1;
        }

        public void AddTask(string title)
        {
            tasks.Add(new Task(nextTaskId, title));
            nextTaskId++;
        }

        public string GetAllTasks()
        {
            return JsonConvert.SerializeObject(tasks, Formatting.Indented);
        }
    }
};
