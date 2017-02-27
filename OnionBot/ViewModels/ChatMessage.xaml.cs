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

namespace OnionBot.ViewModels
{
    /// <summary>
    /// Interaction logic for ChatMessage.xaml
    /// </summary>
    public partial class ChatMessage : UserControl
    {
        public Models.ChatMessage ConvertedModel
        {
            get
            {
                if (this.DataContext != null)
                    return (Models.ChatMessage)
                        this.DataContext;
                else return null;
            }
        }

        public ChatMessage()
        {
            InitializeComponent();
        }

        public ChatMessage(Models.ChatMessage _content)
        {
            InitializeComponent();

            this.DataContext = _content;
            UpdateIcon(_content);
        }
        private void UpdateIcon(Models.ChatMessage _content)
        {
            if (ConvertedModel != null)
            {
                try
                {
                    foreach (var _badge in _content.Badges)
                    {
                        if (_badge.Key.Contains("broadcaster"))
                        {
                            iconPanel.Children.Add(new MaterialDesignThemes.Wpf.PackIcon
                            {
                                Height = 16,
                                Width = 16,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                Kind = MaterialDesignThemes.Wpf.PackIconKind.Camera,
                                Foreground = Brushes.Red,
                                Margin = new Thickness(2, 0, 5, 0)
                            });


                        }
                        else if (_badge.Key.Contains("staff"))
                        {
                            iconPanel.Children.Add(new MaterialDesignThemes.Wpf.PackIcon
                            {
                                Height = 16,
                                Width = 16,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                Kind = MaterialDesignThemes.Wpf.PackIconKind.Wrench,
                                Foreground = Brushes.Red,
                                Margin = new Thickness(2, 0, 5, 0)
                            });
                        }
                        else if (_badge.Key.Contains("admin"))
                        {
                            iconPanel.Children.Add(new MaterialDesignThemes.Wpf.PackIcon
                            {
                                Height = 16,
                                Width = 16,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                Kind = MaterialDesignThemes.Wpf.PackIconKind.Star,
                                Foreground = Brushes.Yellow,
                                Margin = new Thickness(2, 0, 5, 0)
                            });
                        }
                        else if (_badge.Key.Contains("global_mod"))
                        {
                            iconPanel.Children.Add(new MaterialDesignThemes.Wpf.PackIcon
                            {
                                Height = 16,
                                Width = 16,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                Kind = MaterialDesignThemes.Wpf.PackIconKind.Cake,
                                Foreground = Brushes.Green,
                                Margin = new Thickness(2, 0, 2, 0)
                            });
                        }
                        else if (_badge.Key.Contains("moderator"))
                        {
                            iconPanel.Children.Add(new MaterialDesignThemes.Wpf.PackIcon
                            {
                                Height = 16,
                                Width = 16,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                Kind = MaterialDesignThemes.Wpf.PackIconKind.Sword,
                                Foreground = Brushes.Green,
                                Margin = new Thickness(2, 0, 2, 0)
                            });
                        }
                        else if (_badge.Key.Contains("subscriber"))
                        {
                            iconPanel.Children.Add(new MaterialDesignThemes.Wpf.PackIcon
                            {
                                Height = 16,
                                Width = 16,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                Kind = MaterialDesignThemes.Wpf.PackIconKind.Camera,
                                Foreground = Brushes.Red,
                                Margin = new Thickness(2, 0, 2, 0)
                            });
                        }
                        else if (_badge.Key.Contains("turbo"))
                        {
                            iconPanel.Children.Add(new MaterialDesignThemes.Wpf.PackIcon
                            {
                                Height = 16,
                                Width = 16,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                Kind = MaterialDesignThemes.Wpf.PackIconKind.BatteryCharging,
                                Foreground = Brushes.Purple,
                                Margin = new Thickness(2, 0, 2, 0)
                            });
                        }
                        else if (_badge.Key.Contains("prime"))
                        {
                            iconPanel.Children.Add(new MaterialDesignThemes.Wpf.PackIcon
                            {
                                Height = 16,
                                Width = 16,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                Kind = MaterialDesignThemes.Wpf.PackIconKind.Crown,
                                Foreground = Brushes.Blue,
                                Margin = new Thickness(2, 0, 2, 0)
                            });
                        }
                        else if (_badge.Key.Contains("bot"))
                        {
                            iconPanel.Children.Add(new MaterialDesignThemes.Wpf.PackIcon
                            {
                                Height = 16,
                                Width = 16,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                Kind = MaterialDesignThemes.Wpf.PackIconKind.Android,
                                Foreground = Brushes.Purple,
                                Margin = new Thickness(2, 0, 2, 0)
                            });
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }
    }
}
