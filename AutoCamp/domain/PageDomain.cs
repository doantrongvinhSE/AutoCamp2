using AutoCamp.Helper;
using AutoCamp.models;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCamp.domain
{
    public class PageDomain
    {
        public static async Task<List<PageInfoModel>> getDataAllPage(string cookie, string token, string? proxy = null)
        {
            string uid = HelperUtils.ExtractUserIdFromCookie(cookie);
            var options = new RestClientOptions("https://graph.facebook.com")
            {
                MaxTimeout = -1,
            };

            if (proxy != null)
            {
                ProxyHelper.SetProxy(options, proxy);
            }

            var client = new RestClient(options);
            var request = new RestRequest("/v14.0/" + uid + "/facebook_pages?access_token=" + token + "&limit=5000&fields=[%22category%22,%22name%22,%22additional_profile_id%22]&include_headers=false&pretty=0", Method.Get);
            request.AddHeader("Cookie", cookie);
            RestResponse response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
            {
                Console.WriteLine("Request failed or empty response.");
                return new List<PageInfoModel>();
            }

            try
            {
                var json = JObject.Parse(response.Content);
                var data = json["data"]?.ToObject<List<PageInfoModel>>();
                return data ?? new List<PageInfoModel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error parsing response: " + ex.Message);
                return new List<PageInfoModel>();
            }

        }


        public async static Task<List<string>> getAllPostPage(string cookie, string token, string idPage, string? proxy = null)
        {
            var options = new RestClientOptions("https://graph.facebook.com")
            {
                MaxTimeout = -1,
            };

            if (proxy != null)
            {
                ProxyHelper.SetProxy(options, proxy);
            }

            var client = new RestClient(options);

            var request = new RestRequest($"/v11.0/{idPage}/posts?access_token={token}&limit=100&fields=message&include_headers=false&pretty=0", Method.Get);
            request.AddHeader("Cookie", cookie);

            RestResponse response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
            {
                Console.WriteLine("Request failed or empty response.");
                return new List<string>();
            }

            try
            {
                var json = JObject.Parse(response.Content);
                var data = json["data"];
                var result = new List<string>();

                if (data != null)
                {
                    foreach (var item in data)
                    {
                        if (item["message"] != null && item["id"] != null)
                        {
                            string fullId = item["id"]!.ToString();
                            if (fullId.Contains("_"))
                            {
                                // Lấy phần sau dấu gạch dưới
                                var parts = fullId.Split('_');
                                if (parts.Length == 2)
                                {
                                    result.Add(parts[1]);
                                }
                            }
                        }
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error parsing response: " + ex.Message);
                return new List<string>();
            }
        }


    }
}
