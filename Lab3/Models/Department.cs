using System.ComponentModel.DataAnnotations;

namespace StudentDeptMemoCRUD.Models
{
    public class Department
    {
        [Required]
        public int Id { get; set; }
        [Required, StringLength(10, MinimumLength = 3)]
        public string? Name { get; set; }
        [Required, Range(100, 500)]
        public int Capacity { get; set; }

        // NAVIGATION PROPS

        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();

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
