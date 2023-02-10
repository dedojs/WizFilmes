using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;

namespace WizFilmes.Infra.Data.Dtos.UserDtos
{
    public class ReadUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
    }
}
