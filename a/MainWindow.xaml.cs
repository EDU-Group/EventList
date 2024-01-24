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
    }
}