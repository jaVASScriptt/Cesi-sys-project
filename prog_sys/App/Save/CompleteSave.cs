using System.Xml.Linq;

namespace Controler
{
    class CompleteSave : Save
    {
        public CompleteSave(string name, string sourcePath, string targetPath) : base(name, sourcePath, targetPath)
        {
        }

        public void CopyFile()
        {
            File.Copy(Path.Combine(sourcePath, name), Path.Combine(targetPath, name), true);
            Console.WriteLine(Path.Combine(sourcePath, name));
            Console.WriteLine("File has been copied successfully.");
            Console.ReadLine();

        }
    }
}