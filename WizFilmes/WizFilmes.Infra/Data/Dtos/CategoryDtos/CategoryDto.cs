using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.FilmDtos;

namespace WizFilmes.Infra.Data.Dtos.CategoryDtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<FilmDtoDataReturn> Films { get; set; }

    }
}
