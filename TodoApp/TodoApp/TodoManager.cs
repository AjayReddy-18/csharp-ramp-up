namespace TodoApp
{
    internal class TodoManager
    {
        private readonly Todo todo;

        public TodoManager(Todo todo)
        {
            this.todo = todo;
        }

        private void Prompt()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Todo App");
            Console.WriteLine("choose your operation");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View All Tasks");
        }

        private string ReadInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public void Start()
        {
            while (true)
            {
                Prompt();
                var input = ReadInput("Enter your choice: ");
                var choice = int.Parse(input);
                PerformOperation(choice);
                Console.ReadLine();
            }
        }

        private void PerformOperation(int choice)
        {
            if (choice == 1)
            {
                var title = ReadInput("Enter task title: ");
                todo.AddTask(title);
                Console.WriteLine("Task added successfully");
                return;
            }

            if (choice == 2)
            {
                PrintTasks();
                return;
            }

            Console.WriteLine("Invalid choice, Try Again!");
        }

        private void PrintTasks()
        {
            Console.Clear();
            Console.WriteLine(string.Join("\t", "TaskId", "Title", "Done"));

            foreach (var task in todo.tasks)
            {
                Console.WriteLine(string.Join("\t", task.TaskId, task.Title, task.Done));
            }
        }
    }
    }
