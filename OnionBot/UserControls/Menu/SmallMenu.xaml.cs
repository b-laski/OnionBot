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
<<<<<<< HEAD
using System.Windows.Media.Animation;
=======
>>>>>>> 868c1f7797cbb145240ef3207edae253bee0b29f

namespace OnionBot.UserControls.Menu
{
    /// <summary>
    /// Interaction logic for SmallMenu.xaml
    /// </summary>
    public partial class SmallMenu : UserControl
    {
<<<<<<< HEAD
        public delegate void MenuEventHundler(object sender, MenuList e);
        public event MenuEventHundler MenuButtons;

        public SmallMenu()
        {
            InitializeComponent();

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

        private void ShowHideMenu(string Storyboard, StackPanel pnl)
        {
            Storyboard sb = (Storyboard)this.Resources[Storyboard] as Storyboard;
            sb.Begin(pnl);
        }

        #region Buttons
        private void btnChat_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                MenuButtons?.Invoke(this, MenuList.chat);
            }
            
        }

        private void btnDashboard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                MenuButtons?.Invoke(this, MenuList.dashboard);
            }
        }

        private void btnGiveaway_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                MenuButtons?.Invoke(this, MenuList.giveaway);
            }
        }

        private void btnSongrequest_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                MenuButtons?.Invoke(this, MenuList.songrequest);
            }
        }

        private void btnSettings_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                MenuButtons?.Invoke(this, MenuList.settings);
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

=======
        public SmallMenu()
        {
            InitializeComponent();
        }
>>>>>>> 868c1f7797cbb145240ef3207edae253bee0b29f
    }
}
