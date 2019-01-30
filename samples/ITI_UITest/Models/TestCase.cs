using System.Collections.Generic;

namespace ITI_UITest.Models
{
    public class TestCase : TestModel
    {
        bool? _isPassed;
        public TestCase(TestModel parent, string name, bool? isPassed) 
            : base(parent, name)
        {
            _isPassed = isPassed;
            SetChlidren(new List<TestModel>());
        }
        public override string Name => $"{Parent.Name}({base.Name})";
        public override bool? IsPassed => _isPassed;
        public override string ToString()
        {
            return Parent.ToString();
        }
    }
}
