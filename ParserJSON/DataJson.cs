namespace ParserJson
{

    #region Using

    using System.Collections;
    using System.Collections.Generic;
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
        public Dictionary<string, string> InterfaceSettings { get; set; }

        /// <summary>
        /// MediaInterfaceSettings.
        /// </summary>
        [JsonProperty("Media Interface Settings")]
        public Dictionary<string, Dictionary<string, string>> MediaInterfaceSettings { get; set; }

        /// <summary>
        /// PortSettings.
        /// </summary>
        [JsonProperty("Port Settings")]
        public Dictionary<string, string> PortSettings { get; set; }

        /// <summary>
        /// UniqueId.
        /// </summary>
        [JsonProperty("Unique ID")]
        public Dictionary<string, string> UniqueId { get; set; }

        /// <summary>
        /// MacAddress.
        /// </summary>
        [JsonProperty("MAC Address")]
        public Dictionary<string, string> MacAddress { get; set; }

        /// <summary>
        /// ComponentInterconnectId.
        /// </summary>
        [JsonProperty("Component Interconnect ID")]
        public Dictionary<string, string> ComponentInterconnectId { get; set; }
    }
}