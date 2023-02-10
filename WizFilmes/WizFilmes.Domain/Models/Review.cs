using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizFilmes.Domain.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int FilmId { get; set; }
        public virtual Film Film { get; set; }
    }
}
