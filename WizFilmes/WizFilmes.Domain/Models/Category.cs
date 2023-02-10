using System.ComponentModel.DataAnnotations;

namespace WizFilmes.Domain.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Film> Films { get; set; }
    }
}