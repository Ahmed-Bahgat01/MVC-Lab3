using System.ComponentModel.DataAnnotations;

namespace StudentDeptMemoCRUD.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; }
        [Required, StringLength(20,MinimumLength =3)]
        public string Name { get; set; }

        // NAVIGATION PROPS
        public virtual Department Department { get; set; }

        public Student()
        {
            Id = -1;
            Name = "NONAME";
        }

        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
