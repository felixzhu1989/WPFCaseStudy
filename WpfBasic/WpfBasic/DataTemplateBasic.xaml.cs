using System.Collections.Generic;
using System.Windows.Controls;

namespace WpfBasic;

/// <summary>
/// DataTemplate.xaml 的交互逻辑
/// </summary>
public partial class DataTemplateBasic : Page
{
    public DataTemplateBasic()
    {
        InitializeComponent();
        List<Color> colors = new List<Color>
        {
            new(){Code = "#FFB6C1",Name = "浅粉色"},
            new(){Code = "#4682B4",Name = "钢蓝"},
            new(){Code = "#2E8B57",Name = "海洋绿"},
            new(){Code = "#FF8C00",Name = "深橙色"}
        };
        ColorList.ItemsSource=colors;
    }
}
public class Color
{
    public string Code { get; set; }
    public string Name { get; set; }
}