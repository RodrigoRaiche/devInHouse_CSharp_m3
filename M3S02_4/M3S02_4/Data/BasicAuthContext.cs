using M3S02_4.Model;
using Microsoft.EntityFrameworkCore;

namespace M3S02_4.Data;

public class BasicAuthContext: DbContext
{
    private readonly IConfiguration _configuration;

    public BasicAuthContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Cliente> Clientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer(
            _configuration.GetConnectionString("ServerConnection")
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>(entidade =>
        {
            entidade.ToTable("Usuarios");

            entidade.HasKey(a => a.Id);
            entidade.HasAlternateKey(a => a.NomeUsuario);

            entidade
                .Property(a => a.NomeUsuario)
                .HasMaxLength(120)
                .IsRequired();

            entidade
                .Property(a => a.Senha)
                .HasMaxLength(100)
                .IsRequired();

            entidade.HasData(
                new Usuario
                {
                    Id = Guid.Parse("3ff37ac0-75bb-4dc9-9cc8-b5259d01088a"),
                    NomeUsuario = "admin",
                    Senha = "123abc456"
                }
            );
        });

        modelBuilder.Entity<Cliente>(entidade =>
        {
            entidade.ToTable("Clientes");

            entidade.HasKey(a => a.Id);

            entidade
                .Property(a => a.DataCadastro)
                .IsRequired();

            entidade
                .Property(a => a.Nome)
                .IsRequired();

            entidade.HasData(new[]
            {
                new Cliente
                {
                    Id = Guid.Parse("073ce8bb-d9be-4f72-9d1d-e7152d58974d"),
                    DataCadastro = new DateTime(2022, 09, 02),
                    Nome = "Rodrigo Paiva"
                },
                new Cliente
                {
                    Id = Guid.Parse("901a33b7-9949-4330-832a-aa9bba66db45"),
                    DataCadastro = new DateTime(2022, 09, 03),
                    Nome = "Rafael Luiz Paiva"
                },
                new Cliente
                {
                    Id = Guid.Parse("77da11b5-efc9-466a-abdb-edbb7639016f"),
                    DataCadastro = new DateTime(2022, 09, 04),
                    Nome = "Liliane Paiva"
                }
            });
        });
    }
}