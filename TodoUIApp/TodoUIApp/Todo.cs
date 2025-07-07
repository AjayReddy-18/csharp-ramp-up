using Dapper;
using System.Data.SQLite;

namespace TodoApp
{
    internal class Todo : ITodo
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
            _connection.Execute(sql);
        }

        public List<Task> GetAllTasks()
        {
            var sql = "SELECT * FROM todo;";
            return [.. _connection.Query<Task>(sql)];
        }

        public List<Task> SearchTasks(string keyword)
        {
            var sql = $"SELECT * FROM todo WHERE title LIKE '%{keyword}%'";
            return [.. _connection.Query<Task>(sql)];
        }
    }
};
