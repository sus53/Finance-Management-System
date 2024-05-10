using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.Stock
{
    public class UpdateStockRequestDto
    {
        [Required]
        [MinLength(1, ErrorMessage = "Symbol must consists of 1 or more letters.")]
        [MaxLength(10, ErrorMessage = "Symbol mustn't contain more than 10 letters.")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MinLength(5, ErrorMessage = "Company Name must consists of 5 or more letters.")]
        [MaxLength(20, ErrorMessage = "Company Name must consists of 20 or more letters.")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.001, 100)]
        public decimal LastDiv { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Industry Name must consists of 5 or more letters.")]
        [MaxLength(20, ErrorMessage = "Industry Name must consists of 20 or more letters.")]
        public string Industry { get; set; } = string.Empty;
        [Required]
        public long MarketCap { get; set; }
    }
}