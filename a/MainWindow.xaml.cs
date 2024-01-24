using HandyControl.Data;
using HandyControl.Tools.Extension;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace a
{
    //Win32方法
    public static class Win32
    {
        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        public const UInt32 SWP_NOSIZE = 0x0001;
        public const UInt32 SWP_NOMOVE = 0x0002;
        public const UInt32 SWP_NOACTIVATE = 0x0010;
        public static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void SetBottom(Window window)
        {
            IntPtr hWnd = new WindowInteropHelper(window).Handle;
            Win32.SetWindowPos(hWnd, Win32.HWND_BOTTOM, 0, 0, 0, 0, Win32.SWP_NOSIZE | Win32.SWP_NOMOVE | Win32.SWP_NOACTIVATE);
        }
        public MainWindow()
        {
            InitializeComponent();
            SetBottom(this);
            int h = (int)SystemParameters.PrimaryScreenWidth;
            Left = h - Width;
            Top = 0;
            Init();
        }
        async void Init ()
        {
            while(true)
            {
                await Task.Delay(15);
                DateTime Fo = Convert.ToDateTime("2024/1/24 16:12:00");
                DateTime Now = DateTime.Now;
                DateTime To = Convert.ToDateTime("2024/1/24 16:15:00");
                progressBar.Maximum = (To - Fo).TotalSeconds;
                progressBar.Value = ((To - Fo).TotalSeconds)-(To - Now).TotalSeconds;
            }
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //DragMove();
        }
        public bool OnTab = false;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            switch (OnTab)
            {
                case false:
                    var Opena = FindResource("a_down") as Storyboard;
                    Opena.Begin();
                    OnTab = true;
                    break;
                case true:
                    var Opena1 = FindResource("a_more") as Storyboard;
                    Opena1.Begin();
                    OnTab = false;
                    break;
            }
        }

        private void Window_GotFocus(object sender, RoutedEventArgs e)
        {
            //SetBottom(this);
        }

        private void image2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //SetBottom(this);
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            SetBottom(this);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Edit edit = new();
            edit.ShowDialog();
        }

        private void button3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Edit edit = new();
            edit.ShowDialog();
        }

        private void image3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Edit edit = new();
            edit.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BrushConverter bcrg = new();
            Brush brug1 = (Brush)bcrg.ConvertFromString("#33ff0000");
            AddEventList(brug1, DateTime.Now, DateTime.Now.AddSeconds(9), "good",1000);
        }
        public async void AddEventList (Brush BackgroundColorb , DateTime StartTime , DateTime EndTime , string Name , int Freq)
        {
            //参数区
            int totald = 0;
            double progress = 0;
            int day = 0;
            string totalFomat = "天";
            TimeSpan td = (EndTime - StartTime);


            //实例化和设置控件区
            Border bord = new();
            bord.Height = 47;
            bord.Width = 320;
            BrushConverter bcr = new();
            Brush bru = (Brush)bcr.ConvertFromString("#ffffffff");
            bord.BorderBrush = bru;
            bord.Margin = new(0, 4, 0, 0);
            BrushConverter bcrg = new();
            Brush brug = (Brush)bcrg.ConvertFromString("#ffffffff");
            bord.Background = BackgroundColorb;
            bord.BorderThickness = new Thickness(1, 1, 1, 1);
            bord.CornerRadius = new CornerRadius(4, 4, 4, 4);
            Grid grid = new();
            grid.Background = null;
            Label title = new();
            title.Background = null;
            title.BorderBrush = null;
            title.Width = 290;
            title.Height = 46;
            title.Content = Name;
            title.Foreground = bru;
            title.HorizontalContentAlignment = HorizontalAlignment.Left;
            title.VerticalContentAlignment = VerticalAlignment.Top;
            Label TotalDay = new();
            TotalDay.Background = null;
            TotalDay.BorderBrush = null;
            TotalDay.Width = 320;
            TotalDay.Height = 46;
            TotalDay.Content = Convert.ToString(progress) + "% | " + Convert.ToString(day) + totalFomat;
            TotalDay.Foreground = bru;
            TotalDay.HorizontalContentAlignment = HorizontalAlignment.Right;
            TotalDay.VerticalContentAlignment = VerticalAlignment.Bottom;
            Label EDate = new();
            EDate.Background = null;
            EDate.BorderBrush = null;
            EDate.Width = 320;
            EDate.Height = 46;
            EDate.Content = Convert.ToString(totald) + "天";
            EDate.Foreground = bru;
            EDate.HorizontalContentAlignment = HorizontalAlignment.Right;
            EDate.VerticalContentAlignment = VerticalAlignment.Top;
            Label Date = new();
            Date.Background = null;
            Date.BorderBrush = null;
            Date.Width = 320;
            Date.Height = 46;
            Date.Content = EndTime.ToString("yyyy/M/d");
            Date.Foreground = bru;
            Date.HorizontalContentAlignment = HorizontalAlignment.Left;
            Date.VerticalContentAlignment = VerticalAlignment.Bottom;
            Image img = new();
            img.Margin = new(8, 6, 294, 22);
            ImageSource ise =
            img.Source = new BitmapImage(new Uri(@"/Img/img.png", UriKind.Relative));
            img.Stretch = Stretch.Uniform;
            ProgressBar pgb = new();
            pgb.Style = (Style)Application.Current.TryFindResource("ProgressBarFlat");
            pgb.Margin = new(10, 39, 10, 2);

            //呈现控件
            EventPanel.Children.Add(bord);
            bord.Child = grid;
            grid.Children.Add(EDate);
            grid.Children.Add(TotalDay);
            grid.Children.Add(title);
            grid.Children.Add(Date);
            grid.Children.Add(img);
            grid.Children.Add(pgb);

            //算法区
            while (true)
            {
                if (!(DateTime.Now >= EndTime))
                {
                    if ((EndTime - DateTime.Now).TotalSeconds <= 60)
                    {
                        totalFomat = "秒";
                        TotalDay.Content = Convert.ToString(Math.Ceiling(progress)) + "% | " + Math.Floor((EndTime - DateTime.Now).TotalSeconds) + totalFomat;
                    }
                    else if ((EndTime - DateTime.Now).TotalMinutes < 60)
                    {
                        if (!(td.TotalSeconds <= 60))
                        {
                            totalFomat = "分";
                            TotalDay.Content = Convert.ToString(Math.Ceiling(progress)) + "% | " + Math.Floor((EndTime - DateTime.Now).TotalMinutes) + totalFomat;
                        }
                    }
                    else if ((EndTime - DateTime.Now).TotalHours < 24)
                    {
                        totalFomat = "小时";
                        TotalDay.Content = Convert.ToString(Math.Ceiling(progress)) + "% | " + Math.Floor((EndTime - DateTime.Now).TotalHours) + totalFomat;
                    }
                    else if ((EndTime - DateTime.Now).TotalHours > 24)
                    {
                        totalFomat = "天";
                        TotalDay.Content = Convert.ToString(Math.Ceiling(progress)) + "% | " + Math.Floor((EndTime - DateTime.Now).TotalDays) + totalFomat;
                    }
                }
                
                if(DateTime.Now >= EndTime)
                {
                    img.Source = new BitmapImage(new Uri(@"/Img/img.png", UriKind.Relative));
                }
                else
                {
                    img.Source = new BitmapImage(new Uri(@"/Img/right.png", UriKind.Relative));
                }
                pgb.Maximum = td.TotalSeconds;
                pgb.Value = (td.TotalSeconds) - (EndTime - DateTime.Now).TotalSeconds;
                progress = (100 / td.TotalSeconds) * (DateTime.Now - StartTime).TotalSeconds;
                await Task.Delay(Freq);
            }
        }
    }
}