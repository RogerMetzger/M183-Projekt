using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Net.Http;
using System.Net;
using System.Text;
using System.IO;

namespace MiniBlog.Services
{
    public class MobileService
    {
        private static readonly HttpClient client = new HttpClient();

        public string SendSMS(int secret, string phonenumber)
        {
            string apiKey = "fcf8f7cf";
            string apiSecret = "6c2a54203bd0bc8d";
            var request = (HttpWebRequest)WebRequest.Create("https://rest.nexmo.com/sms/json");

            string postData = "api_key=" + apiKey;
            postData += "&api_secret=" + apiSecret;
            postData += "&to=" + phonenumber;
            postData += "&from=\"\"Mini Blog\"\"";
            postData += "&text=\"" + secret;
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }
    }
}