using System.ComponentModel;
using System.Diagnostics;

namespace DesignSystem;

public partial class DsEntry
{
    public static readonly BindableProperty PlaceholderProperty =
        BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(DsEntry), "");
    public static readonly BindableProperty IsPasswordProperty =
            BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(DsEntry), false);

    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(DsEntry), "");
    

    public static readonly BindableProperty ErrorProperty =
        BindableProperty.Create(nameof(Error), typeof(string), typeof(DsEntry), "");
    public static readonly BindableProperty KeyboardProperty =
        BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(DsEntry));
    
    public event EventHandler<TextChangedEventArgs> TextChanged;

    private void OnInternalTextChanged(object sender, TextChangedEventArgs e)
    {
        TextChanged?.Invoke(this, e);
    }
    
    public string Placeholder
    {
        get => (string) GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public bool IsPassword
    {
        get => (bool)GetValue(IsPasswordProperty);
        set => SetValue(IsPasswordProperty, value);
    }

    public string Text
    {
        get => (string) GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    
    public string Error
    {
        get => (string) GetValue(ErrorProperty);
        set => SetValue(ErrorProperty, value);
    }

    public Keyboard Keyboard
    {
        get => (Keyboard)GetValue(KeyboardProperty);
        set => SetValue(KeyboardProperty, value);
    }
    
    public DsEntry()
    {
        InitializeComponent();
        InnerEntry.HandlerChanged += (_, _) =>
        {
            if (InnerEntry.Handler?.PlatformView is null) return;

#if ANDROID
            var nativeView = InnerEntry.Handler.PlatformView as Android.Views.View;
            if (nativeView != null)
            {
                nativeView.SetPadding(0,0,0,0);
                nativeView.Background = null;
            }
#elif IOS || MACCATALYST
            var nativeView = InnerEntry.Handler.PlatformView as UIKit.UITextField;
            if (nativeView is not null)
            {
                nativeView.BorderStyle = UIKit.UITextBorderStyle.None;
            }
#elif WINDOWS
            var nativeView = InnerEntry.Handler.PlatformView as Microsoft.UI.Xaml.Controls.TextBox;
            if (nativeView is not null)
            {
                nativeView.BorderThickness = new Microsoft.UI.Xaml.Thickness(0);
            }
#endif
        };
    }
}