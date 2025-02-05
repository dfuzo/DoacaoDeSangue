using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trabalho_BD.Data.Models;

public partial class Doador
{
    [Key]
    public string Cpf { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public DateOnly DataNascimento { get; set; }

    public string Sexo { get; set; } = null!;

    public double Peso { get; set; }

    public string? Telefone { get; set; }

    public string? Email { get; set; }

    public int? Id_Tipo_Sanguineo { get; set; }

    public int? Id_Endereco { get; set; }

    public virtual ICollection<Coleta> Coletas { get; set; } = new List<Coleta>();

    public virtual ICollection<Doacao> Doacoes { get; set; } = new List<Doacao>();

    public virtual Endereco? IdEnderecoNavigation { get; set; }

    public virtual TipoSanguineo? IdTipoSanguineoNavigation { get; set; }
}
