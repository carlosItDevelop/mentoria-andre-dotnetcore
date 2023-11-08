using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SmartAdmin.WebUI.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string NomeCompleto { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Apelido { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime DataDeNascimento { get; set; }

        public bool Ativo { get; set; }
    }

}
