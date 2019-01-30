using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ITI_UITest.Models;
using ITI_UITest.ViewModels;

namespace ITI_UITest.Views
{
    public class TreeViewControl : UserControl
    {
        TreeView _treeView;
        public TreeViewControl()
        {
            InitializeComponent();
            _treeView = this.FindControl<TreeView>("TreeViewTests");
            _treeView.Tapped += OnSelectedItemChanged;
            _treeView.DoubleTapped += Run;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public virtual void Run(object sender, RoutedEventArgs e)
        {
            OnSelectedItemChanged(sender, e);
            (DataContext as TreeViewVM).Model.Run();
        }

        protected virtual void OnSelectedItemChanged(object sender, RoutedEventArgs e)
        {
            TestModel testModel = this.FindControl<TreeView>("TreeViewTests").SelectedItem as TestModel;
            (DataContext as TreeViewVM).Model.SelectedTest = testModel.ToString();
        }
    }
}
