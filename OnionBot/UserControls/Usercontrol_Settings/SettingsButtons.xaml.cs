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

namespace OnionBot.UserControls.Usercontrol_Settings
{
    /// <summary>
    /// Interaction logic for SettingsButtons.xaml
    /// </summary>
    public partial class SettingsButtons : UserControl
    {
        public delegate void SettingMenuButtonEventHundler(object sender, SettingMenuButtons e);
        public event SettingMenuButtonEventHundler SettingMenuButtonClick;
        public enum SettingMenuButtons
        {
            Commends,
            Timers,
            SFX,
            Account,
            Colors
        }


        public SettingsButtons()
        {
            InitializeComponent();
        }

        private void btnCommends_Click(object sender, RoutedEventArgs e)
        {
            SettingMenuButtonClick?.Invoke(this, SettingMenuButtons.Commends);
            resetButton();
            btnCommends.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
        }

        private void btnTimers_Click(object sender, RoutedEventArgs e)
        {
            SettingMenuButtonClick?.Invoke(this, SettingMenuButtons.Timers);
            resetButton();
            btnTimers.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
        }

        private void btnSFX_Click(object sender, RoutedEventArgs e)
        {
            SettingMenuButtonClick?.Invoke(this, SettingMenuButtons.SFX);
            resetButton();
            btnSFX.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
        }

        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {
            SettingMenuButtonClick?.Invoke(this, SettingMenuButtons.Account);
            resetButton();
            btnAccount.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
        }

        private void btnColors_Click(object sender, RoutedEventArgs e)
        {
            SettingMenuButtonClick?.Invoke(this, SettingMenuButtons.Colors);
            resetButton();
            btnColors.Foreground = (Brush)FindResource("PrimaryHueMidBrush");
        }

        private void resetButton()
        {
            foreach (Button item in pnlFirst.Children)
            {
                var bc = new BrushConverter();
                item.Foreground = (Brush)bc.ConvertFrom("#616161");
            }

            foreach (Button item in pnlSecound.Children)
            {
                var bc = new BrushConverter();
                item.Foreground = (Brush)bc.ConvertFrom("#616161");
            }
        }
    }
}
