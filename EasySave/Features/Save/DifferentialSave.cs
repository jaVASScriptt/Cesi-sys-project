﻿using System;
using EasySafe;
using System.Diagnostics;
using System.IO;
using System.Windows.Input;

namespace Controler
{
    class DifferentialSave : ISave
    {
        private static object lockObject = new object();

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

            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(originPath, "*", SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(originPath, savePath));

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(originPath, "*.*", SearchOption.AllDirectories))
            {
                string origin = newPath;

                string target = newPath.Replace(originPath, savePath);
                
                FileInfo sourceFile = new FileInfo(origin);
                FileInfo targetFile = new FileInfo(target);
                //test if files has been updated
                if (!targetFile.Exists || targetFile.LastWriteTime < sourceFile.LastWriteTime)
                {
                        
                    //Measurement of the current time
                    DateTime startTimeFile = DateTime.Now;

                    //Measurement of the file size
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

                    //Save time: subtract current time - previously measured time
                    DateTime endTimeFile = DateTime.Now;
                    TimeSpan timeSave = endTimeFile - startTimeFile;
                    Double fileSaveTime = timeSave.TotalMilliseconds;

                    //Just take the file name
                    string fileName = Path.GetFileName(target);

                    LanguageTool.print(entry: fileName + ": " + fileSaveTime + " ms, " + size + " octet");

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
                else
                {
                    Console.WriteLine(origin + " has ALREADY been copied."); 
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