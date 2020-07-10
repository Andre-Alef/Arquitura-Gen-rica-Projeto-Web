using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArquiteturaTeste.Domain.Models
{
    public class NovoChamado
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Assunto { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Categoria { get; set; }

        [DisplayName("Mais informações")]
        [StringLength(255)]
        public string MaisInformacoes { get; set; }

        [StringLength(100)]
        public string Status { get; set; }
        [DisplayName("Data")]
        [Required(ErrorMessage = "Preencha a data")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataDeCadastro{ get; set; }
        
    }
}
