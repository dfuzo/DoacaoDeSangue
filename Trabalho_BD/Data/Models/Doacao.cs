using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trabalho_BD.Data.Models;

public partial class Doacao
{
    [Key]
    public int IdDoacao { get; set; }

    public string? IdDoador { get; set; }

    public DateOnly DataDoacao { get; set; }

    public string LocalDoacao { get; set; } = null!;

    public double VolumeColetado { get; set; }

    public int? TipoSanguineo { get; set; }

    public virtual Doador? IdDoadorNavigation { get; set; }

    public virtual TipoSanguineo? IdTipoSanguineoNavigation { get; set; }
}
