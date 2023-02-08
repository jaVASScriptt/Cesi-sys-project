namespace Controler
{
    class DifferentialSave : Save
    {
        public DifferentialSave(string name, string sourcePath, string targetPath) : base(name, sourcePath, targetPath)
        {
        }

        public void CopyFileDifferential(string[] fileNames)
        {
            foreach (string fileName in fileNames)
            {
                FileInfo sourceFile = new FileInfo(Path.Combine(sourcePath, fileName));
                FileInfo targetFile = new FileInfo(Path.Combine(targetPath, fileName));

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
            Console.ReadLine();
        }

    }
}