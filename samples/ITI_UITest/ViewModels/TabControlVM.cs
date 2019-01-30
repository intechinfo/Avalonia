using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ITI_UITest.Models;

namespace ITI_UITest.ViewModels
{
    public class TabControlVM : INotifyPropertyChanged
    {
        UITestModel _model;

        public TabControlVM(UITestModel model)
        {
            _model = model;
            _model.ProjectUpdate += UpdateProperties;
        }

        private void UpdateProperties(object sender, EventArgs e)
        {
            PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(nameof(Errors)));
            PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(nameof(Console)));
        }

        public string Errors => _model.Projects.First().GetErrorsResult();
        public string Console => _model.Projects.First().GetConsoleResult();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
