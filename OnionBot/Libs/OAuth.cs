using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionBot.Libs
{
    public static class OAuth
    {
        private static string _userID = null;
        private static string _oAuth = null;
        private static string _channel = null;

        public static string UserID
        {
            get { return _userID; }
            set
            {
                if (_userID == null)
                {
                    _userID = value;
                }
            }
        }
        public static string OAuthToken
        {
            get { return _oAuth; }
            set
            {
                if (_oAuth == null)
                {
                    _oAuth = value;
                }
                else
                {
                    throw new Exception("SORKA ZJEBALES!");
                }
            }
        }
        public static string Channel
        {
            get { return _channel; }
            set
            {
                if (_channel == null)
                {
                    _channel = value;
                }
            }
        }
    }
}
