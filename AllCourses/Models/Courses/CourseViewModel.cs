using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AllCourses.Models.Courses
{
    public class CourseViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Discription { get; set; }
        public string Author { get; set; }
        public string CourseCategoryType { get; set; }
        public DateTime CreatedAt { get; set; }
        public byte[] ImageData { get; set; }
        public List<LessonModel> lessons { get; set; }
        public List<TestModel> tests { get; set; }        
    }
}
