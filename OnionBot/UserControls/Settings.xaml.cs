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

namespace OnionBot.UserControls
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void btnAddCommend_ButtonClick(object sender, EventArgs e)
        {
            addCommendForm.Visibility = Visibility.Visible;
        }

        private void addCommends_ButtonClick(object sender, Usercontrol_Settings.Commends.AddCommend.SelectedButton e)
        {
            if (e == Usercontrol_Settings.Commends.AddCommend.SelectedButton.Add) { addCommendForm.Visibility = Visibility.Collapsed; }
            else if (e == Usercontrol_Settings.Commends.AddCommend.SelectedButton.Cancel) { addCommendForm.Visibility = Visibility.Collapsed; }
        }

        private void settingsList_SettingMenuButtonClick(object sender, Usercontrol_Settings.SettingsButtons.SettingMenuButtons e)
        {
            foreach(Border item in pnlGridSettings.Children)
            {
                item.Visibility = Visibility.Collapsed;
            }

            if(e == Usercontrol_Settings.SettingsButtons.SettingMenuButtons.Commends) { CommendsForm.Visibility = Visibility.Visible; }
            else if (e == Usercontrol_Settings.SettingsButtons.SettingMenuButtons.Timers) { TimersForm.Visibility = Visibility.Visible; }
            else if (e == Usercontrol_Settings.SettingsButtons.SettingMenuButtons.SFX) { SFXForm.Visibility = Visibility.Visible; }
            else if (e == Usercontrol_Settings.SettingsButtons.SettingMenuButtons.Account) { AccountForm.Visibility = Visibility.Visible; }
            else if (e == Usercontrol_Settings.SettingsButtons.SettingMenuButtons.Colors) { ColorsForm.Visibility = Visibility.Visible; }

        }
    }
}
