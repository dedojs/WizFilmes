using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizFilmes.Infra.Data.Dtos.LoginDtos
{
    public class UserLoginDto
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$")]
        public string Email { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 6, ErrorMessage = "A senha deve conter entre 6 e 8 caracteres")]
        public string Password { get; set; }
    }
}
