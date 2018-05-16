using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Power.Infra.DataBase.Map
{
    public interface IEntityMappingConfiguration<T> where T : class
    {
        void Map(EntityTypeBuilder<T> builder);
    }
}
