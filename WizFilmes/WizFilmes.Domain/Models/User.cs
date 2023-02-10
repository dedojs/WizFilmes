using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Entidades;

namespace WizFilmes.Domain.Models
{
    public class User : Person
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Review Id { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        
    }
}
