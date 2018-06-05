using Microsoft.Extensions.Configuration;

namespace Power.Repository
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly IConfiguration _configurationService;
        public ConnectionStringProvider(IConfiguration configurationService)
        {
            _configurationService = configurationService;
        }
        public string GetConnectionString()
        {
            return _configurationService.GetConnectionString("DefaultConnection");
        }
    }
}
