using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;

namespace WizFilmes.Domain.Entidades
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Film> Films { get; set; }
    }
}
