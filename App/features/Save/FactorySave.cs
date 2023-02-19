using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controler
{
    public class FactorySave
    {
        public static ISave? GetSave(string saveName, string originPath, string targetPath, string saveType)
        {
            ISave? newSave;
            switch (saveType) {
                case "Differential":
                    newSave = new DifferentialSave(saveName, originPath, targetPath);
                    break;
                case "Complete":
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