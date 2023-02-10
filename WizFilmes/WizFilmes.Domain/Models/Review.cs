using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizFilmes.Domain.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
    }
}
