namespace Trabalho_BD.Data.Models
{
    public class DoadorHistorico
    {
        public string Cpf { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Tipo_Sanguineo { get; set; } = null!;
        public int Total_Doacoes { get; set; }
        public double Volume_Total_Doado { get; set; }
        public DateTime? Ultima_Doacao { get; set; }
        public string? Nome_Hemocentro { get; set; }
        public string Status_Doador { get; set; } = null!;
    }
}
