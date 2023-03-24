namespace StudentDeptMemoCRUD.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Capacity { get; set; }

        public Department()
        {
            Id= 0;
            Name = null;
            Capacity = 0;
        }
        public Department(int id, string? name, int capacity)
        {
            Id = id;
            Name = name;
            Capacity = capacity;
        }
    }
}
