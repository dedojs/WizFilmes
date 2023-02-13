using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;

namespace WizFilmes.Infra.Data.Dtos.FilmDtos
{
    public class FilmDto
    {
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
        public double Rating
        {
            get
            {
                if (Reviews.Any())
                {
                    return Math.Round(Reviews.Average(x => x.Rating), 2);
                }
                else
                {
                    return 0;
                }
            }
        }
        [JsonIgnore]
        public virtual IEnumerable<FilmActor> Cast { get; set; }
    }
}
