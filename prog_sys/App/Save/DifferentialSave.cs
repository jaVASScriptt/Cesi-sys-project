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
            FileInfo sourceFile = new FileInfo(Path.Combine(originPath));
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