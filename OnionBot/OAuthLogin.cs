using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OnionBot
{
    class OAuthLogin
    {
        private HttpListener linkListener;
        private string app_token;

        public OAuthLogin()
        {
            linkListener = new HttpListener();
        }
        public OAuthLogin(string app_token)
        {
            this.app_token = app_token;
            linkListener = new HttpListener();
        }

        public void Start() //dLPY7SsqnQUeVXChcZ3jz4J0NyHx1tp2gkWrG8wf
        {
            BackgroundWorker bgWorker = new BackgroundWorker();
            bgWorker.DoWork += BgWorker_DoWork;
            bgWorker.RunWorkerCompleted += BgWorker_RunWorkerCompleted;
            bgWorker.RunWorkerAsync();

            Process.Start(string.Format(@"https://api.hitbox.tv/oauth/login?app_token={0}", app_token));
        }

        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            linkListener.Prefixes.Add(@"http://localhost/hitboxclient/token/");
            linkListener.Start();

            HttpListenerContext context = linkListener.GetContext();
            HttpListenerRequest request = context.Request;

            string requestToken = "";
            string parameterName = "request_token=";
            requestToken = request.RawUrl.Substring(request.RawUrl.IndexOf(parameterName) + parameterName.Length);
            e.Result = requestToken;

            HttpListenerResponse response = context.Response;

            string responseMessage = "self.close()";
            byte[] buffer = Encoding.UTF8.GetBytes(responseMessage);

            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();

            linkListener.Stop();
        }

        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
