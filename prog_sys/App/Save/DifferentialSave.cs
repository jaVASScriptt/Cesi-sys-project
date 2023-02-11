namespace Controler
{
    class DifferentialSave : ISave
    {
        private string saveName;
        private string originPath;
        private string targetPath;
        public DifferentialSave(string saveName, string originPath, string targetPath)
        {
            this.saveName = saveName;
            this.originPath = originPath;
            this.targetPath = targetPath;
        }

        /*
        public void CopyFileComplete(string[] fileNames)
        {
            foreach (string fileName in fileNames)
            {
                File.Copy(Path.Combine(sourcePath, fileName), Path.Combine(targetPath, fileName), true);
                Console.WriteLine(Path.Combine(sourcePath, fileName));
            }

            Console.WriteLine("File has been copied successfully.");
            Console.ReadLine();

        }
        */

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

        /*

        public void CopyFileDifferential(string[] fileNames)
        {
            foreach (string fileName in fileNames)
            {
                FileInfo sourceFile = new FileInfo(Path.Combine(sourcePath, fileName));
                FileInfo targetFile = new FileInfo(Path.Combine(targetPath, fileName));

                if (!targetFile.Exists || targetFile.LastWriteTime < sourceFile.LastWriteTime)
                {
                    File.Copy(sourceFile.FullName, targetFile.FullName, true);
                    Console.WriteLine(sourceFile.FullName + " has been copied successfully.");
                }
                else
                {
                    Console.WriteLine(sourceFile.FullName + " has not been modified and was not copied.");
                }
            }
            Console.ReadLine();
        }*/

        public void SaveData()
        {
            FileInfo sourceFile = new FileInfo(originPath);
            FileInfo targetFile = new FileInfo(Path.Combine(targetPath, saveName));

            if (!targetFile.Exists || targetFile.LastWriteTime < sourceFile.LastWriteTime)
            {
                File.Copy(sourceFile.FullName, targetFile.FullName, true);
                Console.WriteLine(sourceFile.FullName + " has been copied successfully.");
            }
            else
            {
                Console.WriteLine(sourceFile.FullName + " has not been modified and was not copied.");
            }
        }

    }
}