using Dapper;
using System.Data.SQLite;

namespace TodoApp
{
    internal class Todo : ITodo
    {
        private readonly SQLiteConnection _connection;

        public Todo(SQLiteConnection connection)
        {
            _connection = connection;
        }

        public async Task AddTaskAsync(string title)
        {
            var sql = "INSERT INTO todo(title) VALUES (@Title);";
            await _connection.ExecuteAsync(sql, new { Title = title });
        }

        public async Task<List<TaskItem>> GetAllTasksAsync()
        {
            var sql = "SELECT * FROM todo;";
            var tasks = await _connection.QueryAsync<TaskItem>(sql);
            return tasks.ToList();
        }

        public async Task<List<TaskItem>> SearchTasksAsync(string keyword)
        {
            var sql = "SELECT * FROM todo WHERE title LIKE @Keyword;";
            var tasks = await _connection.QueryAsync<TaskItem>(sql, new { Keyword = $"%{keyword}%" });
            return tasks.ToList();
        }
    }
}
