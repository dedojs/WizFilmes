namespace WizFilmes.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Film> Films { get; set; }
    }
}