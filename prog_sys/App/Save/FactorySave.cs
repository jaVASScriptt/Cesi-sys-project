using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controler
{
    public class FactorySave
    {
        public Save getSave(string saveName, string originPath, string targetPath, string type)
        {
            Save newSave;
            switch (type) {
                case "Complete":
                    newSave = new DifferentialSave(saveName, originPath, targetPath);
                    break
                case "Differential":
                    newSave = new CompleteSave(saveName, originPath, targetPath);
                    break;
                default:
                    newSave = null;
                    break;
            }
            return newSave;
        }
    }
}
