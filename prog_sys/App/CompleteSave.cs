using System.Xml.Linq;

namespace Controler
{
    class CompleteSave : Save
    {
        public void CopyFile()
        {
            File.Copy(getSourcePath + "/" + getName, getTargetPath + "/" + getName, true);
            Console.WriteLine("File has been copied successfully.");
        }
    }
}