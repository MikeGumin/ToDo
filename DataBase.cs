
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.Data.Sqlite;

namespace ToDo
{
    public static class DataBase
    {
        private static readonly string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ToDo", "todo.db");
        private static readonly string connectionString = $"Data Source={dbPath}";
        public static void Initialize()
        {
            // Создаём директорию, если нужно 
            Directory.CreateDirectory(Path.GetDirectoryName(dbPath)!);
            // Записываем адрес базы данных где хранятся наши таблицы
            using var conn = new SqliteConnection(connectionString);
            conn.Open();

            // Создаем в базе данных таблицы, если их там нет
            var cmd = conn.CreateCommand();
            cmd.CommandText = @" 
            CREATE TABLE IF NOT EXISTS ToDoLists ( 
                Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                Name TEXT NOT NULL 
            ); 
            CREATE TABLE IF NOT EXISTS ToDoItems ( 
                Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                Title TEXT NOT NULL, 
                IsCompleted INTEGER NOT NULL DEFAULT 0, 
                ListId INTEGER NOT NULL, 
                FOREIGN KEY (ListId) REFERENCES ToDoLists(Id) ON DELETE CASCADE 
            );";
            cmd.ExecuteNonQuery();
        }
        //Выводим все строки из ToDoList и записываем их в ComboBox
        public static List<ToDoList> GetAllLists()
        {
            var result = new List<ToDoList>();
            using var conn = new SqliteConnection(connectionString);
            conn.Open();
            
            var cmd = new SqliteCommand("Select Id, Name From ToDoLists", conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read()) {
                result.Add(new ToDoList {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Items = GetTaskForList(reader.GetInt32(0))
                });
            }

            conn.Close();

            return result;
        }
        //Выводим все строки из ToDoItems и записываем их в ListBox
        public static List<ToDoItem> GetTaskForList(int listId)
        {
            var tasks = new List<ToDoItem>();
            using var conn = new SqliteConnection(connectionString);
            conn.Open();

            using var cmd = new SqliteCommand("Select Id, Title, IsCompleted from ToDoItems where ListId = @listId", conn);
            cmd.Parameters.AddWithValue("@listId", listId);

            using var reader = cmd.ExecuteReader();

            while (reader.Read()) 
            {
                tasks.Add(new ToDoItem
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    IsCompleted = reader.GetInt32(2) == 1
                });
            }

            conn.Close();

            return tasks;
        }
        //Добавляем новый список дел в таблицу ToDoList
        public static void AddList(string name)
        {
            using var conn = new SqliteConnection(connectionString);
            conn.Open();

            var cmd = new SqliteCommand("insert into ToDoLists (Name) Values (@name)", conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        //Добавляем новую задачу в таблицу ToDoItems
        public static void AddTask(int listId, string title) {
            using var conn = new SqliteConnection(connectionString);
            conn.Open();

            var cmd = new SqliteCommand("insert into ToDoItems (Title, IsCompleted, ListId) Values (@title, 0, @listId)", conn);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@listId", listId);
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        //Удаляем выбранный список дел из таблицы ToDoList вместе со всеми его задачами в ToDoItems
        public static void DeleteList(int listId) {
            using var conn = new SqliteConnection(connectionString);
            conn.Open();

            var deleteTasks = new SqliteCommand("delete From ToDoItems where ListId = @id", conn);
            deleteTasks.Parameters.AddWithValue("@id", listId);
            deleteTasks.ExecuteNonQuery();

            var deleteList = new SqliteCommand("Delete From ToDoLists where Id = @id", conn);
            deleteList.Parameters.AddWithValue("@id", listId);
            deleteList.ExecuteNonQuery();

            conn.Close();
        }
        //Удаляем выбранную задачу из перечня из ToDoItems
        public static void DeleteTasks(int taskId) {
            using var conn = new SqliteConnection(connectionString);
            conn.Open();

            var cmd = new SqliteCommand("delete From ToDoItems where Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", taskId);
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        //Обновляем название списка дел
        public static void UpdateListName(int listId, string newName)
        {
            using var conn = new SqliteConnection(connectionString);
            conn.Open();

            var cmd = new SqliteCommand("Update ToDoLists set Name = @name Where id = @id", conn);
            cmd.Parameters.AddWithValue("@name", newName);
            cmd.Parameters.AddWithValue("@id", listId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //Обновляем название выбранной задачи
        public static void UpdateTaskName(int taskId, string newTitle, bool isCompleted)
        {
            using var conn = new SqliteConnection(connectionString);
            conn.Open();

            var cmd = new SqliteCommand("Update ToDoItems set Title = @name, IsCompleted = @isCompleted Where Id = @id", conn);
            cmd.Parameters.AddWithValue("@name", newTitle);
            cmd.Parameters.AddWithValue("@isCompleted", isCompleted ? 1 : 0);
            cmd.Parameters.AddWithValue("@id", taskId);
            cmd.ExecuteNonQuery();
            
            conn.Close();
        }
    }
}
