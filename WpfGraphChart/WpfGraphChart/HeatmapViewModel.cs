using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfGraphChart.Annotations;

namespace WpfGraphChart
{
    public class HeatmapViewModel:INotifyPropertyChanged
    {
        public double[,] HeatValues { get; set; }
        Random random=new Random();

        public HeatmapViewModel()
        {
            //热力图模拟数据
            Task.Run(async () =>
            {
                int index = 0;
                while (true)
                {
                    await Task.Delay(50);
                    HeatValues = CreateSeries(index++, 150, 120, 0, 200);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HeatValues"));
                }
            });


            
        }
        private double[,] CreateSeries(int index, int width, int height, double cpMin, double cpMax)
        {
            double[,] result = new double[height, width];
            double angle = Math.Round(Math.PI * 2 * index, 3) / 30;
            int w = width, h = height;
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    var v = (1 + Math.Round(Math.Sin(x * 0.04 + angle), 3)) * 50 +
                            (1 + Math.Round(Math.Sin(y * 0.1 + angle), 3)) * 50 *
                            (1 + Math.Round(Math.Sin(angle * 2), 3));
                    var cx = w / 2;
                    var cy = h / 2;
                    var r = Math.Sqrt((x - cx) * (x - cx) + (y - cy) * (y - cy));
                    var exp = Math.Max(0, 1 - r * 0.008);
                    var zValue = v * exp + random.NextDouble() * 50;
                    result[y,x] = zValue>cpMax?cpMax:zValue;
                }
            }

            return result;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
