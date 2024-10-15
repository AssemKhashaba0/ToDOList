namespace ToDOList.Models
{
    public class ToDoListEf
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string fileName { get; set; }
        public bool? IsCompleted { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime Dateline { get; set;} 

    }
}
