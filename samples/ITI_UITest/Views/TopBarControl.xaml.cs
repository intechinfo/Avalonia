using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ITI_UITest.Views
{
    public class TopBarControl : UserControl
    {
        public TopBarControl()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
