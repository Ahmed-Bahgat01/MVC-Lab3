using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentDeptMemoCRUD.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; }
        [Required, StringLength(20,MinimumLength =3)]
        public string Name { get; set; }

        public string? ImageName { get; set; }

        [NotMapped, DisplayName("Upload File")]
        public IFormFile? ImageFile { get; set; }

        // FKs
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }


        // NAVIGATION PROPS
        public virtual Department? Department { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
        //public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();

        public Student()
        {
            Id = 0;
            Name = "NONAME";
        }

        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
