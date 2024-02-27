namespace TrainingCenter
{
    public class TCenter 
    {
        private List<Teacher> teachers;
        private List<Student> students;
        private List<Course> courses;
        public System.Collections.ObjectModel.ReadOnlyCollection<Teacher> Teachers
        {
            get { return teachers.AsReadOnly(); }
        }
        public System.Collections.ObjectModel.ReadOnlyCollection<Student> Students
        {
            get { return students.AsReadOnly(); }
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Course> Courses
        {
            get { return courses.AsReadOnly(); }
        }

        public TCenter()
        {
            teachers = new List<Teacher>();
            students = new List<Student>();
            courses = new List<Course>();
        }
        public void AddTeacher(Teacher teacher)
        {
            teachers.Add(teacher);
        }
        public void AddStudent(Student student)
        {
            students.Add(student);
        }
        public void AddCourse(Course course)
        {
            courses.Add(course);
        }

        public void AddCourseToTeacher (Teacher teacher, Course course)
        {
            teacher.Courses.Add(course);
        }
        public void AddCourseToStudent(Student student, Course course)
        {
            student.Courses.Add(course);
        }

        public void CalculateStudentCourseGrades(Student student)
        {
            foreach (var course in student.Courses)
            {
                var courseGrade = new Grade(course.Lessons.Aggregate(0.0, (total, lesson) => total + student.LessonGrades[lesson].GradeValue)/course.Lessons.Count());
                student.GetCourseGrade(course, courseGrade);
            }
        }

    }   
}