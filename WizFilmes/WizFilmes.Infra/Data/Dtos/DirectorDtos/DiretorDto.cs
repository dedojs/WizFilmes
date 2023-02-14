using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.FilmDtos;

namespace WizFilmes.Infra.Data.Dtos.DirectorDtos
{
    public class DirectorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<FilmDtoDataReturn> Films { get; set; }
    }
}
