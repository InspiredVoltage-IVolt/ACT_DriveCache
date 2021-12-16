using ACT.Core.Extensions;

namespace ACT.Applications.DriveCache
{
    public static class SetupTestConfiguration
    {
        /// <summary>
        ///    
        /// </summary>
        public static void InitTestConfiguration()
        {
            string _UserID = Guid.NewGuid().ToString();
            string _MachioneID = Guid.NewGuid().ToString();
            string _Path1ID = Guid.NewGuid().ToString();
            string _Path2ID = Guid.NewGuid().ToString();

            ConfigurationData configurationData = new ConfigurationData();
            var cd = configurationData;
            cd.Users = new List<User>();
            cd.Users.Add(new User()
            {
                DatabaseConnectionString = "Data Source=ns-sql-01;Initial Catalog=ACT_DriveCache;User ID=root;Password=K@iserB3lla!MS",
                Id = _UserID,
                Lastlogin = DateTime.Now.ToString(),
                Password = "asdasd",
                Securitylevel = 0,
                Username = Environment.UserDomainName + "--" + Environment.UserName,
                Mainmachine = Environment.MachineName,
                Actid = Guid.NewGuid().ToString()
            });

            cd.Machines = new List<Machine>();
            cd.Machines.Add(new Machine()
            {
                Id = _MachioneID,
                Name = Environment.MachineName,
                Paths = new List<Path>()
            }); ;

            var _P1 = new Path()
            {
                Encryption = false,
                Userid = _UserID,
                Id = _Path1ID,
                PathPath = "Z:\\Applications_New\\",
                Pattern = "*.*",
                Recursive = true
            };
            var _P2 = new Path()
            {
                Encryption = false,
                Userid = _UserID,
                Id = _Path2ID,
                PathPath = "Z:\\Assets\\",
                Pattern = "*.*",
                Recursive = true,
            };

            cd.Machines[0].Paths.Add(_P1);
            cd.Machines[0].Paths.Add(_P2);

            cd.Searchdefinitions = new List<Searchdefinition>();

            var S1 = new Searchdefinition()
            {
                Id = Guid.NewGuid().ToString(),
                Userid = _UserID,
                Hoursbetweenupdate = 22,
                Lastrundate = "11/1/2021",
                Totalindexeditems = 0,
                Name = "New Appllications Path"
            };
            var S2 = new Searchdefinition()
            {
                Id = Guid.NewGuid().ToString(),
                Userid = _UserID,
                Hoursbetweenupdate = 22,
                Lastrundate = "11/1/2021",
                Totalindexeditems = 0,
                Name = "All Assets Path"
            };

            cd.Searchdefinitions.Add(S1);
            cd.Searchdefinitions.Add(S2);
            cd.DatabaseConnectionString = "Data Source=ns-sql-01;Initial Catalog=ACT_DriveCache;User ID=root;Password=K@iserB3lla!MS";

            Globals.GlobalsExtenal.SetData(cd);

            cd.ToJson().SaveAllText(@"D:\IVolt_Development\ACT_DriveCache\ACT_DriveCache\ACT_DriveCacheSolution\ACT_DriveCache\Resources\Data\DriveCache\Template\ConfigurationData.json");
        }
    }
}
