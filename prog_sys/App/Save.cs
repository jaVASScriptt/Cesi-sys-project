using System.Xml.Linq;

namespace Controler
{
    class Save
    {
        internal String name;
        internal String sourcePath;
        internal String targetPath;

        public Save(String name, String sourcePath, String targetPath)
        {
            this.name = name;
            this.sourcePath = sourcePath;
            this.targetPath = targetPath;
        }

        public String getName()
        {
            return name;
        }

        public String getSourcePath()
        {
            return sourcePath;
        }

        public String getTargetPath()
        {
            return targetPath;
        }

        
        public void checkType(Save save)
        {
            Console.WriteLine("Choose the type save");
            Console.WriteLine("1: Complete save");
            Console.WriteLine("2: Differential save");
            String typeNumber = Console.ReadLine();

            /*
            switch (typeNumber)
            {
                case "1":
                    Console.WriteLine("Ok for complete save");
                    CompleteSave saveC = new CompleteSave();
                    saveC.CopyFile();
                    break;
                case "2":
                    Console.WriteLine("Ok differential save");
                    DifferentialSave saveD = new DifferentialSave();
                    break;
                default:
                    Console.WriteLine("Sorry we don't understand your request");
                    break;
            }*/

            if (typeNumber == "1")
            {
                Console.WriteLine("Ok for complete save");
                /*name = save.getName();
                sourcePath = save.getSourcePath();
                targetPath = save.getTargetPath();*/
                CompleteSave saveC = new CompleteSave(name, sourcePath, targetPath);
                saveC.CopyFile(saveC);
            }
            else if (typeNumber == "2")
            {
                Console.WriteLine("Ok differential save");
            }
            else
            {
                Console.WriteLine("Sorry we don't understand your request");
            }

        }

    }
}
