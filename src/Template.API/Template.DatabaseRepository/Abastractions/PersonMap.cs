using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Domain.Entities;
using Template.Shared.Abstractions.Entities;

namespace Template.DatabaseRepository.Abastractions
{
    public abstract class PersonMap<T>  :
            IEntityTypeConfiguration<T> where T: Pessoa
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd().IsRequired();

            builder.Property(x => x.UniqueId)
                .IsRequired();

            builder
               .Property(x => x.Nome)
               .HasMaxLength(200).HasColumnType("varchar(200)");

            builder
               .Property(x => x.CpfCnpj)
               .HasMaxLength(14).HasColumnType("varchar(14)");

            builder
               .Property(x => x.Email)
               .HasMaxLength(100).HasColumnType("varchar(100)");

            builder
               .Property(x => x.TipoPessoa);

            builder
               .Property(x => x.Telefone).HasMaxLength(100).HasColumnType("varchar(100)");            

            builder
                .Property(x => x.CreatedAt)
                .IsRequired();

            builder
                .Property(x => x.ModifiedAt);

            builder.Property(x => x.CreatedBy)
                .IsRequired()
                .HasMaxLength(45).HasColumnType("varchar(45)");

            builder
                .Property(x => x.ModifiedBy)
                .IsRequired(false)
                .HasMaxLength(45)
                .HasColumnType("varchar(45)");

            builder
                .Property(x => x.IsDeleted)
                .IsRequired();
        }
    }
}
