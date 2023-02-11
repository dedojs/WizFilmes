using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizFilmes.Infra.Data.Dtos.DirectorDtos
{
    public class CreateDirectorDto
    {
        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "O Nome deve ter no mínimo 10 e no máximo 50 caracteres")]
        public string Name { get; set; }
    }
}
