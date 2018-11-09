using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI_UITest.Models
{
    public class TestClass : TestModel
    {
        public TestClass(TestProject parentProject, string name)
            :base(parentProject, name)
        {
        }
        public override bool? IsPassed => Children.Any(c => !c.IsPassed.HasValue) ? (bool?)null : !Children.Any(c => !c.IsPassed.Value);
    }
}
