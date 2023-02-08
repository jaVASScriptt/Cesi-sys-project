using System.Xml.Linq;

namespace Controler
{
    class CompleteSave : Save
    {
        public CompleteSave(string name, string sourcePath, string targetPath) : base(name, sourcePath, targetPath)
        {
        }

        public void CopyFile(string[] fileNames)
        {
            foreach (string fileName in fileNames)
            {
                File.Copy(Path.Combine(sourcePath, fileName), Path.Combine(targetPath, fileName), true);
                Console.WriteLine(Path.Combine(sourcePath, fileName));
            }

            Console.WriteLine("File has been copied successfully.");
            Console.ReadLine();

        }
    }
}