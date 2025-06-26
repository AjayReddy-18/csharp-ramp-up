using System.Data.SQLite;

namespace TodoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cs = @"Data Source=C:\Users\fws-t\workspace\personal\cs\TodoApp\TodoApp\" + args[0];
            using (var connection = new SQLiteConnection(cs))
            {
                var todo = new Todo(connection);
                var todoManager = new TodoManager(todo);
                todoManager.Start();
            }
        }
    }
}
