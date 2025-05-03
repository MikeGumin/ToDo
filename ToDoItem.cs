namespace ToDo
{
    public class ToDoItem
    {
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public override string ToString() => IsCompleted ? $"[v] {Title}" : $"[ ] {Title}";
    }
}
