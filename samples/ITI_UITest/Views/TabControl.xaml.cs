using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ITI_UITest.Views
{
    public class TabControl : UserControl
    {
        public TabControl()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
