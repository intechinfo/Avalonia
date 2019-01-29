using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ITI_UITest.Views
{
    public class RunTestControl : UserControl
    {
        public RunTestControl()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
