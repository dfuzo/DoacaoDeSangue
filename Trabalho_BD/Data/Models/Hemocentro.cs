using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trabalho_BD.Data.Models;

public partial class Hemocentro
{
    [Key]
    public string Cnpj { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public int? IdEndereco { get; set; }

    public string? Telefone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Coleta> Coletas { get; set; } = new List<Coleta>();

    public virtual ICollection<Estoque> Estoques { get; set; } = new List<Estoque>();

    public virtual ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

    public virtual Endereco? IdEnderecoNavigation { get; set; }

    public virtual ICollection<Transfusao> Transfusoes { get; set; } = new List<Transfusao>();
}
