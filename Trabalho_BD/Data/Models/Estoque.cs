using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trabalho_BD.Data.Models;

public partial class Estoque
{
    [Key]
    public int IdEstoque { get; set; }

    public string? IdHemocentro { get; set; }

    public string TipoItem { get; set; } = null!;

    public int Quantidade { get; set; }

    public virtual Hemocentro? IdHemocentroNavigation { get; set; }
}
