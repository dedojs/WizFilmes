using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WizFilmes.Domain.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int DirectorId { get; set; }
        [JsonIgnore]
        public virtual Director Director { get; set; }
        public int CategoryId { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }
        public virtual IEnumerable<Review> Reviews { get; set; }
        public double Rating { get; set; }
        public virtual IEnumerable<FilmActor> Cast { get; set; }
    }
}
