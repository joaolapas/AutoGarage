using System.ComponentModel.DataAnnotations;

namespace AutoGarage.Models
{
public class AutomoveisModel
{
    [Key]
    public int Id { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public string Cor { get; set; }
    public string Matricula { get; set; }

    public int? ClienteId { get; set; }
    public ClientesModel? Cliente { get; set; }

    public List<ServicosModel>? Servicos { get; set; }
}
}
