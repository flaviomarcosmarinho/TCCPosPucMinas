using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace TCCPosPucMinas.API.Models
{
    public class Veiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Marca é obrigatória.")]
        [StringLength(150)]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Modelo é obrigatório.")]
        [StringLength(150)]
        public string Modelo { get; set; }

        [StringLength(4)]
        public string AnoModelo { get; set; }

        [StringLength(4)]
        public string AnoFabricacao { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getutcdate()")]
        public DateTime DataCadastro { get; set; }
        public string Cor { get; set; }
        public int Quilometragem { get; set; }

        public bool UnicoDono { get; set; } = false;
        public string Status { get; set; }

        [Precision(18, 2)]
        [Required(ErrorMessage = "Valor é obrigatório.")]
        public decimal Preco { get; set; }

        public string ImagemURL { get; set; }
    }
}
