﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentDeptMemoCRUD.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; }
        [Required, StringLength(20,MinimumLength =3)]
        public string Name { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        // NAVIGATION PROPS
        public virtual Department? Department { get; set; }

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
