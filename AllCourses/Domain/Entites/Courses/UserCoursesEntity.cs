using System.ComponentModel.DataAnnotations;

namespace Hexagon.Domain.Entites.Courses
{
    public class UserCoursesEntity
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public List<string> CoursesId { get; set; }

    }
}
