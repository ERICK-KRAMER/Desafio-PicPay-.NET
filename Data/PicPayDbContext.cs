using Microsoft.EntityFrameworkCore;
using PicPay.Model.Entity;

namespace PicPay.Data;

public class PicPayDbContext : DbContext
{
    public PicPayDbContext(DbContextOptions<PicPayDbContext> options) : base(options) { }

    public DbSet<WalletEntity> Wallet { get; set; }
    public DbSet<TransferEntity> Transfer { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Denomina o nome da tabela
        modelBuilder.Entity<WalletEntity>()
            .ToTable("Wallet");
        modelBuilder.Entity<TransferEntity>()
            .ToTable("Transfer");

        // Permite que a tabela Armazene apenas um E-MAIL e um CPF
        modelBuilder.Entity<WalletEntity>()
            .HasIndex(i => new { i.Email, i.Cpf })
            .IsUnique();

        // Configura o valor na Tabela para duas casas decimais 
        modelBuilder.Entity<WalletEntity>()
            .Property(u => u.Cash)
            .HasColumnType("decimal(18,2)");
        modelBuilder.Entity<TransferEntity>()
            .Property(p => p.Value)
            .HasColumnType("decimal(18,2)");
        
        // Converte o valor pelo nome na tabela wallet 
        modelBuilder.Entity<WalletEntity>()
            .Property(p => p.Type)
            .HasConversion<string>();
        
        // Indica qual é o Id da tabela
        modelBuilder.Entity<TransferEntity>()
            .HasKey(k => k.TranferId);
        
        // Relaciona a chave estrangeira da tabela Wallet com a Transfer
        modelBuilder.Entity<TransferEntity>()
            .HasOne(t => t.Sender)
            .WithMany()
            .HasForeignKey(p => p.SerderId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Transfer_Sender");
        modelBuilder.Entity<TransferEntity>()
            .HasOne(t => t.Receive)
            .WithMany()
            .HasForeignKey(k => k.ReceiveId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Transfer_Receive");

    }
}