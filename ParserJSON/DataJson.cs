namespace ParserJson
{

    #region Using

    using Newtonsoft.Json;

    #endregion

    /// <summary>
    /// Class which contain data of .json file.
    /// </summary>
    public class DataJson
    {
        /// <summary>
        /// InterfaceSettings.
        /// </summary>
        [JsonProperty("Interface Settings")]
        protected string InterfaceSettings { get; set; }

        /// <summary>
        /// MediaInterfaceSettings.
        /// </summary>
        [JsonProperty("Media Interface Settings")]
        protected string MediaInterfaceSettings { get; set; }

        /// <summary>
        /// PortSettings.
        /// </summary>
        [JsonProperty("Port Settings")]
        protected string PortSettings { get; set; }

        /// <summary>
        /// UniqueId.
        /// </summary>
        [JsonProperty("Unique ID")]
        protected string UniqueId { get; set; }

        /// <summary>
        /// MacAddress.
        /// </summary>
        [JsonProperty("MAC Address")]
        protected string MacAddress { get; set; }

        /// <summary>
        /// ComponentInterconnectId.
        /// </summary>
        [JsonProperty("Component Interconnect ID")]
        protected string ComponentInterconnectId { get; set; }
    }
}