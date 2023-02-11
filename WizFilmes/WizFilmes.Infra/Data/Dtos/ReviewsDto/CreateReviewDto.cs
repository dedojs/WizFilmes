using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;

namespace WizFilmes.Infra.Data.Dtos.ReviewsDto
{
    public class CreateReviewDto
    {
        [StringLength(200, ErrorMessage = "A descrição deve ter no máximo 200 caracteres")]
        public string? Description { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "O valor deve estar emtre 1 e 5" )]
        public int Rating { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int FilmId { get; set; }
        
    }
}
