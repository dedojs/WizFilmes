using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace WizFilmes.Domain.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public Director Director { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public double Rating { get; set; }
        public IEnumerable<Actor> Cast { get; set; }
    }
}
