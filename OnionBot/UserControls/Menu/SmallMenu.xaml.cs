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
using Utilities;

namespace OnionBot.UserControls.Menu
{
    /// <summary>
    /// Interaction logic for SmallMenu.xaml
    /// </summary>
    public partial class SmallMenu : UserControl
    {
        public delegate void MenuEventHundler(object sender, MenuList e);
        public event MenuEventHundler MenuButtons;
        public enum MenuList
        {
            chat,
            dashboard,
            giveaway,
            songrequest,
            settings
        }

        private int targetClosedWidth = 56;
        private int targetOpenWidth = 200;


        public bool? isMenuVisible = false;

        public SmallMenu()
        {
            InitializeComponent();

            targetClosedWidth = (int) this.MinWidth;
            targetOpenWidth = (int) this.MaxWidth;

            pnlMenu.Width = targetClosedWidth;

            btnChat.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
            btnChat.AddHandler(FrameworkElement.MouseDownEvent, new MouseButtonEventHandler(btnChat_MouseDown), true);
            btnDashboard.AddHandler(FrameworkElement.MouseDownEvent, new MouseButtonEventHandler(btnDashboard_MouseDown), true);
            btnGiveaway.AddHandler(FrameworkElement.MouseDownEvent, new MouseButtonEventHandler(btnGiveaway_MouseDown), true);
            btnSongrequest.AddHandler(FrameworkElement.MouseDownEvent, new MouseButtonEventHandler(btnSongrequest_MouseDown), true);
            btnSettings.AddHandler(FrameworkElement.MouseDownEvent, new MouseButtonEventHandler(btnSettings_MouseDown), true);
        }

        #region AnimationsMenu
        public void openMenu()
        {
            showTextBlocks();
            ShowMenu(pnlMenu);
        }

        public void closeMenu()
        {
            HideMenu(pnlMenu);
        }

        private void showTextBlocks()
        {
            chatTextBlock.Visibility = Visibility.Visible;
            dashboardTextBlock.Visibility = Visibility.Visible;
            giveawayTextBlock.Visibility = Visibility.Visible;
            songrequestTextBlock.Visibility = Visibility.Visible;
            settingsTextBlock.Visibility = Visibility.Visible;
        }

        private void hideTextBlocks()
        {
            chatTextBlock.Visibility = Visibility.Collapsed;
            dashboardTextBlock.Visibility = Visibility.Collapsed;
            giveawayTextBlock.Visibility = Visibility.Collapsed;
            songrequestTextBlock.Visibility = Visibility.Collapsed;
            settingsTextBlock.Visibility = Visibility.Collapsed;
        }

        private void HideMenu(Grid pnl)
        {
            isMenuVisible = null;
            chatTextBlock.Opacity = 1;
            dashboardTextBlock.Opacity = 1;
            giveawayTextBlock.Opacity = 1;
            songrequestTextBlock.Opacity = 1;
            settingsTextBlock.Opacity = 1;
            Utilities.Animations.WidthAnimation(pnl, targetClosedWidth, TimeSpan.FromMilliseconds(500), ()=> 
            {
                isMenuVisible = false;
                hideTextBlocks();

            });
            Utilities.Animations.OpacityAnimation(chatTextBlock, 0, TimeSpan.FromMilliseconds(300));
            Utilities.Animations.OpacityAnimation(dashboardTextBlock, 0, TimeSpan.FromMilliseconds(300));
            Utilities.Animations.OpacityAnimation(giveawayTextBlock, 0, TimeSpan.FromMilliseconds(300));
            Utilities.Animations.OpacityAnimation(songrequestTextBlock, 0, TimeSpan.FromMilliseconds(300));
            Utilities.Animations.OpacityAnimation(settingsTextBlock, 0, TimeSpan.FromMilliseconds(300));
        }

        private void ShowMenu(Grid pnl)
        {
            isMenuVisible = null;
            chatTextBlock.Opacity = 0;
            dashboardTextBlock.Opacity = 0;
            giveawayTextBlock.Opacity = 0;
            songrequestTextBlock.Opacity = 0;
            settingsTextBlock.Opacity = 0;
            Utilities.Animations.WidthAnimation(pnl, targetOpenWidth, TimeSpan.FromMilliseconds(500), () =>
            {
                isMenuVisible = true;
            });
            Utilities.Animations.OpacityAnimation(chatTextBlock, 1, TimeSpan.FromMilliseconds(800));
            Utilities.Animations.OpacityAnimation(dashboardTextBlock, 1, TimeSpan.FromMilliseconds(800));
            Utilities.Animations.OpacityAnimation(giveawayTextBlock, 1, TimeSpan.FromMilliseconds(800));
            Utilities.Animations.OpacityAnimation(songrequestTextBlock, 1, TimeSpan.FromMilliseconds(800));
            Utilities.Animations.OpacityAnimation(settingsTextBlock, 1, TimeSpan.FromMilliseconds(800));
        }

        private void resetButton()
        {
            foreach(Button item in pnlButtonMenu.Children)
            {
                var bc = new BrushConverter();
                item.Foreground = (Brush)bc.ConvertFrom("#616161");
            }
        }
        #endregion

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
    }
}
