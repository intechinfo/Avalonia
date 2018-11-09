using Avalonia;
using Avalonia.Markup.Xaml;

namespace ITI_UITest
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
