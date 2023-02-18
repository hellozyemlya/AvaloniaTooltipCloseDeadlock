using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;

namespace AvToolTipBug;

public partial class MainWindow : Window
{
    private List<ToolTipDto> _tooltips = new List<ToolTipDto>();

    public static readonly DirectProperty<MainWindow, List<ToolTipDto>> TooltipsProperty = AvaloniaProperty.RegisterDirect<MainWindow, List<ToolTipDto>>(
        "Tooltips", o => o.Tooltips, (o, v) => o.Tooltips = v);

    public List<ToolTipDto> Tooltips
    {
        get => _tooltips;
        set => SetAndRaise(TooltipsProperty, ref _tooltips, value);
    }
    public MainWindow()
    {
        for (var i = 0; i < 10; i++)
        {
            _tooltips.Add(new ToolTipDto() {Title = $"t {i}", Content = $"c {i}"});
        }
        InitializeComponent();
    }
}