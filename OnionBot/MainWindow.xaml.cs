using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OnionBot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnMaxiWindow.AddHandler(FrameworkElement.MouseDownEvent, new MouseButtonEventHandler(btnMaxiWindow_Click), true);
            btnMinWindow.AddHandler(FrameworkElement.MouseDownEvent, new MouseButtonEventHandler(btnMinWindow_Click), true);
        }

        #region Buttons
        private void btnCloseApp_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMaxiWindow_Click(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
        }

        private void btnMinWindow_Click(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Application.Current.MainWindow.WindowState = WindowState.Minimized;
            }
        }


        #endregion
    }
}
