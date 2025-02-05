using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trabalho_BD.Data.Models;

public partial class Coleta
{
    [Key]
    public int IdColeta { get; set; }

    public string? CpfDoador { get; set; }

    public string? PontoFuncionario { get; set; }

    public DateOnly DataColeta { get; set; }

    public DateOnly DataValidade { get; set; }

    public double Volume { get; set; }

    public string? IdHemocentro { get; set; }

    public int? IdTipoSanguineo { get; set; }

    public byte[]? Comprovante { get; set; }

    public virtual Doador? CpfDoadorNavigation { get; set; }

    public virtual Hemocentro? IdHemocentroNavigation { get; set; }

    public virtual TipoSanguineo? IdTipoSanguineoNavigation { get; set; }

    public virtual Funcionario? PontoFuncionarioNavigation { get; set; }

    public virtual ICollection<Transfusao> Transfusoes { get; set; } = new List<Transfusao>();
}
