namespace innovation_dev_Task.Domain.Entities
{
    public class Student : BaseClass
    {
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public Student()
        {
            Subjects = new List<Subject>();
        }

    }
}
