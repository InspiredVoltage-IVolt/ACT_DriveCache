using ACT.Core.Extensions;

namespace ACT.Applications.DriveCache.Core
{
    public class DriveCacheManagement
    {
        DriveCacheManagement(string UN, string PW)
        {
            if (Globals.GlobalsClass.ConfigurationData == null) { LoadConfig(); }
            if (Globals.GlobalsClass.ConfigurationData == null) { throw new Exception("Invalid Configuration Data File. ReRun Setup"); }
            if (Globals.GlobalsClass.ConfigurationData.Users.Exists(x => x.Username == UN && x.Password == PW.ToSHA512Hash(true)))
            {
                var _User = Globals.GlobalsClass.ConfigurationData.Users.First(x => x.Username == UN && x.Password == PW.ToSHA512Hash(true));
                Guid? _tmpReturn = _User.Id.ToGuid();
                if (_tmpReturn == null) { throw new Exception("Invalid Configuration Data File - USER ID INVALID. ReRun Setup"); }
                Globals.GlobalsClass.UserID = _tmpReturn.Value;
            }

            if (Globals.GlobalsClass.ConfigurationData.Machines.Exists(x => x.Name == Environment.MachineName))
            {
                var _Machine = Globals.GlobalsClass.ConfigurationData.Machines.First(x => x.Name == Environment.MachineName);
                Guid? _tmpReturn = _Machine.Id.ToGuid();
                if (_tmpReturn == null) { throw new Exception("Invalid Configuration Data File - Missing Machine"); }
                Globals.GlobalsClass.MachineID = _tmpReturn.Value;
            }

            DB.DatabaseAPI.Init();
            if (DB.DatabaseAPI.IsInitialized == false) { throw new Exception("Errors During Initialization"); }
        }

        public static void LoadConfig()
        {
            string _AppConfigPath = Globals.GlobalsClass.BaseDataDirectory + "\\Template\\ConfigurationData.json";

            if (_AppConfigPath.FileExists() == false) { throw new Exception("Please Run Setup To Configure.  Missing Configuration Data File"); }

            try
            {
                Globals.GlobalsClass.ConfigurationData = ConfigurationData.FromJson(_AppConfigPath.ReadAllText());
            }
            catch
            {
                throw new Exception("Invalid Configuration Data File. ReRun Setup");
            }
        }

        public void StartCataloging(List<string> StartingPaths)
        {
            Guid _StartingCatalogJobID = Guid.NewGuid();
            var _Job = Globals.GlobalsClass.BaseDataDirectory + "\\Jobs\\" + _StartingCatalogJobID.ToString().Replace("-", "") + "\\JobData.txt";
            _Job.CreateDirectoryStructure();

            List<string> AllPaths = new List<string>();
            foreach (var p in StartingPaths) { AllPaths.AddRange(p.GetAllSubDirectories()); }
            // Save To Job File
            AllPaths.SaveToFile(_Job, true);

            long _FileCount = 0;
            // Calculate Total File Count
            Parallel.ForEach(AllPaths, path =>
            {
                //int c = ACT.Core.Extensions.String_FileIO.GetF0000();
                Interlocked.Add(ref _FileCount, c);
            });

        }
    }
}
