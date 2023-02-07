using System.Xml.Linq;

namespace Controler
{
    class CompleteSave : Save
    {
        public CompleteSave(string name, string sourcePath, string targetPath) : base(name, sourcePath, targetPath)
        {
        }

        public void CopyFile(CompleteSave save)
        {
            File.Copy(sourcePath + "\\" + name, targetPath + "\\" + name, true);
            Console.WriteLine(sourcePath + "\\" + name, targetPath + "\\" + name);
            Console.WriteLine("File has been copied successfully.");
            Console.ReadLine();

        }
    }
}