﻿using System.ComponentModel.DataAnnotations;

namespace Hexagon.Domain.Entites.Forum
{
    public class DiscussionEntity
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Поле заголовка не должно быть пустым.")]
        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле контента не должно быть пустым.")]
        [Display(Name = "Контент")]
        public string Discription { get; set; }

        [Required(ErrorMessage = "Поле автора не должно быть пустым.")]
        [Display(Name = "Автор")]
        public string Author { get; set; }
        public string AuthorId { get; set; }

        [Required(ErrorMessage = "Поле категории курса не должно быть пустым.")]
        [Display(Name = "Категория кура")]
        public DateTime CreatedAt { get; set; }
        public byte[] ImageData { get; set; }
        public List<string>? MessagesId { get; set; }
    }
}
