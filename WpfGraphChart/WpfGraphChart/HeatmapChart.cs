using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfGraphChart
{
    public class HeatmapChart:FrameworkElement
    {
        public double[,] Values
        {
            get => (double[,])GetValue(ValuesProperty);
            set => SetValue(ValuesProperty,value);
        }
        public static readonly DependencyProperty ValuesProperty=DependencyProperty.Register("Values",typeof(double[,]),typeof(HeatmapChart),new PropertyMetadata(null,new PropertyChangedCallback(OnValuesChanged)));

        //值变化时的回调方法
        private static void OnValuesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as HeatmapChart).InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            
            base.OnRender(drawingContext);
            if (Values == null) return;
            var rowCount = Values.GetLength(0);
            var colCount = Values.GetLength(1);
            Size renderSize = base.RenderSize;
            double perWidth = renderSize.Width / colCount;
            double perHeight = renderSize.Height / rowCount;

            double[,] values = Values;
            for (int i = 0; i < colCount; i++)
            {
                for (int j = 0; j < rowCount; j++)
                {
                    //绘制矩形
                    drawingContext.DrawRectangle(GetColor(values[j,i]),null,new Rect(i* perWidth+0.5,j* perHeight+0.5,perWidth-1,perHeight-1));
                }
            }
            
        }
        //颜色分档
        private Brush GetColor(double value)
        {
            if (value > 140)
                return Brushes.Red;
            else if (value > 90)
                return Brushes.Orange;
            else if (value > 60)
                return Brushes.Pink;
            return Brushes.LightBlue;
        }
    }
}
