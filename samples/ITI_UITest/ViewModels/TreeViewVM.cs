using System;
using System.Collections.Generic;
using System.Text;
using ITI_UITest.Models;

namespace ITI_UITest.ViewModels
{
    public class TreeViewVM
    {

        public TreeViewVM(UITestModel model)
        {
            Model = model;
        }
        public UITestModel Model {get;}
        public List<TestProject> Projects => Model.Projects;
    }
}
