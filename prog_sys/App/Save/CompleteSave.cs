using System.Xml.Linq;

namespace Controler
{
    class CompleteSave : ISave
    {
        
        private string saveName;
        private string originPath;
        private string targetPath;
        public CompleteSave(string saveName, string originPath, string targetPath)
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

        public void SaveData()
        {
            File.Copy(Path.Combine(originPath), Path.Combine(targetPath, saveName), true);
            //Console.WriteLine(Path.Combine(sourcePath, fileName));
            Console.WriteLine("File has been copied successfully.");
            Console.ReadLine();
        }
    }
}