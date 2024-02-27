namespace TrainingCenter
{
    public class Grade
    {
        public double GradeValue { get; }

        public Grade(double GradeValue)
        {
            if (GradeValue < 0 || GradeValue > 100) 
            {
                throw new ArgumentException("Grade value must be from 0-100");
            } 
            else 
            {
                this.GradeValue = GradeValue;
            }
        }
    }
}