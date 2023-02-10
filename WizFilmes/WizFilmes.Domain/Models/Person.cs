using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;

namespace WizFilmes.Domain.Entidades
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserType Type { get; set; }
        public IEnumerable<Film> Films { get; set; }
    }
}
