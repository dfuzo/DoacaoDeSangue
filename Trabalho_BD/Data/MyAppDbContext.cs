using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Trabalho_BD.Data.Models;

namespace Trabalho_BD.Data
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
        public virtual DbSet<Coleta> Coletas { get; set; }
        public virtual DbSet<Doacao> Doacoes { get; set; }
        public virtual DbSet<Doador> Doadores { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Estoque> Estoques { get; set; }
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<Hemocentro> Hemocentros { get; set; }
        public virtual DbSet<Receptor> Receptores { get; set; }
        public virtual DbSet<TipoSanguineo> TipoSanguineos { get; set; }
        public virtual DbSet<Transfusao> Transfusoes { get; set; }
        public DbSet<DoadorHistorico> DoadoresHistorico { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coleta>(entity =>
            {
                entity.ToTable("Coleta");
                entity.HasKey(e => e.IdColeta).HasName("PK__Coleta__AC4C35C09C301E20");

                entity.Property(e => e.IdColeta).HasColumnName("Id_Coleta");
                entity.Property(e => e.CpfDoador)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("Cpf_Doador");
                entity.Property(e => e.DataColeta).HasColumnName("Data_Coleta");
                entity.Property(e => e.DataValidade).HasColumnName("Data_Validade");
                entity.Property(e => e.Volume).HasColumnName("Volume");
                entity.Property(e => e.IdHemocentro).HasColumnName("Id_Hemocentro");
                entity.Property(e => e.IdTipoSanguineo).HasColumnName("Id_Tipo_Sanguineo");
                entity.Property(e => e.PontoFuncionario).HasColumnName("Ponto_Funcionario");


                entity.HasOne(d => d.CpfDoadorNavigation)
                    .WithMany(p => p.Coletas)
                    .HasForeignKey(d => d.CpfDoador)
                    .HasConstraintName("FK_Coleta_CpfDoador");

                entity.HasOne(d => d.IdHemocentroNavigation)
                    .WithMany(p => p.Coletas)
                    .HasForeignKey(d => d.IdHemocentro)
                    .HasConstraintName("FK_Coleta_IdHemocentro");

                entity.HasOne(d => d.IdTipoSanguineoNavigation)
                    .WithMany(p => p.Coletas)
                    .HasForeignKey(d => d.IdTipoSanguineo)
                    .HasConstraintName("FK_Coleta_IdTipoSanguineo");

                entity.HasOne(d => d.PontoFuncionarioNavigation)
                    .WithMany(p => p.Coletas)
                    .HasForeignKey(d => d.PontoFuncionario)
                    .HasConstraintName("FK_Coleta_PontoFuncionario");
            });

            modelBuilder.Entity<Doacao>(entity =>
            {
                entity.HasKey(e => e.IdDoacao).HasName("PK__Doacoes__14ECF39DDC1A94D3");

                entity.ToTable("Doacao");

                entity.Property(e => e.IdDoacao).HasColumnName("Id_Doacao");
                entity.Property(e => e.DataDoacao).HasColumnName("Data_Doacao");
                entity.Property(e => e.IdDoador)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("Id_Doador");
                entity.Property(e => e.LocalDoacao)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Local_Doacao");
                entity.Property(e => e.TipoSanguineo).HasColumnName("Tipo_Sanguineo");
                entity.Property(e => e.VolumeColetado).HasColumnName("Volume_Coletado");

                entity.HasOne(d => d.IdDoadorNavigation).WithMany(p => p.Doacoes)
                    .HasForeignKey(d => d.IdDoador)
                    .HasConstraintName("FK__Doacoes__Id_Doad__5629CD9C");
                entity.HasOne(d => d.IdTipoSanguineoNavigation)
                    .WithMany(p => p.Doacoes)
                    .HasForeignKey(d => d.TipoSanguineo)
                    .HasConstraintName("FK_Coleta_IdTipoSanguineo");

            });

            modelBuilder.Entity<Doador>(entity =>
            {
                entity.HasKey(e => e.Cpf).HasName("PK__Doadores__C1FF9308FD16D77A");

                entity.ToTable("Doador");
                entity.Property(e => e.DataNascimento).HasColumnName("Data_Nascimento");
                entity.HasMany(e => e.Doacoes).WithOne(d => d.IdDoadorNavigation);

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Doadores)
                    .HasForeignKey(d => d.Id_Endereco)
                    .HasConstraintName("FK_Doador_Id_Endereco");

                entity.HasOne(d => d.IdTipoSanguineoNavigation)
                    .WithMany(p => p.Doadores)
                    .HasForeignKey(d => d.Id_Tipo_Sanguineo)
                    .HasConstraintName("FK_Doador_Id_Tipo_Sanguineo");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.ToTable("Endereco");

                entity.HasKey(e => e.IdEndereco).HasName("PK_Endereco");

                entity.Property(e => e.IdEndereco)
                    .HasColumnName("Id_Endereco");

                entity.Property(e => e.Cep)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasColumnName("CEP");

                entity.Property(e => e.Quadra)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Quadra");

                entity.Property(e => e.Bloco)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Bloco");

                entity.Property(e => e.Numero)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Numero");

                entity.Property(e => e.Complemento)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Complemento");

                entity.Property(e => e.Cidade)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasColumnName("Cidade");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasColumnName("Estado");
            });

            modelBuilder.Entity<Estoque>(entity =>
            {
                entity.ToTable("Estoque");

                entity.HasKey(e => e.IdEstoque).HasName("PK_Estoque");

                entity.Property(e => e.IdEstoque)
                    .HasColumnName("Id_Estoque");

                entity.Property(e => e.IdHemocentro)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasColumnName("Id_Hemocentro");

                entity.Property(e => e.TipoItem)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasColumnName("Tipo_Item");

                entity.Property(e => e.Quantidade)
                    .IsRequired()
                    .HasColumnName("Quantidade");

                entity.HasOne(d => d.IdHemocentroNavigation)
                    .WithMany(p => p.Estoques)
                    .HasForeignKey(d => d.IdHemocentro)
                    .HasConstraintName("FK_Estoque_IdHemocentro");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.ToTable("Funcionario");

                entity.HasKey(e => e.Ponto)
                    .HasName("PK_Funcionario");

                entity.Property(e => e.Ponto)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsRequired()
                    .IsConcurrencyToken()
                    .HasColumnName("Ponto");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasColumnName("Nome");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasColumnName("Sexo");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Telefone");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Email");

                entity.Property(e => e.Cargo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Cargo");

                entity.Property(e => e.Hemocentro)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasColumnName("Hemocentro");

                entity.HasOne(d => d.HemocentroNavigation)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.Hemocentro)
                    .HasConstraintName("FK_Funcionario_Hemocentro");
            });

            modelBuilder.Entity<Hemocentro>(entity =>
            {
                entity.ToTable("Hemocentro");

                entity.HasKey(e => e.Cnpj)
                    .HasName("PK_Hemocentro");

                entity.Property(e => e.Cnpj)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasColumnName("CNPJ");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasColumnName("Nome");

                entity.Property(e => e.IdEndereco)
                    .HasColumnName("Id_Endereco");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Telefone");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Email");

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Hemocentros)
                    .HasForeignKey(d => d.IdEndereco)
                    .HasConstraintName("FK_Hemocentro_IdEndereco");
            });

            modelBuilder.Entity<Receptor>(entity =>
            {
                entity.ToTable("Receptor");

                entity.HasKey(e => e.Cpf)
                    .HasName("PK_Receptor");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasColumnName("Cpf");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasColumnName("Nome");

                entity.Property(e => e.DataNascimento)
                    .IsRequired()
                    .HasColumnName("Data_Nascimento");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasColumnName("Sexo");

                entity.Property(e => e.Peso)
                    .IsRequired()
                    .HasColumnName("Peso");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Telefone");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Email");

                entity.Property(e => e.IdTipoSanguineo)
                    .HasColumnName("Id_Tipo_Sanguineo");

                entity.Property(e => e.IdEndereco)
                    .HasColumnName("Id_Endereco");

                entity.HasOne(d => d.IdTipoSanguineoNavigation)
                    .WithMany(p => p.Receptores)
                    .HasForeignKey(d => d.IdTipoSanguineo)
                    .HasConstraintName("FK_Receptor_IdTipoSanguineo");

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Receptores)
                    .HasForeignKey(d => d.IdEndereco)
                    .HasConstraintName("FK_Receptor_IdEndereco");
            });

            modelBuilder.Entity<TipoSanguineo>(entity =>
            {
                entity.ToTable("Tipo_Sanguineo");

                entity.HasKey(e => e.IdTipoSanguineo)
                    .HasName("PK_Tipo_Sanguineo");

                entity.Property(e => e.IdTipoSanguineo)
                    .HasColumnName("Id_Tipo_Sanguineo");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasColumnName("Tipo");

                entity.Property(e => e.FatorRh)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasColumnName("Fator_Rh");
            });

            modelBuilder.Entity<Transfusao>(entity =>
            {
                entity.ToTable("Transfusao");

                entity.HasKey(e => e.IdTransfusao)
                    .HasName("PK_Transfusao");

                entity.Property(e => e.IdTransfusao)
                    .HasColumnName("Id_Transfusao");

                entity.Property(e => e.IdColeta)
                    .HasColumnName("Id_Coleta");

                entity.Property(e => e.CpfReceptor)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("Cpf_Receptor");

                entity.Property(e => e.PontoFuncionario)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ponto_Funcionario");

                entity.Property(e => e.DataTransfusao)
                    .IsRequired()
                    .HasColumnName("Data_Transfusao");

                entity.Property(e => e.Volume)
                    .IsRequired()
                    .HasColumnName("Volume");

                entity.Property(e => e.IdHemocentro)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("Id_Hemocentro");

                entity.Property(e => e.IdTipoSanguineo)
                    .HasColumnName("Id_Tipo_Sanguineo");

                entity.Property(e => e.Comprovante)
                    .HasColumnType("varbinary(max)")
                    .HasColumnName("Comprovante");

                entity.HasOne(d => d.IdColetaNavigation)
                    .WithMany(p => p.Transfusoes)
                    .HasForeignKey(d => d.IdColeta)
                    .HasConstraintName("FK_Transfusao_IdColeta");

                entity.HasOne(d => d.CpfReceptorNavigation)
                    .WithMany(p => p.Transfusoes)
                    .HasForeignKey(d => d.CpfReceptor)
                    .HasConstraintName("FK_Transfusao_CpfReceptor");

                entity.HasOne(d => d.PontoFuncionarioNavigation)
                    .WithMany(p => p.Transfusoes)
                    .HasForeignKey(d => d.PontoFuncionario)
                    .HasConstraintName("FK_Transfusao_PontoFuncionario");

                entity.HasOne(d => d.IdHemocentroNavigation)
                    .WithMany(p => p.Transfusoes)
                    .HasForeignKey(d => d.IdHemocentro)
                    .HasConstraintName("FK_Transfusao_IdHemocentro");

                entity.HasOne(d => d.IdTipoSanguineoNavigation)
                    .WithMany(p => p.Transfusoes)
                    .HasForeignKey(d => d.IdTipoSanguineo)
                    .HasConstraintName("FK_Transfusao_IdTipoSanguineo");

                modelBuilder.Entity<DoadorHistorico>()
                   .HasNoKey()
                   .ToView("vw_Doador_Historico");

            });
        }
    }
}
