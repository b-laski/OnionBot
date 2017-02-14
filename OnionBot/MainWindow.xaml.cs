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

        #region MainWindow
        private void btnCloseApp_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMaxiWindow_Click(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
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
        #endregion // mainWindow

        #region NaviBar
        private void NavigationBar_MenuButtonClick(object sender, UserControls.NavigationBar.MenuButton e)
        {
            if (e == UserControls.NavigationBar.MenuButton.Open)
            {
                smallMenu.openMenu();
            }
            else
            {
                smallMenu.closeMenu();
            }
        }
        #endregion //NaviBar

        #region MenuButtons
        private void smallMenu_MenuButtons(object sender, UserControls.Menu.SmallMenu.MenuList e)
        {
            foreach (Control item in panelUserControl.Children) //Jak bedziesz dodawal nowe opcje do grida, ten kod automatycznie je bedzie wylaczal jak bedziesz wlaczal nowe opcje
            {
                item.Visibility = Visibility.Collapsed;
            }

            //zostaje ci tylko dodac nowa opcje/windowa tutaj, chyba dosyc proste co? ez
            if (e == UserControls.Menu.SmallMenu.MenuList.chat) chatControl.Visibility = Visibility.Visible;
            else if (e == UserControls.Menu.SmallMenu.MenuList.dashboard) DashboardControl.Visibility = Visibility.Visible;
            else if (e == UserControls.Menu.SmallMenu.MenuList.giveaway) DashboardControl.Visibility = Visibility.Visible;
            else if (e == UserControls.Menu.SmallMenu.MenuList.songrequest) SongrequestControl.Visibility = Visibility.Visible;
            else if (e == UserControls.Menu.SmallMenu.MenuList.settings) SettingsControl.Visibility = Visibility.Visible;
        }
        #endregion //MenuButtons

        #endregion
    }
}
