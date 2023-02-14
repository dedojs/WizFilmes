using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;

namespace WizFilmes.Infra.Data.Dtos.ActorDtos
{
    public class CreateActorDto
    {
        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "O Nome deve ter no mínimo 10 e no máximo 50 caracteres")]
        public string Name { get; set; }
        //[Required]
        //[StringLength(20, MinimumLength = 5, ErrorMessage = "O Papel deve ter no mínimo 5 e no máximo 20 caracteres")]
        //public string Character { get; set; }
    }
}
