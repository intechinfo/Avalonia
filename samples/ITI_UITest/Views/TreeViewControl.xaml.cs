using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ITI_UITest.Models;

namespace ITI_UITest.Views
{
    public class TreeViewControl : UserControl
    {
        public TreeViewControl()
        {
            this.InitializeComponent();
            DataContext = DataGenerator.GenerateProjects();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
