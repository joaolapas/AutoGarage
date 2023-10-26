namespace AutoGarage.Models
{
    public class ServicosModel
    {
        public int Id { get; set; }
        public string TipoServico { get; set; }
        public DateTime DataServico { get; set; }
        public string DescricaoServico { get; set; }
        public decimal CustoServico { get; set; }

        public int? AutomovelId { get; set; }
        public AutomoveisModel? Automovel { get; set; }
    }
}
