using Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Power.Infra.DataBase.Map
{
    public class EquipamentoMap : IEntityMappingConfiguration<Equipamento>
    {

        public void Map(EntityTypeBuilder<Equipamento> builder)
        {
            builder.ToTable("Equipamento");
            builder.HasKey(m => m.Id);

            builder.HasIndex(q => q.Nome).IsUnique();
        }
    }

}
