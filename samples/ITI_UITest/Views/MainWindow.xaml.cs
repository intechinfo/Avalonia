using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ITI_UITest.ViewModels;

namespace ITI_UITest.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //(Content as MainView).LoadDll((DataContext as MainWindowViewModel).DllPath);
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
