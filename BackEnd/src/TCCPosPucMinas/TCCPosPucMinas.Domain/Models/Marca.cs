using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCCPosPucMinas.Domain.Models
{
    public class Marca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome da marca é obrigatória.")]
        [StringLength(150)]
        public string Nome { get; set; }

        public List<Veiculo> VeiculosNavigation { get; set; }
    }
}
