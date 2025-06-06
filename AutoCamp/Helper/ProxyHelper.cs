using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoCamp.Helper
{
    public class ProxyHelper
    {
        public static async Task<string> getIp(string? proxy = null)
        {
            string url = "https://whois.inet.vn/api/ifconfig";

            try
            {
                // khởi tạo client
                var options = new RestClientOptions(url)
                {
                    Timeout = TimeSpan.FromSeconds(30) // 30 giây
                };

                if (proxy != null)
                {
                    SetProxy(options, proxy);
                }

                var client = new RestClient(options);

                // tạo request
                var request = new RestRequest();

                var res = await client.GetAsync(request);

                if (res.Content != null)
                {
                    return res.Content;
                }
                else
                {
                    return "IP not found";
                }
            }
            catch
            {
                return "Đã xảy ra lỗi khi lấy IP";
            }
        }


        public static void SetProxy(RestClientOptions options, string? proxy = null)
        {
            if (proxy != null)
            {
                string[] proxyParts = proxy.Split(':');
                if (proxyParts.Length == 4) // host:port:username:password
                {
                    string host = proxyParts[0];
                    int port = int.Parse(proxyParts[1]);
                    string username = proxyParts[2];
                    string password = proxyParts[3];

                    WebProxy webProxy = new WebProxy(host, port);
                    webProxy.Credentials = new NetworkCredential(username, password);
                    webProxy.BypassProxyOnLocal = false;
                    options.Proxy = webProxy;
                }
                else if (proxyParts.Length == 2) // host:port
                {
                    WebProxy webProxy = new WebProxy(proxyParts[0], int.Parse(proxyParts[1]));
                    webProxy.BypassProxyOnLocal = false;
                    options.Proxy = webProxy;
                }
            }
        }
    }
}
