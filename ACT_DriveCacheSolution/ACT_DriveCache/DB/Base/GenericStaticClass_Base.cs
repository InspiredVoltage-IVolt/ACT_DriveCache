using ACT.Core.Interfaces.DataAccess;

namespace NameSpace.ACT_DriveCache
{
    public static class GenericStaticClass
    {
        public static string DatabaseConnectionName = "ACT_DriveCache_connectionstring";
        public static string DatabaseConnectionString { get { return ""; } }
        public static I_DataAccess GetDataAccess(bool OpenDB)
        {
            var _TmpReturn = ACT.Core.CurrentCore<I_DataAccess>.GetCurrent();

            if (_TmpReturn == null)
            {
                ACT.Core.Helper.ErrorLogger.LogError("unable to create instance of I_DataAccess", "Check Plugin Configuration", null, ErrorLevel.Warning);
                return null;
            }

            if (OpenDB)
            {
                if (_TmpReturn.Open(DatabaseConnectionString) == false) { return null; }
            }

            return _TmpReturn;
        }
    }
}
