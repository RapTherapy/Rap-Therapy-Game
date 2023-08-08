using Newtonsoft.Json;

namespace RapGame.Models
{
    public class AppSettings
    {
        public Logging Logging { get; set; }
        public AdminData AdminData { get; set; }
        public PathToGameFile PathToGameFile { get; set; }
        public PathToMediaFileForFrame PathToMediaFileForFrame { get; set; }
        public string AllowedHosts { get; set; }

        public PathToLicence PathToLicence { get; set; }

        public string Key { get; set; }

    }

    public class LogLevel
    {
        public string Default { get; set; }
        public string Microsoft { get; set; }

        [JsonProperty("Microsoft.Hosting.Lifetime")]
        public string MicrosoftHostingLifetime { get; set; }
    }

    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }
}
