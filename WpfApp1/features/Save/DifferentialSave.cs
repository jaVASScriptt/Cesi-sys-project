using System;
using EasySafe;
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
                FileInfo sourceFile = new FileInfo(newPath);
                FileInfo targetFile = new FileInfo(newPath.Replace(originPath, savePath));
                //test if files has been updated
                if (!targetFile.Exists || targetFile.LastWriteTime < sourceFile.LastWriteTime)
                {
                    //Measurement of the current time
                    DateTime startTimeFile = DateTime.Now;

                    //Measurement of the file size
                    FileInfo fileInfo = new FileInfo(newPath);
                    long size = fileInfo.Length;

                    //Copy all the files
                    File.Copy(newPath, newPath.Replace(originPath, savePath), true);
                    Console.WriteLine(newPath + " has been copied successfully.");

                    //Save time: subtract current time - previously measured time
                    DateTime endTimeFile = DateTime.Now;
                    TimeSpan timeSave = endTimeFile - startTimeFile;
                    Double fileSaveTime = timeSave.TotalMilliseconds;

                    //Just take the file name
                    string fileName = Path.GetFileName(newPath);

                    Console.WriteLine(fileName + ": " + fileSaveTime + " ms, " + size + " octet");

                    if (i == null)
                    {
                        //Create a log for each file
                        
                        if (i != null)
                            logFile.addLog(name: saveName, SourceFilePath: Path.Combine(originPath, fileName), TargetFilePath: Path.Combine(targetPath, fileName), success: "success", FileSize: size, FileTransferTime: fileSaveTime);
                    }
                    else
                    {
                        //Create a log for each file
                        logFile.addLog(task: (int)i, SourceFilePath: Path.Combine(originPath, fileName), TargetFilePath: Path.Combine(targetPath, fileName), success: "success", FileSize: size, FileTransferTime: fileSaveTime);
                    }
                    if (i != null)
                        logFile.setTask(index: (int)i, NbFilesLeftToDo: 0);
                    //Thread.Sleep(2000);


                }
                else
                {
                    Console.WriteLine(newPath + " has ALREADY been copied.");

                }
            }
            if (i != null)
            {
                logFile.changeState((int)i);
                logFile.setTask(index: (int)i, NbFilesLeftToDo: logFile.getTask((int)i).TotalFilesToCopy);
                logFile.setTask(index: (int)i, Progression: 0);
            }
        }
                
    }
}