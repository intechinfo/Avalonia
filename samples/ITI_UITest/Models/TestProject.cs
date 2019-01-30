using System.Collections.Generic;
using System.Linq;

namespace ITI_UITest.Models
{
    public class TestProject : TestModel
    {
        public TestProject(string name)
            :base(null, name)
        {
        }
        public override bool? IsPassed => Children.Any(c => !c.IsPassed.HasValue) ? (bool?)null : !Children.Any(c => !c.IsPassed.Value);
        public int PassedCount(bool passed)
        {
            int count = 0;
            foreach (var @class in Children)
            {
                foreach (TestMethod method in @class.Children)
                {
                    count += method.PassedCount(passed);
                }
            }
            return count;
        }
    }
}
