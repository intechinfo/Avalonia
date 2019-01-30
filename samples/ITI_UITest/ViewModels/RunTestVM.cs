using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using ITI_UITest.Models;
using ReactiveUI;

namespace ITI_UITest.ViewModels
{
    public class RunTestVM : INotifyPropertyChanged
    {
        UITestModel _model;
        public RunTestVM(UITestModel model)
        {
            _model = model;
            _model.PropertyChanged += _model_PropertyChanged;
            StartCommand = ReactiveCommand.CreateFromTask(Start);
        }

        private void _model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_model.IsRunning))
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRunning)));
            if(e.PropertyName == nameof(_model.IsFinish))
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ResultString)));
            }
        }

        public bool IsRunning => _model.IsRunning;
        public int Value => _model.IsFinish ? 100 : 0;
        public string ResultString => _model.IsFinish ? $"Passed : {_model.Projects.First().PassedCount(true)} Failed : {_model.Projects.First().PassedCount(false)}" : "";
        public ReactiveCommand<Unit,Unit> StartCommand { get; }
        public ReactiveCommand<Unit,Unit> StopCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public async Task Start()
        {
            await _model.Run();
        }
    }
}
