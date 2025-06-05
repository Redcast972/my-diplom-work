using System.ComponentModel.DataAnnotations;

namespace Hexagon.Domain.Entites.Courses
{
    public class CourseUserProgessEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string CourseId { get; set; }
        public string LessonsCount { get; set; }
        public string lessonsСompletedCount { get; set; }

    }
}
