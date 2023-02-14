using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;

namespace WizFilmes.Infra.Data.Dtos.FilmDtos
{
    public class FilmDtoDataReturn
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Review> Reviews { get; set; }
        public double Rating
        {
            get
            {
                if (Reviews.Any())
                {
                    return Math.Round(Reviews.Average(x => x.Rating), 2);
                }
                if (Reviews == null)
                {
                    return 0;
                }
                return 0;
            }
            set { }
        }
        public string Director { get; set; }
    }
}
