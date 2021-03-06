using Microsoft.Extensions.Configuration;
using Nats.Service.Infrastructure.Configurations;

namespace Nats.Service.Infrastructure.Messaging.Nats
{
    public interface INatsConfiguration
    {
        string Url { get; }
    }

    public class NatsConfigurationData
    {
        public string Url { get; set; }
    }

    public class NatsConfiguration : BaseConfiguration<NatsConfigurationData>, INatsConfiguration
    {
        public NatsConfiguration(IConfiguration configuration) : base("NATS", configuration)
        {
        }

        public string Url => Config.Url;
    }
}