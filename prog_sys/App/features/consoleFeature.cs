
namespace EasySafe;

public class consoleFeature
{
    public consoleFeature(Feature f)
    {

        Feature feature = f;


        int choice = 0;
        
        while ( choice != 5)
        {
            feature.showTasks();

            Console.WriteLine(Language.featureMenu());

            choice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (choice)
            {
                case 1:
                    Console.WriteLine(Language.numberSaveWork());
                    int index = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(Language.saveNameMessage());
                    string name = Console.ReadLine();

                    Console.WriteLine(Language.originPathMessage());
                    string sourcePath = Console.ReadLine();

                    Console.WriteLine(Language.targetPathMessage());
                    string targetPath = Console.ReadLine();
                    
                    Console.WriteLine(Language.saveType());
                    int type = Convert.ToInt32(Console.ReadLine());

                    feature.addNewTask(index, name, sourcePath, targetPath, 0, 0, 0, 0, type == 1? "complete" : type == 2 ? "differential" : "bad type");

                    break;
                
                case 2 :
                    Console.WriteLine(Language.numberSaveWork());
                    int indexToModify = Convert.ToInt32(Console.ReadLine());
                    
                    Console.WriteLine(Language.saveNameMessage() + Language.editSaveWork());
                    string newName = Console.ReadLine();
                    
                    Console.WriteLine(Language.originPathMessage() + Language.editSaveWork());
                    string newSourcePath = Console.ReadLine();
                    
                    Console.WriteLine(Language.targetPathMessage() + Language.editSaveWork());
                    string newTargetPath = Console.ReadLine();
                    
                    Console.WriteLine(Language.saveType() + Language.editSaveWork());
                    int newType = Convert.ToInt32(Console.ReadLine());
                    
                    TaskData task = feature.getTask(indexToModify);
                    
                    feature.addNewTask(indexToModify, 
                        Name: newName == "" ? task.Name : newName, 
                        SourceFilePath: newSourcePath == "" ? task.SourceFilePath : newSourcePath, 
                        TargetFilePath: newTargetPath == "" ? task.TargetFilePath : newTargetPath,
                        task.TotalFilesToCopy, task.TotalFilesSize, task.NbFilesLeftToDo, task.Progression,
                        Type: newType == 1 ? "complete" : newType == 2 ? "differential" : task.Type);
                break;
                
                case 3 :
                    Console.WriteLine(Language.deleteSaveWork());
                    int indexToDelete = Convert.ToInt32(Console.ReadLine());

                    feature.factoryFillOneState(indexToDelete);
                break;
                
                case 4 :
                    Console.WriteLine(Language.deleteAllSaveWork());
                    int confirm = Convert.ToInt32(Console.ReadLine());
                    
                    if (confirm == 1)
                    {
                        feature.factoryFillState();
                    }
                    break;
                default:
                    break;
            }
            Console.Clear();

        }


    }
    
}