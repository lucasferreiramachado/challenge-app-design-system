using System.Windows.Input;

namespace DesignSystem;

public partial class DsNavBar : ContentView
{
    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(nameof(Title), typeof(string), typeof(DsNavBar), "");
    
    public static readonly BindableProperty BackCommandProperty =
        BindableProperty.Create(
            nameof(BackCommand),
            typeof(ICommand),
            typeof(DsNavBar),
            default(ICommand));

    // 2. Cria a propriedade tradicional C# para encapsular o BindableProperty
    public ICommand BackCommand
    {
        get => (ICommand)GetValue(BackCommandProperty);
        set => SetValue(BackCommandProperty, value);
    }
    
    public string Title
    {
        get => (string) GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
    
    public DsNavBar()
    {
        InitializeComponent();
    }
}