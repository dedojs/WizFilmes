using System.ComponentModel.DataAnnotations;
using WizFilmes.Domain.Entidades;

namespace WizFilmes.Domain.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<FilmActor> Films { get; set; }
        public string? Character { get; set; }
    }
}