using System;
using System.Collections.Generic;
using System.Text;
using ITI_UITest.Models;

namespace ITI_UITest.ViewModels
{
    public class RunTestVM
    {
        UITestModel _model;
        public RunTestVM(UITestModel model)
        {
            _model = model;
        }
        public bool IsRunning => _model.IsRunning;
        public int Value => _model.IsFinish ? 100 : 0;
        public void Start()
        {
            _model.Run();
        }
    }
}
