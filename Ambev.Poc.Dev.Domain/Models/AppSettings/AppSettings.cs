using Ambev.Poc.Dev.Domain.Models.AppSettings.Sections;
using Newtonsoft.Json;

namespace Ambev.Poc.Dev.Domain.Models.AppSettings
{
    public class AppSettings
    {
        [JsonProperty("ConnectionStrings")]
        public ConnectionStrings ConnectionStrings { get; set; }
    }
}
