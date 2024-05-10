using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace server.Dtos.Comment
{
    public class UpdateCommentRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Min length must be greater than 3 letters!")]
        [MaxLength(20, ErrorMessage = "Max Length must be less than 20 letters!")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(10, ErrorMessage = "Min length must be greater than 10 letters!")]
        [MaxLength(255, ErrorMessage = "Max Length must be less than 255 letters!")]
        public string Content { get; set; } = string.Empty;
    }
}