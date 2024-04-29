using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.DatabaseRepository.Abastractions;
using Template.Domain.Entities;

namespace Template.DatabaseRepository.Mappings
{
    public class CorretorMap : PersonMap<Corretor>, IEntityTypeConfiguration<Corretor>
    {

        public void Configure(EntityTypeBuilder<Corretor> builder)
        {
            builder.ToTable("Corretor", "dbo");
            base.Configure(builder);
            builder.Property(x => x.Comissao).HasColumnType("decimal(5,2)");
        }
    }
}
