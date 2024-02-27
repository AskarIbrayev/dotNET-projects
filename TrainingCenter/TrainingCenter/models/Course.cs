using System.Linq;
namespace TrainingCenter
{
    public class Course
    {
        public string Name { get; }
        public List<Lesson> Lessons { get; }
        public Course(string Name)
        {
            this.Name = Name;
            this.Lessons = new List<Lesson>();
        }
        public void AddLesson(Lesson lesson)
        {
            if (!Lessons.Contains(lesson))
            {
                Lessons.Add(lesson);
            }
            else 
            {
                throw new ArgumentException("The lesson already exists in the course");
            }
        }
    }
}