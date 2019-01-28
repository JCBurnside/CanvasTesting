using Avalonia;
using Avalonia.Logging;
using Avalonia.Logging.Serilog;
using Avalonia.Markup.Xaml;
using Serilog;
using Serilog.Filters;

namespace CanvasTesting
{
    public class App : Application
    {
        public override void Initialize()
        {
            InitializeLogging();
            Avalonia.Logging.Logger.Information(LogArea.Binding, this, "Init");
            AvaloniaXamlLoader.Load(this);
        }

        private void InitializeLogging()
        {
            SerilogLogger.Initialize(new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Filter.ByIncludingOnly(Matching.WithProperty("Area", LogArea.Binding))
                .WriteTo.Debug(outputTemplate: "{Area}: {Message}")
                .CreateLogger());
        }
    }
}
