using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        List<TestProject> _projects;

        public UITestModel(List<TestProject> projects)
        {
            _projects = projects;
        }
        public List<TestProject> Projects => _projects;
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

        public int FailedTest { get; internal set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler ProjectUpdate;

        public async Task<string> Run()
        {
            IsFinish = false;
            if (IsRunning)
                return null;
            IsRunning = true;
            Update();
            await Task.Run(() => Thread.Sleep(5000));
            IsRunning = false;
            IsFinish = true;
            return "ok";
        }
        public void Stop()
        {
            IsRunning = false;
            Console.WriteLine("Stop");
        }
        public void Update()
        {
            _projects = DataGenerator.GenerateProject();
            ProjectUpdate?.Invoke(this, EventArgs.Empty);
        }
    }
}
