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
    }
}
