namespace TrainingCenter
{
    public class Teacher 
    {
        public string Name { get; }
        public string Surname { get; }
        public List<Course> Courses { get; }

        public Teacher(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
            this.Courses = new List<Course>();
        }

        public void GradeStudentsLesson(Student student, Course course, Lesson lesson, double gradeValue)
        {
            var studentCourse = student.Courses.Find(c => c.Name == course.Name);
            if (studentCourse == null) 
            {
                throw new ArgumentException($"Course is not found");
            }
            var courseLesson = studentCourse.Lessons.Find(l => l.Name == lesson.Name);
            if (courseLesson == null) 
            {
                throw new ArgumentException($"Lesson is not found");
            }
            student.GetLessonGrade(courseLesson, new Grade(gradeValue));
        }
    }
}