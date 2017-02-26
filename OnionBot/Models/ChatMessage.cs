using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionBot.Models
{
    public class ChatMessage : Utilities.ViewModelBase
    {
        private string _username = null;
        private List<KeyValuePair<string, string>> _badges = new List<KeyValuePair<string, string>>();
        private string _color = null;
        private string _message = null;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged("Username"); // co to robi?  To aktualizuje automatycznie View jak zmienia sie zmienna z Modela i viceversa
            }
        }
        public string Color
        {
            get { return _color; }
            set
            {
                _color = value;
                OnPropertyChanged("Color");
            }
        }
        public List<KeyValuePair<string, string>> Badges
        {
            get { return _badges; }
            set
            {
                _badges = value;
                OnPropertyChanged("Badges");
            }
        }
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }
    }
}
