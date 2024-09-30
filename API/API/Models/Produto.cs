namespace API.Models;

public class Produto
{
    //C# - Construtor
    public Produto()
    {
        Id = Guid.NewGuid().ToString();
        CriadoEm = DateTime.Now;
    }
    //C# - Atributos/Propriedades - Características
    public string? Id { get; set; }
    public string? Nome { get; set; }
    public string? descricao { get; set; }
    public double Valor { get; set; }
    public int Quantidade { get; set; }
    public DateTime CriadoEm { get; set; }


}