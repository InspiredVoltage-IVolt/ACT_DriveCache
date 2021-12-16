using ACT.Core.Extensions;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;


namespace ACT.Applications.DriveCache.DB
{
    public static class DBConnectionString
    {
        public static string GetConn()
        {
            string _tmpReturn = ACT.Applications.DriveCache.About.GetString(1);
            Globals.GlobalsExtenal.cn = System.IO.File.ReadAllText(Globals.GlobalsClass.BaseDataDirectory + "Resources\\Data\\DriveCache\\Settings\\DatabaseConnection.enc").DecryptString(_tmpReturn);
            return Globals.GlobalsExtenal.cn;
        }
    }


    internal class DatabaseAPI
    {
        private static bool _Init = false;
        private static SqlConnection _Connection = null;
        private static SqlCommand _Command = null;
        private static DataTable _DataTable = null;

        public static bool IsInitialized { get => _Init; set => _Init = value; }

        public static void Init()
        {
            if (Globals.GlobalsClass.UserID == null) { return; }

            _Connection = new SqlConnection(Globals.GlobalsClass.ConfigurationData.Users.First(x => x.Id == Globals.GlobalsClass.UserID.ToString()).DatabaseConnectionString);
            _Connection.Open();
            if (_Connection.State != System.Data.ConnectionState.Open)
            {
                _Connection.Dispose();
                return;
            }
            _Connection.Close();

            _Init = true;
        }

        public static List<dynamic> GetData(string Query)
        {
            if (_Init == false) { return null; }

            _Connection.Open();
            _Command = _Connection.CreateCommand();
            _Command.CommandText = Query;
            var _Reader = _Command.ExecuteReader(System.Data.CommandBehavior.Default);
            _DataTable = null;
            if (_Reader.HasRows) { _DataTable = _Reader.ToDataTable(); }
            else { _Reader.Dispose(); }

            if (_DataTable == null) { return null; }
            else
            {
                _Command = null;
                return ToDynamic(_DataTable);
            }
        }

        public static List<dynamic> ToDynamic(DataTable dt)
        {
            var dynamicDt = new List<dynamic>();
            foreach (DataRow row in dt.Rows)
            {
                dynamic dyn = new ExpandoObject();
                dynamicDt.Add(dyn);
                foreach (DataColumn column in dt.Columns)
                {
                    var dic = (IDictionary<string, object>)dyn;
                    dic[column.ColumnName] = row[column];
                }
            }
            return dynamicDt;
        }
    }
}
