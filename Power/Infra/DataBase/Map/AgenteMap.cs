using Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Power.Infra.DataBase.Map
{
    public class AgenteMap : IEntityMappingConfiguration<Agente>
    {

        public void Map(EntityTypeBuilder<Agente> builder)
        {
            builder.ToTable("Agente");
            builder.HasKey(m => m.Id);

            builder.HasIndex(q => q.Nome).IsUnique();
        }
    }

}
