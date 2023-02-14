using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;

namespace WizFilmes.Infra.Data.Dtos.FilmDtos
{
    public class FilmResultDtoCountPages
    {
        public IEnumerable<FilmDto> Films { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
    }
}
