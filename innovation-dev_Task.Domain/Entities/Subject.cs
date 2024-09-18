namespace innovation_dev_Task.Domain.Entities
{
    public class Subject :BaseClass
    {
        public ICollection<Student> Students { get; set; }
        public Subject() 
        {
            Students = new List<Student>();
        }
    }
    
}
