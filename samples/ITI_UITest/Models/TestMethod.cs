using System;
using System.Collections.Generic;
using System.Linq;

namespace ITI_UITest.Models
{
    public class TestMethod : TestModel
    {
        private bool? _isPassed;
        private string _error;
        private string _console;
        public TestMethod(TestClass parrentClass, string name)
            :base(parrentClass, name)
        {
            _isPassed = null;
        }
        public TestMethod(TestClass parentClass, string name, bool? isPassed, string error, string console)
            : base(parentClass, name)
        {
            if (isPassed == false && error == null) throw new ArgumentException("If isPassed is false, error shouldn't be null.");
            if (isPassed != false && error != null) throw new ArgumentException("If isPassed isn't false, error should be null.");
            if (isPassed == null && console != null) throw new ArgumentException("If isPassed is null, console should be null.");
            _isPassed = isPassed;
            _error = error == null ? null : $"{name} : {error}";
            _console = console == null ? null : $"{name} : {console}";
        }
        public override void SetChlidren(IReadOnlyList<TestModel> children)
        {
            base.SetChlidren(children);
            if(children.Count != 0)
                _isPassed = children.Any(c => !c.IsPassed.HasValue) ? (bool?)null : !children.Any(c => !c.IsPassed.Value);
        }
        public override bool? IsPassed => _isPassed;
        public override string GetConsoleResult()
        {
            return _console;
        }
        public override string GetErrorsResult()
        {
            return _error;
        }
        public int PassedCount(bool passed)
        {
            if(Children?.Count > 0)
                return Children.Where(c => c.IsPassed == passed).Count();
            return IsPassed == passed ? 1 : 0;
        }
        public void SetConsoleResult(string console)
        {
            _console = console;
        }
        public void SetErrorsResult(string error)
        {
            _error = error + Environment.NewLine;
        }
        public void Run(bool run)
        {
            _isPassed = run;
        }
    }
}
