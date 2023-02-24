using System;
using System.Diagnostics;

namespace ConsoleApp2.Features.utils;

public sealed class SingleInstance
{
    public static bool AlreadyRunning()
    {
        bool running = false;
        try
        {
            // Obtention de la collection de processus
            Process currentProcess = Process.GetCurrentProcess();

            // Vérifier avec un autre processus déjà en cours d'exécution   
            foreach (var p in Process.GetProcesses())
            {
                if (p.Id != currentProcess.Id)   
                {
                    if (p.ProcessName.Equals(currentProcess.ProcessName) == true)
                    {
                        running = true;
                        IntPtr hFound = p.MainWindowHandle;
                        if (User32API.IsIconic(hFound)) // Si l'application est en mode ICONIC alors  
                            User32API.ShowWindow(hFound, User32API.SW_RESTORE);
                        User32API.SetForegroundWindow(hFound); // Active la fenêtre, si le processus est déjà en cours d'exécution
                        break;
                    }
                }
            }
        }
        catch
        {
        }

        return running;
    }
}