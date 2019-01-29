using System;
using System.Collections.Generic;
using System.Text;
using ITI_UITest.Models;

namespace ITI_UITest.ViewModels
{
    public class MainViewVM : ViewModelBase
    {
        UITestModel _model;

        public MainViewVM(UITestModel model)
        {
            _model = model;
            TreeVM = new TreeViewVM(model);
            TabControlVM = new TabControlVM(model);
            RunTestVM = new RunTestVM(model);
        }

        public TreeViewVM TreeVM { get; }
        public TabControlVM TabControlVM { get; }
        public RunTestVM RunTestVM { get; }
    }
}
