namespace TrainingCenter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var student1 = new Student("Askar", "Ibrayev");
            var student2 = new Student("Ivan", "Ivanov");
            var courseReact = new Course ("React-1");
            var courseNet = new Course ("DotNet-4");
            var reactLesson1 = new Lesson("Redux");
            var reactLesson2 = new Lesson("Hooks");
            var netLesson1 = new Lesson("LINQ");
            var netLesson2 = new Lesson("Delegates");

            var tCenter = new TCenter();

            tCenter.AddTeacher(new Teacher("Jonh", "Smith"));

            tCenter.AddStudent(new Student("Askar", "Ibrayev"));
            tCenter.AddStudent(new Student("Ivan", "Ivanov"));

            tCenter.AddCourse(courseReact);
            tCenter.AddCourse(courseNet);

            tCenter.Courses[0].AddLesson(reactLesson1);
            tCenter.Courses[0].AddLesson(reactLesson2);
            tCenter.Courses[1].AddLesson(netLesson1);
            tCenter.Courses[1].AddLesson(netLesson2);
            
            tCenter.AddCourseToStudent(tCenter.Students[0], courseReact);
            tCenter.AddCourseToStudent(tCenter.Students[0], courseNet);
            tCenter.AddCourseToStudent(tCenter.Students[1], courseReact);
            tCenter.AddCourseToStudent(tCenter.Students[1], courseNet);

            tCenter.Teachers[0].GradeStudentsLesson(tCenter.Students[0], tCenter.Courses[0], tCenter.Courses[0].Lessons[0], 100);
            tCenter.Teachers[0].GradeStudentsLesson(tCenter.Students[0], tCenter.Courses[0], tCenter.Courses[0].Lessons[1], 80);
            tCenter.Teachers[0].GradeStudentsLesson(tCenter.Students[0], tCenter.Courses[1], tCenter.Courses[1].Lessons[0], 95);
            tCenter.Teachers[0].GradeStudentsLesson(tCenter.Students[0], tCenter.Courses[1], tCenter.Courses[1].Lessons[1], 82);
            
            tCenter.Teachers[0].GradeStudentsLesson(tCenter.Students[1], tCenter.Courses[0], tCenter.Courses[0].Lessons[0], 86);
            tCenter.Teachers[0].GradeStudentsLesson(tCenter.Students[1], tCenter.Courses[0], tCenter.Courses[0].Lessons[1], 75);
            tCenter.Teachers[0].GradeStudentsLesson(tCenter.Students[1], tCenter.Courses[1], tCenter.Courses[1].Lessons[0], 0);
            tCenter.Teachers[0].GradeStudentsLesson(tCenter.Students[1], tCenter.Courses[1], tCenter.Courses[1].Lessons[1], 93);

            tCenter.CalculateStudentCourseGrades(tCenter.Students[0]);
            tCenter.CalculateStudentCourseGrades(tCenter.Students[1]);
            
            Console.WriteLine(tCenter.Students[0].CourseGrades[tCenter.Courses[0]].GradeValue);
            Console.WriteLine(tCenter.Students[0].CourseGrades[tCenter.Courses[1]].GradeValue);
            Console.WriteLine(tCenter.Students[1].CourseGrades[tCenter.Courses[0]].GradeValue);
            Console.WriteLine(tCenter.Students[1].CourseGrades[tCenter.Courses[1]].GradeValue);

        }
    }
}

