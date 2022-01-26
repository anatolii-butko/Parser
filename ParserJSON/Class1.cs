namespace ParserJSON
{
    public class Rootobject
    {
        public InterfaceSettings InterfaceSettings { get; set; }
        public MediaInterfaceSettings MediaInterfaceSettings { get; set; }
        public PortSettings PortSettings { get; set; }
        public UniqueID UniqueID { get; set; }
        public MACAddress MACAddress { get; set; }
        public ComponentInterconnectID ComponentInterconnectID { get; set; }
    }

    public class InterfaceSettings
    {
        public string _1th_interface { get; set; }
        public string _2nd_interface { get; set; }
    }

    public class MediaInterfaceSettings
    {
        public NetworkStatusIndicatorConfiguration1 NetworkStatusIndicatorConfiguration1 { get; set; }
        public HardwareTimeout HardwareTimeout { get; set; }
    }

    public class NetworkStatusIndicatorConfiguration1
    {
        public bool CONF1_ENABLE { get; set; }
        public int PACKAGE_ID { get; set; }
        public bool CONF2 { get; set; }
        public int VERSION { get; set; }
        public bool CONF3 { get; set; }
        public bool CONF4 { get; set; }
        public int PACKAGE_ID_PROTOCOL_0 { get; set; }
        public int PACKAGE_ID_PROTOCOL_1 { get; set; }
        public int READ_PACKAGE_ID_FROM_PROTOCOL { get; set; }
    }

    public class HardwareTimeout
    {
        public int TIMEOUT { get; set; }
    }

    public class PortSettings
    {
        public int SET_0 { get; set; }
        public int SET_1 { get; set; }
        public int SET_2 { get; set; }
        public int SET_3 { get; set; }
        public int SET_4 { get; set; }
        public int SET_5 { get; set; }
        public int SET_6 { get; set; }
        public int SET_7 { get; set; }
    }

    public class UniqueID
    {
        public int TIME_0 { get; set; }
        public int TIME_1 { get; set; }
        public int TIME_2 { get; set; }
        public int TIME_3 { get; set; }
        public int TIME_4 { get; set; }
        public int NODE_0 { get; set; }
        public int NODE_1 { get; set; }
        public int NODE_2 { get; set; }
    }

    public class MACAddress
    {
        public string MAC_0 { get; set; }
    }

    public class ComponentInterconnectID
    {
        public int DEVICE_0_ID { get; set; }
        public int ID_0 { get; set; }
        public int ID_1 { get; set; }
        public int ID_2 { get; set; }
        public int ID_3 { get; set; }
        public int ID_4 { get; set; }
        public int ID_5 { get; set; }
        public int ID_6 { get; set; }
        public int ID_7 { get; set; }
        public int DEVICE_1_ID { get; set; }
    }

}