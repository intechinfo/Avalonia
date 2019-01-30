﻿using System;
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
        List<TestModel> _children = new List<TestModel>();
        public TestModel(TestModel parent, string name)
        {
            Parent = parent;
            Name = name;
        }
        public virtual string Name { get; }
        public IReadOnlyList<TestModel> Children { get => _children; }
        public TestModel Parent { get; }
        public virtual bool? IsPassed { get; private set; }
        public virtual void SetChlidren(IReadOnlyList<TestModel> children)
        {
            if (children == null)
                throw new ArgumentNullException("children");
            _children = new List<TestModel>();
            _children.AddRange(children);
        }
        public virtual void AddChild(TestModel child)
        {
            if (_children == null)
                _children = new List<TestModel>();
            _children.Add(child);
        }
        public IBrush Color => !IsPassed.HasValue ? BlackBrush: GetColor(IsPassed.Value);
        IBrush GetColor(bool value) => value ? GreenBrush : RedBruch;
        public virtual string GetConsoleResult()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var child in Children)
            {
                string s = child.GetConsoleResult();
                if (!string.IsNullOrEmpty(s))
                    builder.AppendLine(s);
            }
            return builder.ToString();
        }
        public virtual string GetErrorsResult()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var child in Children)
            {
                string s = child.GetErrorsResult();
                if(!string.IsNullOrEmpty(s))
                    builder.AppendLine(s);
            }
            return builder.ToString();
        }

        public override string ToString()
        {
            if (Parent != null)
                return $"{Parent.ToString()}/{Name}";
            else
                return Name;
        }
    }
}