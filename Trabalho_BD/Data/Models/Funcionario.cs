using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trabalho_BD.Data.Models;

public partial class Funcionario
{
    [Key]
    public string Ponto { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Sexo { get; set; } = null!;

    public string? Telefone { get; set; }

    public string? Email { get; set; }

    public string? Cargo { get; set; }

    public string? Hemocentro { get; set; }

    public virtual ICollection<Coleta> Coletas { get; set; } = new List<Coleta>();

    public virtual Hemocentro? HemocentroNavigation { get; set; }

    public virtual ICollection<Transfusao> Transfusoes { get; set; } = new List<Transfusao>();
}
