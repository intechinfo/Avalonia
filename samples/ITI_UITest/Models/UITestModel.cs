using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ITI_UITest.Models
{
    public class UITestModel : INotifyPropertyChanged
    {
        string _selectedTest;
        bool _isRunning;
        private bool _isFinish;

        public UITestModel(List<TestProject> projects)
        {
            Projects = projects;
        }
        public List<TestProject> Projects { get; }
        public string SelectedTest
        {
            get => _selectedTest;
            set
            {
                if( _selectedTest != value )
                {
                    _selectedTest = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedTest)));
                }
            }
         }
        public bool IsRunning
        {
            get => _isRunning;
            set
            {
                if( _isRunning != value)
                {
                    _isRunning = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRunning)));
                }
            }
        }
        public bool IsFinish
        {
            get => _isFinish;
            set
            {
                if (_isFinish != value)
                {
                    if(value && _isRunning) throw new ArgumentException("Test can't be finished if test are still running");

                    _isFinish = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsFinish)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async Task<string> Run()
        {
            IsFinish = false;
            if (IsRunning)
                return null;
            IsRunning = true;
            Console.WriteLine($"Run : {SelectedTest}");
            Thread.Sleep(5000);
            IsFinish = true;
            IsRunning = false;
            return "ok";
        }
        public void Stop()
        {
            IsRunning = false;
            Console.WriteLine("Stop");
        }
    }
}
