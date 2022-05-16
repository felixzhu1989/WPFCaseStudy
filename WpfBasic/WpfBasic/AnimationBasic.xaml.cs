using System;
using System.Windows.Controls;
using System.Windows.Media.Animation;
namespace WpfBasic
{
    /// <summary>
    /// AnimationBasic.xaml 的交互逻辑
    /// </summary>
    public partial class AnimationBasic : Page
    {
        public AnimationBasic()
        {
            InitializeComponent();
        }

        private void Btn_OnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            //创建一个双精度动画
            DoubleAnimation animation = new DoubleAnimation
            {
                //To = btn.Width +30,//结束值
                //From = btn.Width,//设置动画初始值
                By = 30, //在原来的基础上+30
                Duration = TimeSpan.FromSeconds(1), //持续时间
                AutoReverse = true, //复原
                //RepeatBehavior = RepeatBehavior.Forever,//无限循环
                RepeatBehavior = new RepeatBehavior(2) //循环2次
            };
            animation.Completed += Animation_Completed!;//执行动画完成后的动作
            //启动执行该动画
            btn.BeginAnimation(Button.WidthProperty, animation);
        }
        private void Animation_Completed(object sender, EventArgs e)
        {
            btn.Content = "动画已完成";
        }
    }
}
