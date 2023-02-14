using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WizFilmes.Domain.Models
{
    public class FilmActor
    {
        [Key]
        public int Id { get; set; }
        public int ActorId { get; set; }
        [JsonIgnore]
        public virtual Actor Actor { get; set; }
        public string Character { get; set; }
        public int FilmId { get; set; }
        [JsonIgnore]
        public virtual Film Film { get; set; }
    }
}
