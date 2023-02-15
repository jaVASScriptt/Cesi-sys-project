using EasySafe;
using System.Security.Cryptography.X509Certificates;

namespace Controler
{
    class CompleteSave : ISave
    {
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

        LogAndStateTool logFile = LogAndStateTool.Instance;

        public void SaveData(int? i = null)
        {
            if (i != null)
                logFile.changeState((int)i);

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
                //Measurement of the current time
                DateTime startTimeFile = DateTime.Now;

                //Measurement of the file size
                FileInfo fileInfo = new FileInfo(newPath);
                long size = fileInfo.Length;

                File.Copy(newPath, newPath.Replace(originPath, savePath), true);

                //Save time: subtract current time - previously measured time
                DateTime endTimeFile = DateTime.Now;
                TimeSpan timeSave = endTimeFile - startTimeFile;
                Double fileSaveTime = timeSave.TotalMilliseconds;

                //Just take the file name
                string fileName = Path.GetFileName(newPath);

                Console.WriteLine(fileName + ": " + fileSaveTime + " ms, " + size + " octet");

                if (i== null)
                {
                    logFile.addLog(name: saveName, SourceFilePath: Path.Combine(originPath, fileName), TargetFilePath: Path.Combine(targetPath, fileName), success: "success", FileSize: size, FileTransferTime: fileSaveTime);
                }
                else
                {
                    logFile.addLog(task:(int)i, SourceFilePath: Path.Combine(originPath, fileName), TargetFilePath: Path.Combine(targetPath, fileName), success: "success", FileSize: size, FileTransferTime: fileSaveTime);
                }
                //Create a log for each file

                logFile.setTask(index:(int)i, NbFilesLeftToDo: logFile.getTask((int)i).NbFilesLeftToDo - 1, Progression: 100 - (logFile.getTask((int)i).NbFilesLeftToDo*100/logFile.getTask((int)i).TotalFilesToCopy));

                //Thread.Sleep(2000);
            }
            logFile.setTask(index: (int)i, NbFilesLeftToDo: 0);
            

            //Thread.Sleep(2000);
            if (i != null)
            {
                logFile.changeState((int)i);
                logFile.setTask(index: (int)i, NbFilesLeftToDo: logFile.getTask((int)i).TotalFilesToCopy);
                logFile.setTask(index: (int)i, Progression: 0);
            }


        }
    }
}