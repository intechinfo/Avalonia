using System;
using System.Collections.Generic;
using System.Text;
using Avalonia.Media;

namespace ITI_UITest.Models
{
    public abstract class TestModel
    {
        private static IBrush GreenBrush => Brushes.Green;
        private static IBrush BlackBrush => Brushes.Black;
        private static IBrush RedBruch => Brushes.Red;
        public TestModel(TestModel parent, string name)
        {
            Parent = parent;
            Name = name;
        }
        public virtual string Name { get; }
        public IReadOnlyList<TestModel> Children { get; private set; }
        public TestModel Parent { get; }
        public virtual bool? IsPassed { get; private set; }
        public virtual void SetChlidren(IReadOnlyList<TestModel> children)
        {
            if (children == null)
                throw new ArgumentNullException("children");
            Children = children;
        }
        public IBrush Color => !IsPassed.HasValue ? BlackBrush: GetColor(IsPassed.Value);
        IBrush GetColor(bool value) => value ? GreenBrush : RedBruch;
    }
}
