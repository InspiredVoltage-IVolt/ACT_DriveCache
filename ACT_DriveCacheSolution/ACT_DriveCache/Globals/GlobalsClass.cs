namespace ACT.Applications.DriveCache.Globals
{
    public static class GlobalsExtenal
    {
        public static string cn;
        public static void SetData(ConfigurationData d)
        {
            GlobalsClass.ConfigurationData = d;
        }
    }
    internal static class GlobalsClass
    {
        private static Guid? _UserID = null;
        private static Guid? _MachineID = null;

        internal static ConfigurationData ConfigurationData { get; set; }
        internal static Guid? UserID { get { return _UserID; } set { _UserID = value; } }
        internal static Guid? MachineID { get { return _MachineID; } set { _MachineID = value; } }

        internal static string BaseDataDirectory = AppDomain.CurrentDomain.BaseDirectory + "Resources\\Data\\DriveCache\\";
    }
}
