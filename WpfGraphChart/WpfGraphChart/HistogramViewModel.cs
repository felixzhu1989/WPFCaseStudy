using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGraphChart
{
    public class HistogramViewModel
    {
        public ObservableCollection<double> Values { get; set; } = new();

        public HistogramViewModel()
        {
            Random random = new Random();
            for (int i = 0; i < 30; i++)
            {
                Values.Add(random.Next(10,90));
            }
        }
    }
}
