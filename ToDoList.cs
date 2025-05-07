namespace ToDo
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ToDoItem> Items { get; set; } = new();
        public override string ToString() => Name;
    }
}
