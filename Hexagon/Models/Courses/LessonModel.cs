namespace Hexagon.Models.Courses
{
    public class LessonModel
    {
        public Guid Id { get; set; }
        public string CourseId { get; set; }
        public string Title { get; set; }
        public string Discription { get; set; }
        public byte[] ImageData { get; set; }
        public List<string>? LinksToVideoTutorials { get; set; }
    }
}
