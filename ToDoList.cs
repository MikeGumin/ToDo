namespace ToDo
{
    public class ToDoList
    {
        public string Name { get; set; }
        public List<ToDoItem> Items { get; set; } = new List<ToDoItem>();
        public override string ToString() => Name;
    }
}
