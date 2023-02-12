using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;

namespace WizFilmes.Infra.Data.Dtos.ActorDtos
{
    public class ActorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public virtual IEnumerable<FilmActor> Films { get; set; }

    }
}
