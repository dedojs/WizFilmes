using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WizFilmes.Domain.Models;

namespace WizFilmes.Domain.Entidades
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Film> Films { get; set; }
    }
}
