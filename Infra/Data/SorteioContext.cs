
#nullable disable
using Datas.datas;
using Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

#nullable disable

namespace Datas
{
    public partial class SorteioContext : DbContext
    {
        private readonly ConnectionString connectionStringsConfig;
        public SorteioContext(IOptions<ConnectionString> ConnectionStringConfig)
        {
            connectionStringsConfig = ConnectionStringConfig.Value;
        }

        public SorteioContext(DbContextOptions<SorteioContext> options, IOptions<ConnectionString> connectionStringsCofingOptions)
            : base(options)
        {
            connectionStringsConfig = connectionStringsCofingOptions.Value;
        }

        public virtual DbSet<PessoasConfig> DadosClientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<PessoasConfig>(entity =>
            {

                modelBuilder.Entity<PessoasConfig>(entity =>
                {
                    entity.HasNoKey();
                });

                entity.ToTable("ListaSorteio");


                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CPF)
                  .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Data_Nascimento)
                    .IsUnicode(false);

                entity.Property(e => e.Renda)
                  .HasMaxLength(50)
                  .IsUnicode(false);

                entity.Property(e => e.Cota)
                  .HasMaxLength(50)
                  .IsUnicode(false);

                entity.Property(e => e.CID)
                  .HasMaxLength(50)
                  .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
