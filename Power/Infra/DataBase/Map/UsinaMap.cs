using Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Power.Infra.DataBase.Map
{
    public class UsinaMap : IEntityMappingConfiguration<Usina>
    {

        public void Map(EntityTypeBuilder<Usina> builder)
        {
            builder.ToTable("Usina");
            builder.HasKey(m => m.Id);

            builder.HasIndex(q => q.Nome).IsUnique();
        }
    }

}
