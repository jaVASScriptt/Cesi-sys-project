using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controler
{
    static class SaveTool
    {
        private static string[] fileToCrypt = { ".txt" };
        private static string key = "6c725567f66ec87d";

        public static void setFilesToCrypt(string[] files)
        {
            fileToCrypt = files;
        }

        public static string[] getFilesToCrypt()
        {
            return fileToCrypt;
        }

        public static void setKey(string newKey)
        {
            key = newKey;
        }

        public static string getKey()
        {
            return key;
        }

        public static bool CryptedExtension(string extension)
        {
            bool crypt = false;
            foreach (string ext in fileToCrypt)
            {
                if (!crypt)
                {
                    crypt = (extension == ext);
                }
            }
            return crypt;
        }
    }
}
