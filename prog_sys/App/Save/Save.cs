﻿using System.Xml.Linq;

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

        
        public void checkType(String[] fileNames)
        {
            Console.WriteLine(Language.saveType());
            String typeNumber = Console.ReadLine();

            if (typeNumber == "1")
            {
                Console.WriteLine("Ok for complete save");
                CompleteSave saveC = new CompleteSave(name, sourcePath, targetPath);
                saveC.CopyFileComplete(fileNames);
            }
            else if (typeNumber == "2")
            {
                Console.WriteLine("Ok for differential save");
                DifferentialSave saveD = new DifferentialSave(name, sourcePath, targetPath);
                saveD.CopyFileDifferential(fileNames);
            }
            else
            {
                Console.WriteLine("Sorry we don't understand your request");
            }

        }
        
        

    }
}
