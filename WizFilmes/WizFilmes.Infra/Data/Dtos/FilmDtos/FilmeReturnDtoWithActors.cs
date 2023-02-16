using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;

namespace WizFilmes.Infra.Data.Dtos.FilmDtos
{
    public class FilmeReturnDtoWithActors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string DirectorName
        {
            get
            {
                if (Director != null)
                {
                    return Director.Name;
                }
                if (Director == null)
                {
                    return "";
                }
                return "";
            }
            set { }
        }
        [JsonIgnore]
        public Director Director { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
        public string CategoryName
        {
            get
            {
                if (Category != null)
                {
                    return Category.Name;
                }
                if (Category == null)
                {
                    return "";
                }
                return "";
            }
            set { }
        }
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
        public IEnumerable<FilmDtoActorCharacter> Cast { get; set; }
    }
}
