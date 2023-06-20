namespace TCCPosPucMinas.Application.Dtos
{
    public class MarcaDto
    {
        public int Id { get; set; }
       
        public string Nome { get; set; }

        public IEnumerable<VeiculoDto>? Veiculos { get; set; }
    }
}
