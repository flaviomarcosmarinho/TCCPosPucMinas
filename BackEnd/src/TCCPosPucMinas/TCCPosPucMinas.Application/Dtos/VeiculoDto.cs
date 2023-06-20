namespace TCCPosPucMinas.Application.Dtos
{
    public class VeiculoDto
    {        
        public int Id { get; set; }     
        public int MarcaId { get; set; }    
        public string Modelo { get; set; }
        public string AnoModelo { get; set; }  
        public string AnoFabricacao { get; set; }
        public string DataCadastro { get; set; }     
        public string Cor { get; set; }       
        public string Descricao { get; set; }   
        public string Observacao { get; set; }
        public int Quilometragem { get; set; }
        public bool UnicoDono { get; set; }
        public string Status { get; set; }        
        public decimal Valor { get; set; }
        public string Placa { get; set; }
        public string ImagemURL { get; set; }
        public int UserId { get; set; }
    }
}
