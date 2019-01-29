using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITI_UITest.Models;

namespace ITI_UITest.ViewModels
{
    public class TabControlVM
    {
        UITestModel _model;

        public TabControlVM(UITestModel model)
        {
            _model = model;
            Errors = model.Projects.First().GetErrorsResult();
            Console = model.Projects.First().GetConsoleResult();
        }
        public string Errors { get; private set; }
        public string Console { get; private set; }
    }
}
