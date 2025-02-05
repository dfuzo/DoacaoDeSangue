using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trabalho_BD.Data.Models;

public partial class Endereco
{
    [Key]
    public int IdEndereco { get; set; }

    public string Cep { get; set; } = null!;

    public string? Quadra { get; set; }

    public string? Bloco { get; set; }

    public string? Numero { get; set; }

    public string? Complemento { get; set; }

    public string Cidade { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public virtual ICollection<Doador> Doadores { get; set; } = new List<Doador>();

    public virtual ICollection<Hemocentro> Hemocentros { get; set; } = new List<Hemocentro>();

    public virtual ICollection<Receptor> Receptores { get; set; } = new List<Receptor>();
}
