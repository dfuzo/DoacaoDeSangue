using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trabalho_BD.Data.Models;

public partial class TipoSanguineo
{
    [Key]
    public int IdTipoSanguineo { get; set; }

    public string Tipo { get; set; } = null!;

    public string FatorRh { get; set; } = null!;

    public virtual ICollection<Coleta> Coletas { get; set; } = new List<Coleta>();

    public virtual ICollection<Doacao> Doacoes { get; set; } = new List<Doacao>();

    public virtual ICollection<Doador> Doadores { get; set; } = new List<Doador>();

    public virtual ICollection<Receptor> Receptores { get; set; } = new List<Receptor>();

    public virtual ICollection<Transfusao> Transfusoes { get; set; } = new List<Transfusao>();
}
