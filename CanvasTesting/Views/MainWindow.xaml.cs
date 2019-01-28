using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace CanvasTesting.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            //this.canvas = this.FindControl<Canvas>("Canvas");
        }

        //public override void Show()
        //{
        //    base.Show();
        //    if(this.DataContext is MainWindowViewModel ctx)
        //    {
        //        ctx.PropertyChanged += OnSidesChanged;
        //    }
        //}

        private void InitializeComponent()
        {
            //this.DataContext = new MainWindowViewModel();
            AvaloniaXamlLoader.Load(this);
        }
    }
}
