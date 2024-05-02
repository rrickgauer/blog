using System.Windows.Controls;

namespace Blog.WpfGui.Views.UserControls;

/// <summary>
/// Interaction logic for PageTitleControl.xaml
/// </summary>
public partial class PageTitleControl : UserControl
{

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string), typeof(PageTitleControl), new PropertyMetadata(string.Empty));

    public PageTitleControl()
    {
        InitializeComponent();
        RootControl.DataContext = this;
    }
}
