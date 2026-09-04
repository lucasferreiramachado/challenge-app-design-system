using Microsoft.Maui.Hosting;

namespace DesignSystem;

public static class DsDesignSystemExtensions
{
    public static MauiAppBuilder UseDesignSystem(this MauiAppBuilder builder) {
        
        builder.ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemiBold");
            fonts.AddFont("OpenSans-Bold.ttf", "OpenSansBold");
        });

        return builder;
    }
}