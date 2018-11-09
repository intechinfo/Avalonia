using System.Collections.Generic;
using System.Linq;

namespace ITI_UITest.Models
{
    public class TestMethod : TestModel
    {
        private bool? _isPassed;
        public TestMethod(TestClass parentClass, string name, bool? isPassed)
            :base(parentClass,name)
        {
            _isPassed = isPassed;
        }
        public TestMethod(TestClass parrentClass, string name)
            :base(parrentClass, name)
        {
        }
        public override void SetChlidren(IReadOnlyList<TestModel> children)
        {
            base.SetChlidren(children);
            if(children.Count != 0)
                _isPassed = children.Any(c => !c.IsPassed.HasValue) ? (bool?)null : !children.Any(c => !c.IsPassed.Value);
        }
        public override bool? IsPassed => _isPassed;
    }
}
