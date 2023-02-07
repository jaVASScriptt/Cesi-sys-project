using System.Xml.Linq;

namespace Controler
{
    class Save
    {
        private String name;
        private String sourcePath;
        private String targetPath;

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

        public void GetValues()
        {
            Console.WriteLine("Enter file name: ");
            name = Console.ReadLine();

            Console.WriteLine("Enter source path: ");
            sourcePath = Console.ReadLine();

            Console.WriteLine("Enter target path: ");
            targetPath = Console.ReadLine();
        }
        public void checkType()
        {
            Console.WriteLine("Choose the type save");
            Console.WriteLine("1: Complete save");
            Console.WriteLine("2: Differential save");
            String typeNumber = Console.ReadLine();

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
            }

        }
       
    }
}
