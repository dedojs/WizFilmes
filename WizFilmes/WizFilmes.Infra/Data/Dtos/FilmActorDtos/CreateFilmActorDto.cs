using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;

namespace WizFilmes.Infra.Data.Dtos.FilmActorDtos
{
    public class CreateFilmActorDto
    {
        [Required]
        public int ActorId { get; set; }
        [Required]
        public int FilmId { get; set; }
    }
}
