using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;

namespace WizFilmes.Infra.Data.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "O Nome da categoria deve ter no mínimo 5 e no máximo 20 caracteres")]
        public string Name { get; set; }
    }
}
