using System.Diagnostics;
using System.IO;

namespace Controler
{
    class DifferentialSave : ISave
    {
        private string originPath;        
        private string targetPath;
        private string saveName;
        public DifferentialSave(string saveName, string originPath, string targetPath)
        {
            this.saveName = saveName;
            this.originPath = originPath;
            this.targetPath = targetPath;
        }


        public string getName()
        {
            return saveName;
        }
        public string getSourcePath()
        {
            return originPath;
        }
        public string getTargetPath()
        {
            return targetPath;
        }

        public void SaveData()
        {
            string savePath = Path.Combine(targetPath, saveName);
            Directory.CreateDirectory(savePath);
            savePath = Path.Combine(savePath, new DirectoryInfo(originPath).Name);
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(originPath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(originPath, savePath));
            }

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(originPath, "*.*", SearchOption.AllDirectories))
            {
                FileInfo sourceFile = new FileInfo(newPath);
                FileInfo targetFile = new FileInfo(newPath.Replace(originPath, savePath));
                //test if files has been updated
                if (!targetFile.Exists || targetFile.LastWriteTime < sourceFile.LastWriteTime)
                {
                    // mesure de l'heure actuel
                    // mesure de la taille du fichier
                    File.Copy(newPath, newPath.Replace(originPath, savePath), true);
                    Console.WriteLine(newPath + " has been copied successfully.");
                    // temps de sauvegarde : soutstratction de l'heure actuel - l'heure mesuré précédemment
                    // creation d'une log
                }
            }
        }
    }
}