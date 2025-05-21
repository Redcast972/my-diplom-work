namespace Hexagon.Areas.Teacher.Models
{
    public class CreateCourseViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int ModuleCount { get; set; }
        public int LessonsCount { get; set; }
        public byte[] CourseImageData { get; set; }
    }
}
