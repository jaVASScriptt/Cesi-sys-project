using System;
using System.IO;
using EasySafe;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using EasySave.Features.Language;
using EasySave.Features.LogAndState.Tools;


namespace Controler
{
    class CompleteSave : ISave
    {
        private static object lockObject = new object();

        private string originPath;
        private string targetPath;
        private string saveName;
        public CompleteSave(string saveName, string originPath, string targetPath)
        {
            this.saveName = saveName;
            this.originPath = originPath;
            this.targetPath = targetPath;
        }


        public string getSaveName()
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

        public void saveData(int? i = null)
        {
            if (i != null)
            {
                LogAndStateTool.changeState((int)i);
            }
                

            string savePath = Path.Combine(targetPath, saveName);
            Directory.CreateDirectory(savePath);
            savePath = Path.Combine(savePath, new DirectoryInfo(originPath).Name);
            Directory.CreateDirectory(savePath);

            //Créez maintenant tous les répertoires
            foreach (string dirPath in Directory.GetDirectories(originPath, "*", SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(originPath, savePath));

        
            //Sauvegarde tous les fichiers et écrase n'importe quel fichier qui a le même nom
            foreach (string newPath in Directory.GetFiles(originPath, "*.*", SearchOption.AllDirectories))
            {
                string origin = newPath;
                
                string target = newPath.Replace(originPath, savePath);
                //Mesure de l'heure actuelle
                DateTime startTimeFile = DateTime.Now;

                //Mesure de la taille du fichier
                FileInfo fileInfo = new FileInfo(origin);
                long size = fileInfo.Length;

                try
                {
                    File.Copy(origin, target, true);
                }
                catch (Exception ex)
                {

                }

                //cryptage
                if (SaveTool.CryptedExtension(Path.GetExtension(newPath)))
                {
                    string cryptosoftPath = AppDomain.CurrentDomain.BaseDirectory + "../../../Features/Cryptosoft/Cryptosoft.exe";
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = cryptosoftPath;
                    startInfo.Arguments = $"{origin} {target} {SaveTool.getKey()}";

                    Process.Start(startInfo);
                }

                //Calcul du temp de sauvegarde
                
                DateTime endTimeFile = DateTime.Now;
                TimeSpan timeSave = endTimeFile - startTimeFile;
                Double fileSaveTime = timeSave.TotalMilliseconds;

                //Prend le nom de fichier
                string fileName = Path.GetFileName(target);

                lock (lockObject)
                {
                    if (i != null)
                    {
                        int nbfiles = LogAndStateTool.getTask((int)i).NbFilesLeftToDo;
                        int nbfilesCopy = LogAndStateTool.getTask((int)i).TotalFilesToCopy;

                        LogAndStateTool.addLog(task: (int)i, SourceFilePath: Path.Combine(originPath, fileName), TargetFilePath: Path.Combine(targetPath, fileName), success: "success", FileSize: size, FileTransferTime: fileSaveTime);
                        LogAndStateTool.setTask(index: (int)i, NbFilesLeftToDo: nbfiles - 1, Progression: 100 - nbfiles * 100 / nbfilesCopy);
                    }
                    else
                    {
                        LogAndStateTool.addLog(name: saveName, SourceFilePath: Path.Combine(originPath, fileName), TargetFilePath: Path.Combine(targetPath, fileName), success: "success", FileSize: size, FileTransferTime: fileSaveTime);
                    }
                }
            }

            if (i != null)
            {
                LogAndStateTool.changeState((int)i);
                LogAndStateTool.setTask(index: (int)i, NbFilesLeftToDo: LogAndStateTool.getTask((int)i).TotalFilesToCopy);
            }
            
        }
    }
}