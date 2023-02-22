﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ConsoleApp2.Features.utils;

namespace EasySave
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            if (SingleInstance.AlreadyRunning())
            {
                App.Current.Shutdown(); // Just shutdown the current application,if any instance found.  
            }
            else
            {
                Server.ServerStart();
            }
            base.OnStartup(e);
        }
    }
}