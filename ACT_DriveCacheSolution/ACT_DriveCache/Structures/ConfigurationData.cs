using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace ACT.Applications.DriveCache
{

    public partial class ConfigurationData
    {
        [JsonProperty("users", NullValueHandling = NullValueHandling.Ignore)]
        public List<User> Users { get; set; }

        [JsonProperty("searchdefinitions", NullValueHandling = NullValueHandling.Ignore)]
        public List<Searchdefinition> Searchdefinitions { get; set; }

        [JsonProperty("searchdefinitionpaths", NullValueHandling = NullValueHandling.Ignore)]
        public List<Searchdefinitionpath> Searchdefinitionpaths { get; set; }

        [JsonProperty("machines", NullValueHandling = NullValueHandling.Ignore)]
        public List<Machine> Machines { get; set; }

        [JsonProperty("databaseconnectionstring", NullValueHandling = NullValueHandling.Ignore)]
        public string DatabaseConnectionString { get; set; }
    }

    public partial class Machine
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("paths", NullValueHandling = NullValueHandling.Ignore)]
        public List<Path> Paths { get; set; }
    }

    public partial class Path
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("userid", NullValueHandling = NullValueHandling.Ignore)]
        public string Userid { get; set; }

        [JsonProperty("path", NullValueHandling = NullValueHandling.Ignore)]
        public string PathPath { get; set; }

        [JsonProperty("pattern", NullValueHandling = NullValueHandling.Ignore)]
        public string Pattern { get; set; }

        [JsonProperty("encryption", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Encryption { get; set; }

        [JsonProperty("recursive", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Recursive { get; set; }
    }

    public partial class Searchdefinitionpath
    {
        [JsonProperty("searchdefinitionid", NullValueHandling = NullValueHandling.Ignore)]
        public string Searchdefinitionid { get; set; }

        [JsonProperty("pathid", NullValueHandling = NullValueHandling.Ignore)]
        public string Pathid { get; set; }

        [JsonProperty("totalindexeditems", NullValueHandling = NullValueHandling.Ignore)]
        public long? Totalindexeditems { get; set; }

        [JsonProperty("lastrundate", NullValueHandling = NullValueHandling.Ignore)]
        public string Lastrundate { get; set; }
    }

    public partial class Searchdefinition
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("userid", NullValueHandling = NullValueHandling.Ignore)]
        public string Userid { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("totalindexeditems", NullValueHandling = NullValueHandling.Ignore)]
        public long? Totalindexeditems { get; set; }

        [JsonProperty("lastrundate", NullValueHandling = NullValueHandling.Ignore)]
        public string Lastrundate { get; set; }

        [JsonProperty("hoursbetweenupdate", NullValueHandling = NullValueHandling.Ignore)]
        public long? Hoursbetweenupdate { get; set; }
    }

    public partial class User
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("username", NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        [JsonProperty("password", NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; set; }

        [JsonProperty("mainmachine", NullValueHandling = NullValueHandling.Ignore)]
        public string Mainmachine { get; set; }

        [JsonProperty("actid", NullValueHandling = NullValueHandling.Ignore)]
        public string Actid { get; set; }

        [JsonProperty("lastlogin", NullValueHandling = NullValueHandling.Ignore)]
        public string Lastlogin { get; set; }

        [JsonProperty("securitylevel", NullValueHandling = NullValueHandling.Ignore)]
        public long? Securitylevel { get; set; }

        [JsonProperty("databaseconnectionstring", NullValueHandling = NullValueHandling.Ignore)]
        public string DatabaseConnectionString { get; set; }
    }

    public partial class ConfigurationData
    {
        public static ConfigurationData FromJson(string json) => JsonConvert.DeserializeObject<ConfigurationData>(json, ACT.Applications.DriveCache.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ConfigurationData self) => JsonConvert.SerializeObject(self, ACT.Applications.DriveCache.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
