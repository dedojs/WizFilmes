using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WizFilmes.Domain.Entidades;

namespace WizFilmes.Domain.Models
{
    public class User : Person
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int ReviewId { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Review> Reviews { get; set; }
        
    }
}
