namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {

            string _D = ACT.Core.Security.Encryption.EncryptString(@"D:\IVolt_Development\ACT_DriveCache\ACT_DriveCache\ACT_DriveCacheSolution\ACT_DriveCache\Resources\Data\DriveCache\Settings\DatabaseConnection.txt", "34235t43tgf43g34g34");

            //var _ConfigData = ACT.Applications.DriveCache.ConfigurationData.FromJson(@"D:\IVolt_Development\ACT_DriveCache\ACT_DriveCache\ACT_DriveCacheSolution\ACT_DriveCache\Resources\Data\DriveCache\Template\ConfigurationData.json".ReadAllText());

            // Console.WriteLine("ASDASDA");

            //ACT.Applications.DriveCache.SetupTestConfiguration.InitTestConfiguration();
        }
    }
}