using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.Comment
{
    public class CreateCommentRequestDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Min length must be greater than 3 letters!")]
        [MaxLength(20, ErrorMessage = "Max Length must be less than 20 letters!")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(10, ErrorMessage = "Min length must be greater than 10 letters!")]
        [MaxLength(255, ErrorMessage = "Max Length must be less than 255 letters!")]
        public string Content { get; set; } = string.Empty;
        [Required]
        public DateTime CreatedOn { get; set; }

        public int? StockId { get; set; }
    }
}