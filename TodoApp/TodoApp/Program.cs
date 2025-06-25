using System.Collections.Concurrent;

namespace TodoApp
{
        internal class Program
        {
            static void Main(string[] args)
            {
                var todo = new Todo();
                var todoManager = new TodoManager(todo);
                todoManager.Start();
            }
        }
    }
