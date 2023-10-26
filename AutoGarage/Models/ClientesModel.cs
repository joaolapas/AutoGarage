

namespace AutoGarage.Models
{
    public class ClientesModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Morada { get; set; }
        public string Telefone { get; set; }
        public string Email {  get; set; }

        public List<AutomoveisModel>? Automoveis { get; set; }
    }
}



