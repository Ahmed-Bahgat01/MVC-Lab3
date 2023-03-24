namespace StudentDeptMemoCRUD.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

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
