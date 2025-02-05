using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trabalho_BD.Data.Models;

public partial class Transfusao
{
    [Key]
    public int IdTransfusao { get; set; }

    public int? IdColeta { get; set; }

    public string? CpfReceptor { get; set; }

    public string? PontoFuncionario { get; set; }

    public DateOnly DataTransfusao { get; set; }

    public double Volume { get; set; }

    public string? IdHemocentro { get; set; }

    public int? IdTipoSanguineo { get; set; }

    public byte[]? Comprovante { get; set; }

    public virtual Receptor? CpfReceptorNavigation { get; set; }

    public virtual Coleta? IdColetaNavigation { get; set; }

    public virtual Hemocentro? IdHemocentroNavigation { get; set; }

    public virtual TipoSanguineo? IdTipoSanguineoNavigation { get; set; }

    public virtual Funcionario? PontoFuncionarioNavigation { get; set; }
}
