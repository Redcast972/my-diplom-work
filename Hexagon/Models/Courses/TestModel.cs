namespace Hexagon.Models.Courses
{
    public class TestModel
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string Question { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public int CorrectAnswerNumber { get; set; }
    }
}
