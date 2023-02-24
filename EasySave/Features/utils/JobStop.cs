using System;
using System.Diagnostics;
using System.Threading;

static class JobStop
{
    // name of the software to check
    private static string[] softwareName = {""};

    // Set the names of software processes to stop.
    public static void setSoftwareName(string[] software)
    {
        softwareName = software;
    }

    // Start the process to stop the software processes.
    public static void startProcess()
    {
        // Wait 5 seconds before starting the process.
        System.Threading.Thread.Sleep(5000);

        // Start a new thread to run the start method.
        Thread thread = new Thread(new ThreadStart(start));
        thread.Start();
    }

    // Get the names of software processes to stop.
    public static string[] getSoftwareName()
    {
        return softwareName;
    }

    // Check if the softwareName array has been updated.
    private static bool notUpdate(string[] softwares)
    {
        bool x = true;
        if (softwareName.Length == softwares.Length)
        {
            for (int i = 0; i < softwares.Length; i++)
            {
                if (x)
                {
                    x = (softwareName[i] == softwares[i]);
                }
            }
        }
        return x;
    }

    // Method executed in a new thread to stop software processes.
    static void start()
    {
        string[] lastSoftware = softwareName;

        while (notUpdate(lastSoftware))
        {
            foreach (string software in lastSoftware)
            {
                Process[] processes = Process.GetProcessesByName(software);

                if (processes.Length > 0)
                {
                    foreach (Process process in processes)
                    {
                        try
                        {
                            process.WaitForExit();
                        }
                        catch
                        {
                        }
                    }
                }
            }

            // Wait 5 seconds before checking the softwareName array again.
            System.Threading.Thread.Sleep(5000);
        }
    }

}