using System.ComponentModel.DataAnnotations;

namespace StudentDeptMemoCRUD.Models
{
    public class Course
    {
        [Required,Key]
        public int Id { get; set; }
        [Required, StringLength(10, MinimumLength = 2)]
        public string? Name { get; set; }

        // NAVIGATION PROPS
        public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
    }
}
