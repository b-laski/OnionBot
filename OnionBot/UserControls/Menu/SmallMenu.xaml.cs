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
using System.Windows.Media.Animation;

namespace OnionBot.UserControls.Menu
{
    /// <summary>
    /// Interaction logic for SmallMenu.xaml
    /// </summary>
    public partial class SmallMenu : UserControl
    {
        public delegate void MenuEventHundler(object sender, MenuList e);
        public event MenuEventHundler MenuButtons;

        public SmallMenu()
        {
            InitializeComponent();

            btnChat.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            btnChat.AddHandler(FrameworkElement.MouseDownEvent, new MouseButtonEventHandler(btnChat_MouseDown), true);
            btnDashboard.AddHandler(FrameworkElement.MouseDownEvent, new MouseButtonEventHandler(btnDashboard_MouseDown), true);
            btnGiveaway.AddHandler(FrameworkElement.MouseDownEvent, new MouseButtonEventHandler(btnGiveaway_MouseDown), true);
            btnSongrequest.AddHandler(FrameworkElement.MouseDownEvent, new MouseButtonEventHandler(btnSongrequest_MouseDown), true);
            btnSettings.AddHandler(FrameworkElement.MouseDownEvent, new MouseButtonEventHandler(btnSettings_MouseDown), true);
        }

        public void openMenu()
        {
            ShowHideMenu("showMenu", pnlMenu);
            showTextBlocks();
        }

        public void closeMenu()
        {
            ShowHideMenu("hideMenu", pnlMenu);
        }

        private void showTextBlocks()
        {
            chatTextBlock.Visibility = Visibility.Visible;
            dashboardTextBlock.Visibility = Visibility.Visible;
            giveawayTextBlock.Visibility = Visibility.Visible;
            songrequestTextBlock.Visibility = Visibility.Visible;
            settingsTextBlock.Visibility = Visibility.Visible;
        }

        private void closeTextBlocks()
        {
            chatTextBlock.Visibility = Visibility.Collapsed;
            dashboardTextBlock.Visibility = Visibility.Collapsed;
            giveawayTextBlock.Visibility = Visibility.Collapsed;
            songrequestTextBlock.Visibility = Visibility.Collapsed;
            settingsTextBlock.Visibility = Visibility.Collapsed;
        }

        private void resetButton()
        {
            foreach(Button item in pnlMenu.Children)
            {
                var bc = new BrushConverter();
                item.Foreground = (Brush)bc.ConvertFrom("#616161");
            }
        }

        private void ShowHideMenu(string Storyboard, StackPanel pnl)
        {
            Storyboard sb = (Storyboard)this.Resources[Storyboard] as Storyboard;
            sb.Begin(pnl);
        }

        #region Buttons
        private void btnChat_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                MenuButtons?.Invoke(this, MenuList.chat);
                resetButton();
                btnChat.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            }

        }

        private void btnDashboard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                MenuButtons?.Invoke(this, MenuList.dashboard);
                resetButton();
                btnDashboard.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            }
        }

        private void btnGiveaway_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                MenuButtons?.Invoke(this, MenuList.giveaway);
                resetButton();
                btnGiveaway.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            }
        }

        private void btnSongrequest_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                MenuButtons?.Invoke(this, MenuList.songrequest);
                resetButton();
                btnSongrequest.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            }
        }

        private void btnSettings_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                MenuButtons?.Invoke(this, MenuList.settings);
                resetButton();
                btnSettings.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            }
        }
        #endregion // buttons

        public enum MenuList
        {
            chat,
            dashboard,
            giveaway,
            songrequest,
            settings
        }
    }
}
