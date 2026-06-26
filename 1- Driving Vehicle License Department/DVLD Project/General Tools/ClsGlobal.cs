using System;
using System.IO;
using DVLD_BusinessLayer;

namespace DVLD_Project.General_Tools
{
    static class ClsGlobal
    {
        public static ClsUser GlobalUser;
        public static void DownloadDataFromFile(ref string UserName, ref string Password)
        {

            FileInfo fileInfo = new FileInfo("Login_Info.txt");
             
            if (fileInfo.Exists && fileInfo.Length != 0)
            {
                string[] LoginInfo = File.ReadAllLines("Login_Info.txt");

                UserName = LoginInfo[0];
                Password = LoginInfo[1];

                return;
            }

            UserName = "";
            Password = "";

        }
        public static void UploadDataToFile(string UserName ="", string Password="")
        {
            File.WriteAllLines("Login_Info.txt", new string[] { UserName, Password });

        }
        public static int AmountExpirationInternationalDate { get { return 2; } }
    
    }
}
