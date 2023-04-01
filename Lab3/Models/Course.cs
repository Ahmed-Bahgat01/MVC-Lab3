using System.ComponentModel.DataAnnotations;

namespace StudentDeptMemoCRUD.Models
{
    public class Course
    {
        [Required,Key]
        public int Id { get; set; }

        [Required, StringLength(10, MinimumLength = 2)]
        public string? Name { get; set; }

        [Required, Range(9, 18)]
        public int LectureHours { get; set; }

        [Required, Range(9, 18)]
        public int LabHours { get; set; }

        // NAVIGATION PROPS
        public virtual ICollection<Department> Departments { get; set; } = new HashSet<Department>();
        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
        //public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}
