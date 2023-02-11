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


        public void SaveData()
        {
            File.Copy(Path.Combine(originPath), Path.Combine(targetPath, saveName), true);
            //Console.WriteLine(Path.Combine(sourcePath, fileName));
            Console.WriteLine("File has been copied successfully.");
            Console.ReadLine();
        }
    }
}