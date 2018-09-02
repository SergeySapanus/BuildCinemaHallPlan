using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using WSVistaWebClientTest.Domain.Abstract;
using WSVistaWebClientTest.Domain.Entities;

namespace WSVistaWebClientTest.Domain.Concrete
{
    public class PlanProcessor : IPlanProcessor
    {
        private readonly string _api;

        public PlanProcessor(string api)
        {
            _api = api;
        }

        public Plan GetPlan()
        {
            if (string.IsNullOrWhiteSpace(_api))
                throw new ArgumentException(nameof(_api));

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            var serializer = new JavaScriptSerializer();

            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;

                var proxy = WebRequest.GetSystemWebProxy();
                proxy.Credentials = CredentialCache.DefaultCredentials;

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(_api);
                httpWebRequest.Proxy = proxy;
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                var responseStream = httpWebRequest.GetResponse().GetResponseStream();
                if (responseStream == null)
                    throw new WebException("responseStream is null");

                using (var streamReader = new StreamReader(responseStream))
                {
                    return serializer.Deserialize<Plan>(streamReader.ReadToEnd());
                }
            }
        }
    }
}