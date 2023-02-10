using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizFilmes.Domain.Models
{
    public class FilmActor
    {
        public int ActorId { get; set; }
        public virtual Actor Actor { get; set; }

        public int FilmId { get; set; }
        public virtual Film Film { get; set; }
    }
}
