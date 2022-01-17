using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;


namespace WpfGraphChart
{
    public class PointsHelper
    {
        //依赖附加属性
        public static ObservableCollection<Point> GetPoints(DependencyObject obj)
        {
            return (ObservableCollection<Point>) obj.GetValue(PointsHelper.PointsProperty);
        }
        public static void SetPoints(DependencyObject obj, ObservableCollection<Point> value)
        {
            obj.SetValue(PointsProperty,value);
        }
        public static readonly DependencyProperty PointsProperty =
            DependencyProperty.RegisterAttached("Points", typeof(ObservableCollection<Point>), typeof(PointsHelper), new PropertyMetadata(null,new PropertyChangedCallback(OnPointsChanged)));

        private static void OnPointsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = d as Polyline;
            var ps = e.NewValue as ObservableCollection<Point>;
            ps.CollectionChanged += (se, ev) =>
            {
                obj.Points = new System.Windows.Media.PointCollection((e.NewValue as ObservableCollection<Point>)!);
            };
            
        }
    }
}
