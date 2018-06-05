using System.Data;

namespace Power.Infra.DataBase.Connection
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetInstance();
    }
}
