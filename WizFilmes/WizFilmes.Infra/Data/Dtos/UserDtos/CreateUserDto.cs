using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizFilmes.Infra.Data.Dtos.UserDtos
{
    public class CreateUserDto
    {
        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "O Nome deve ter no mínimo 10 e no máximo 50 caracteres")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", ErrorMessage = "Formato de Email Inválido")]
        public string Email { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 6, ErrorMessage = "A senha deve conter entre 6 e 8 caracteres")]
        public string Password { get; set; }
    }
}
