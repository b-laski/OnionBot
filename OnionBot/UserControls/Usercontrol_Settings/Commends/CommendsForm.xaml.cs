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
    /// Interaction logic for CommendsForm.xaml
    /// </summary>
    public partial class CommendsForm : UserControl
    {
        public delegate void AddCommendEventHundler(object sender, EventArgs e);
        public event AddCommendEventHundler ButtonClick;

        public CommendsForm()
        {
            InitializeComponent();
        }

        private void btnNewCommend_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick?.Invoke(this, e);
        }
    }
}
