using Newtonsoft.Json;

namespace Ambev.Poc.Dev.Domain.Models.AppSettings.Sections
{
    public  class ConnectionStrings
    {
        [JsonProperty("DefautConnection")]
        public string DefautConnection { get; set; }
    }
}
