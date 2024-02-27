using Xunit;
using TrainingCenter;

namespace TrainingCenterTests;
public class TrainingCenterUnitTest
{   
    private TCenter tCenter;

    public TrainingCenterUnitTest()
    {
        tCenter = new TCenter();
    }

    [Fact]
    public void TeacherAddedToTrainingCenterTeacherst()
    {
        var teacher = new Teacher("Jonh", "Smith");
        tCenter.AddTeacher(teacher);

        Assert.Contains(teacher, tCenter.Teachers);

    }

    [Fact]
    public void StudentAddedToTrainingCenterStudentsList()
    {
        var student = new Student("Askar", "Ibrayev");
        tCenter.AddStudent(student);

        Assert.Contains(student, tCenter.Students);

    }
 
    [Fact]
    public void CourseAddedToTrainingCenterCoursesList()
    {
        var course = new Course("React-1");
        tCenter.AddCourse(course);

        Assert.Contains(course, tCenter.Courses);

    }

    [Fact]
    public void LessonAddedToCourse()
    {
        var course = new Course("React-1");
        var lesson = new Lesson("Redux");

        course.AddLesson(lesson);

        Assert.Contains(lesson, course.Lessons);
    }

    [Fact]
    public void CourseAddedToStudent()
    {
        var student = new Student("Askar", "Ibrayev");
        var course = new Course("React-1");

        tCenter.AddCourseToStudent(student, course);

        Assert.Contains(course, student.Courses);
    }

    [Fact]
    public void TeacherGradesTheSudentForLesson()
    {
        var teacher = new Teacher("John", "Smith");
        var student = new Student("Askar", "Ibrayev");
        var course = new Course("DotNet-4");
        var lesson = new Lesson("Delegates");
        var grade = 89.0;

        tCenter.AddStudent(student);
        tCenter.AddCourse(course);
        tCenter.AddCourseToStudent(student, course);
        course.AddLesson(lesson);


        teacher.GradeStudentsLesson(student, course, lesson, grade);

        Assert.Equal(grade, student.LessonGrades[lesson].GradeValue);
    }
    
    [Fact]
    public void StudentCourseGradeIsCalculated()
    {
        var teacher = new Teacher("John", "Smith");
        var student = new Student("Askar", "Ibrayev");
        var course = new Course("DotNet-4");
        var lesson1 = new Lesson("Delegates");
        var lesson2 = new Lesson("LINQ");
        var grade1 = 89.0;
        var grade2 = 93.0;
        var average = (grade1 + grade2) / 2;

        tCenter.AddStudent(student);
        tCenter.AddCourse(course);
        tCenter.AddCourseToStudent(student, course);
        course.AddLesson(lesson1);
        course.AddLesson(lesson2);

        teacher.GradeStudentsLesson(student, course, lesson1, grade1);
        teacher.GradeStudentsLesson(student, course, lesson2, grade2);

        tCenter.CalculateStudentCourseGrades(student);

        Assert.Equal(average, student.CourseGrades[course].GradeValue);
    }
}