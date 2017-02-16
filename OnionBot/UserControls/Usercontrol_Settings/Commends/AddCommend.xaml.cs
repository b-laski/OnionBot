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

namespace OnionBot.UserControls.Usercontrol_Settings.Commends
{
    /// <summary>
    /// Interaction logic for AddCommend.xaml
    /// </summary>
    public partial class AddCommend : UserControl
    {
        public delegate void AddCommendEventHundler(object sender, SelectedButton e);
        public event AddCommendEventHundler ButtonClick;
        public enum SelectedButton
        {
            Add,
            Cancel
        }

        public AddCommend()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick?.Invoke(this, SelectedButton.Cancel);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            addCommendToDatabase();
            ButtonClick?.Invoke(this, SelectedButton.Add);
        }

        private void addCommendToDatabase()
        {

        }
    }
}
