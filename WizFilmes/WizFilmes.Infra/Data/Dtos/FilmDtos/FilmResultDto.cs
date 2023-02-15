using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;

namespace WizFilmes.Infra.Data.Dtos.FilmDtos
{
    public class FilmResultDto
    {
        public IEnumerable<FilmeReturnDtoWithActors> Film { get; set; }
        public double TotalFilms { get; set; }
        public double TotalPages { get; set; }
    }
}
