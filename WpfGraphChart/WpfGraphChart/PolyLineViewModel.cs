using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfGraphChart
{
    public class PolyLineViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Point> Points { get; set; } = new();
        public int OffsetX { get; set; } = 0;
        public PolyLineViewModel()
        {
            Task.Run(async () =>
            {
                double angle = 0.0;
                double x = 0.0;
                while (angle < 360)
                {
                    await Task.Delay(50);
                    double value = Math.Cos(Math.PI * angle / 180);
                    angle += 5;
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Points.Add(new Point(x, value * 40 + 50));
                        x += 2;
                        if (Points.Count > 150)
                        {
                            OffsetX -= 2;
                            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OffsetX"));
                            Points.RemoveAt(0);
                        }
                    });
                    if (angle >= 360) 
                        angle = 0.0;
                }
            });
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
