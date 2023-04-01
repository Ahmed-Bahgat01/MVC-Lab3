using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentDeptMemoCRUD.Models
{
    public class StudentCourse
    {
        [Range(0, 100)]
        public int Grade { get; set; }

        // FKs and composite PK

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set;}

        // NAVIGATION PROPS

        public virtual Student? Student { get; set; }
        public virtual Course? Course { get; set; }


    }
}
