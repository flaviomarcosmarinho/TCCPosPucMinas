using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [StringLength(20)]
        public string Cor { get; set; }

        [StringLength(255)]
        public string Descricao { get; set; }

        [StringLength(255)]
        public string Observacao { get; set; }

        public int Quilometragem { get; set; }
        public bool UnicoDono { get; set; } = false;
        public string Status { get; set; }

        [Precision(18, 2)]
        [Required(ErrorMessage = "Valor é obrigatório.")]
        public decimal Preco { get; set; }

        [StringLength(7)]
        public string Placa { get; set; }

        public string ImagemURL { get; set; }
    }
}
