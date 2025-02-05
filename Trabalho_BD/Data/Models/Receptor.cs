using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trabalho_BD.Data.Models;

public partial class Receptor
{
    [Key]
    public string Cpf { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public DateOnly DataNascimento { get; set; }

    public string Sexo { get; set; } = null!;

    public double Peso { get; set; }

    public string? Telefone { get; set; }

    public string? Email { get; set; }

    public int? IdTipoSanguineo { get; set; }

    public int? IdEndereco { get; set; }

    public virtual Endereco? IdEnderecoNavigation { get; set; }

    public virtual TipoSanguineo? IdTipoSanguineoNavigation { get; set; }

    public virtual ICollection<Transfusao> Transfusoes { get; set; } = new List<Transfusao>();
}
