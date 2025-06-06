using AutoCamp.Helper;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutoCamp.domain
{
    public class TokenCookieDomain
    {
        public static string getActId(string cookie, string? proxy = null)
        {

            var options = new RestClientOptions("https://adsmanager.facebook.com")
            {
                UserAgent = "Mozilla/5.0(Windows NT 10.0; WOW64; rv:58.0) Gecko/20100101 Firefox/58.0"
            };


            ProxyHelper.SetProxy(options, proxy);


            var client = new RestClient(options);
            var request = new RestRequest("/adsmanager/manage/campaigns", Method.Get);


            // Thêm các headers
            request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
            request.AddHeader("sec-ch-ua", "\"Chromium\";v=\"134\", \"Not:A-Brand\";v=\"24\", \"Google Chrome\";v=\"134\"");
            request.AddHeader("sec-ch-ua-mobile", "?0");
            request.AddHeader("sec-fetch-site", "none");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-dest", "empty");
            request.AddHeader("sec-fetch-storage-access", "active");
            request.AddHeader("accept-language", "en-US,en;q=0.9,vi;q=0.8");
            request.AddHeader("priority", "u=1, i");
            request.AddHeader("Cookie", cookie.Trim());

            // Gửi request
            var response = client.Execute(request);

            if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
            {
                string pattern = @"(?<=act=)\d+";
                Match match = Regex.Match(response.Content, pattern);

                if (match.Success)
                {
                    return match.Value;
                }
            }

            return "Lỗi"; // hoặc throw exception tùy bạn xử lý
        }

        public static async Task<string> getTokenEAABs(string cookie, string? proxy = null)
        {
            // Lấy actId từ hàm trước đó
            string actId = getActId(cookie, proxy);
            string url = $"https://adsmanager.facebook.com/adsmanager/manage/campaigns?act={actId}";

            var options = new RestClientOptions("https://adsmanager.facebook.com")
            {
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36",

            };

            if (proxy != null)
            {
                ProxyHelper.SetProxy(options, proxy);
            }   

            var client = new RestClient(options);
            var request = new RestRequest($"/adsmanager/manage/campaigns?act={actId}", Method.Get);

            // Thêm headers
            request.AddHeader("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
            request.AddHeader("accept-language", "en-US,en;q=0.9,vi;q=0.8");
            request.AddHeader("dpr", "1");
            request.AddHeader("priority", "u=0, i");
            request.AddHeader("sec-ch-prefers-color-scheme", "light");
            request.AddHeader("sec-ch-ua", "\"Chromium\";v=\"134\", \"Not:A-Brand\";v=\"24\", \"Google Chrome\";v=\"134\"");
            request.AddHeader("sec-ch-ua-full-version-list", "\"Chromium\";v=\"134.0.6998.36\", \"Not:A-Brand\";v=\"24.0.0.0\", \"Google Chrome\";v=\"134.0.6998.36\"");
            request.AddHeader("sec-ch-ua-mobile", "?0");
            request.AddHeader("sec-ch-ua-model", "\"\"");
            request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
            request.AddHeader("sec-ch-ua-platform-version", "\"10.0.0\"");
            request.AddHeader("sec-fetch-dest", "document");
            request.AddHeader("sec-fetch-mode", "navigate");
            request.AddHeader("sec-fetch-site", "none");
            request.AddHeader("sec-fetch-user", "?1");
            request.AddHeader("upgrade-insecure-requests", "1");
            request.AddHeader("viewport-width", "568");
            request.AddHeader("Cookie", cookie.Trim());

            // Gửi request
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
            {
                string pattern = @"_accessToken=""(EAAB[a-zA-Z0-9]+)""";
                Match match = Regex.Match(response.Content, pattern);
                if (match.Success)
                {
                    return match.Groups[1].Value;
                }
            }

            return "Lỗi lấy Token"; // hoặc throw exception nếu cần
        }

        public async static Task<string> getFbDtsg(string cookie, string? proxy = null)
        {
            string result = "";

            try
            {
                var options = new RestClientOptions("https://www.facebook.com")
                {
                    MaxTimeout = -1,
                };

                if (proxy != null)
                {
                    ProxyHelper.SetProxy(options, proxy);
                }

                var client = new RestClient(options);
                var request = new RestRequest("/", Method.Get);
                request.AddHeader("sec-fetch-site", "same-origin");
                request.AddHeader("Cookie", cookie);
                RestResponse response = await client.ExecuteAsync(request);
                

                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    string pattern = @"""token"":""([^""]+?)""";
                    Regex regex = new Regex(pattern);
                    MatchCollection matches = regex.Matches(response.Content);

                    foreach (Match match in matches)
                    {
                        string token = match.Groups[1].Value;
                        if (token.Length > 40)
                        {
                            result = token;
                            break;
                        }
                    }
                }
                else
                {
                    return "Lỗi";
                }
            }
            catch
            {
                return "Lỗi";
            }

            return result;

        }


    }
}
