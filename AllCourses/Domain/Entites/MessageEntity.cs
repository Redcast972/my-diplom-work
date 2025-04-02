using System.ComponentModel.DataAnnotations;

namespace AllCourses.Domain.Entites
{
    public class MessageEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Author { get; set; }

        [Required(ErrorMessage = "Сообщение не должно быть пустым")]
        [Display(Name = "Сообщение")]
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
