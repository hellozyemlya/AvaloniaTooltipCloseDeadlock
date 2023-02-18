using Avalonia;
using Avalonia.Controls;

namespace AvToolTipBug;

public class ToolTipContent : ContentControl
{
    public static readonly StyledProperty<string> TitleProperty =
        AvaloniaProperty.Register<ToolTipContent, string>("Title");

    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
}