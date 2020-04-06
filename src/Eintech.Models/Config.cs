using Microsoft.Extensions.Configuration;

namespace Eintech.Models
{
    public class Config : IConfig
    {
        private readonly IConfigurationRoot _configuration;

        public Config(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public string DbConnectionString => _configuration["ConnectionString"];
    }
}
