using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using ITI_UITest.Models;

namespace ITI_UITest.ViewModels
{
    public class TreeViewVM : INotifyPropertyChanged
    {

        public TreeViewVM(UITestModel model)
        {
            Model = model;
            Model.ProjectUpdate += UpdateProperties;
        }

        private void UpdateProperties(object sender, EventArgs e)
        {
            PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(nameof(Projects)));
        }

        public UITestModel Model {get;}
        public List<TestProject> Projects => Model.Projects;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
