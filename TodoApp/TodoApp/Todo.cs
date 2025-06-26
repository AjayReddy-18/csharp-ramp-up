using Dapper;
using System.Data.SQLite;

namespace TodoApp
{
    internal class Todo
    {
        public List<Task> tasks = new List<Task>();
        private readonly SQLiteConnection _connection;

        public Todo(SQLiteConnection connection)
        {
            _connection = connection;
        }

        public void AddTask(string title)
        {
            var sql = $"INSERT INTO todo(title) VALUES('{title}');";
            _connection.Query(sql);
        }

        public List<Task> GetAllTasks()
        {
            var sql = "SELECT * FROM todo;";
            return _connection.Query<Task>(sql).ToList();
        }
    }
};
