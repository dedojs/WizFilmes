using WizFilmes.Domain.Entidades;

namespace WizFilmes.Domain.Models
{
    public class Actor : Person
    {
        public string Character { get; set; }
    }
}