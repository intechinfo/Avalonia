﻿using System;
using System.Collections.Generic;
using System.Text;
using Avalonia.Controls;
using ITest.Runner;
using ITI_UITest.Models;

namespace ITI_UITest.ViewModels
{
    public class MainWindowVM : ViewModelBase
    {
        MainViewVM _mainViewVM;
        public MainWindowVM(string dllPath)
        {
            DllPath = dllPath;
            _mainViewVM = new MainViewVM(LoadDll());

        }
        public MainWindowVM()
        {
        }
        public string DllPath { get; set; }
        public async void Open()
        {
            var dialog = new OpenFileDialog();
            dialog.AllowMultiple = false;
            var result = await dialog.ShowAsync();

            if (result != null)
            {
                foreach (var path in result)
                {
                    DllPath = path;
                }
            }
            LoadDll();
        }
        public void Close()
        {
            DllPath = null;
        }
        private UITestModel LoadDll()
        {
            if (string.IsNullOrWhiteSpace(DllPath)) throw new ArgumentNullException("DllPath should not be null");
            try
            {
                //ProjectManager pm = new ProjectManager(DllPath, DllPath.Remove(DllPath.Length - 4));
                XMLConverter xml = new XMLConverter();
                UITestModel um = xml.CreateUITestModel(@"‪Discovered.xml");
                return um;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public MainViewVM MainViewVM => _mainViewVM;
    }
}