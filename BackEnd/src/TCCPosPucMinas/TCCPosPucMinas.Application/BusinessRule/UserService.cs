namespace TCCPosPucMinas.Application.BusinessRule
{
    public class UserService
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; } = string.Empty;

        public string ImagemURL { get; set; } = string.Empty;
    }
}
