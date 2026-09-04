using DesignSystem;

namespace Example;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder()
            .UseMauiApp<App>()
            .UseDesignSystem();

        return builder.Build();
    }
}
