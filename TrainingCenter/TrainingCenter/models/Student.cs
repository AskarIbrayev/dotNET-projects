namespace TrainingCenter
{
    public class Student 
    {
        public string Name { get; }
        public string Surname { get; }
        public List<Course> Courses { get; }
        
        private Dictionary<Course, Grade> courseGrades = new Dictionary<Course, Grade>();
        public System.Collections.ObjectModel.ReadOnlyDictionary<Course, Grade> CourseGrades
        {
            get { return courseGrades.AsReadOnly(); }
        }
        private Dictionary<Lesson, Grade> lessonGrades = new Dictionary<Lesson, Grade>();
        public System.Collections.ObjectModel.ReadOnlyDictionary<Lesson, Grade> LessonGrades
        {
            get { return lessonGrades.AsReadOnly(); }
        }
        public Student(string Name, string Surname)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Courses = new List<Course>();
        }
        public void GetCourseGrade(Course course, Grade grade)
        {
            courseGrades.Add(course, grade);
        }
        public void GetLessonGrade(Lesson courseLesson, Grade grade)
        {
            lessonGrades.Add(courseLesson, grade);
        }
    }
}