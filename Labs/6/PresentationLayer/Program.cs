using ServiceLayer;

namespace PresentationLayer;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        var dataDirectory = Path.Combine(AppContext.BaseDirectory, "Data");
        Application.Run(new MainForm(Service.CreateDefault(dataDirectory)));
    }
}