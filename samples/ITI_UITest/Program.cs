﻿using System;
using System.Linq;
using Avalonia;
using Avalonia.Logging.Serilog;
using ITI_UITest.ViewModels;
using ITI_UITest.Views;

namespace ITI_UITest
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildAvaloniaApp().Start<MainWindow>(() => new MainWindowVM(args.First()));
        }

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .UseReactiveUI()
                .LogToDebug();
    }
}
