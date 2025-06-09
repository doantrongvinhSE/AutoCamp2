using AutoCamp.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutoCamp.domain
{
    public class AdsDomain
    {
        public async static Task<string> getInfoTkqcUser(string cookie, string token, string? proxy = null)
        {
            var options = new RestClientOptions();
            if (proxy != null)
            {
                ProxyHelper.SetProxy(options, proxy);
            }

            var client = new RestClient(options);
            var allData = new List<JObject>();

            // Lần đầu truy cập adaccounts thông qua endpoint /me
            string? nextUrl = $"https://graph.facebook.com/v23.0/me/?fields=adaccounts.limit(100)%7Bname%2Caccount_id%2Caccount_status%2Ctax_country%2Ccurrency%2Cis_prepay_account%2Ctimezone_name%2Ccreated_time%2Cbalance%2Cnext_bill_date%2Cadtrust_dsl%2Cuser_tasks%2Cfunding_source_details%2Cadspaymentcycle%7D&access_token={token}";

            bool firstCall = true;

            while (!string.IsNullOrEmpty(nextUrl))
            {
                var request = new RestRequest(nextUrl, Method.Get);
                request.AddHeader("cookie", cookie);

                var response = await client.ExecuteAsync(request);

                if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                {
                    throw new Exception($"Lỗi gọi API: {response.StatusCode} - {response.ErrorMessage}");
                }

                JObject json;
                try
                {
                    json = JObject.Parse(response.Content);
                }
                catch (Exception ex)
                {
                    throw new Exception("Không parse được JSON trả về: " + ex.Message);
                }

                JArray? adAccounts = null;

                if (firstCall)
                {
                    adAccounts = json["adaccounts"]?["data"] as JArray;
                    nextUrl = json["adaccounts"]?["paging"]?["next"]?.ToString();
                    firstCall = false;
                }
                else
                {
                    adAccounts = json["data"] as JArray;
                    nextUrl = json["paging"]?["next"]?.ToString();
                }

                if (adAccounts != null)
                {
                    foreach (var item in adAccounts)
                    {
                        if (item is JObject obj)
                            allData.Add(obj);
                    }
                }
            }

            var resultJson = JsonConvert.SerializeObject(new { adaccounts = allData }, Formatting.Indented);
            return resultJson;
        }

        public async static Task<string> getInfoTkqcByBm(string cookie, string token, string idBm, string? proxy = null)
        {
            var options = new RestClientOptions("https://graph.facebook.com");
            if (proxy != null)
            {
                ProxyHelper.SetProxy(options, proxy);
            }

            var client = new RestClient(options);
            var allData = new List<JObject>();

            string? nextUrl = $"/v23.0/{idBm}/?fields=client_ad_accounts.limit(100)%7Bname%2Caccount_id%2Caccount_status%2Ctax_country%2Ccurrency%2Cis_prepay_account%2Ctimezone_name%2Ccreated_time%2Cbalance%2Cnext_bill_date%2Cadtrust_dsl%2Cfunding_source_details%2Cadspaymentcycle%7D&access_token={token}";
            bool firstCall = true;

            while (!string.IsNullOrEmpty(nextUrl))
            {
                var request = new RestRequest(nextUrl, Method.Get);
                request.AddHeader("cookie", cookie);

                var response = await client.ExecuteAsync(request);
                if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                {
                    throw new Exception($"Lỗi gọi API: {response.StatusCode} - {response.ErrorMessage}");
                }

                JObject json;
                try
                {
                    json = JObject.Parse(response.Content);
                }
                catch (Exception ex)
                {
                    throw new Exception("Không parse được JSON trả về: " + ex.Message);
                }

                JArray? dataArray;

                if (firstCall)
                {
                    dataArray = json["client_ad_accounts"]?["data"] as JArray;
                    nextUrl = json["client_ad_accounts"]?["paging"]?["next"]?.ToString();
                    firstCall = false;
                }
                else
                {
                    dataArray = json["data"] as JArray;
                    nextUrl = json["paging"]?["next"]?.ToString();
                }

                if (dataArray != null)
                {
                    foreach (var item in dataArray)
                    {
                        if (item is JObject obj)
                            allData.Add(obj);
                    }
                }
            }

            var resultJson = JsonConvert.SerializeObject(new { client_ad_accounts = allData }, Formatting.Indented);
            return resultJson;
        }





        public static async Task<string> checkCredit(string cookie, string idTkqc, string fb_dtsg, string? proxy = null)
        {
            string uidVia = HelperUtils.ExtractUserIdFromCookie(cookie);


            var options = new RestClientOptions("https://business.facebook.com")
            {
            };

            if (proxy != null)
            {
                ProxyHelper.SetProxy(options, proxy);
            }

            var client = new RestClient(options);
            var request = new RestRequest("/api/graphql/", Method.Post);
            request.AddHeader("accept", "*/*");
            request.AddHeader("origin", "https://business.facebook.com");
            request.AddHeader("priority", "u=1, i");
            request.AddHeader("sec-ch-ua-mobile", "?0");
            request.AddHeader("sec-ch-ua-model", "\"\"");
            request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
            request.AddHeader("sec-ch-ua-platform-version", "\"10.0.0\"");
            request.AddHeader("sec-fetch-dest", "empty");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-site", "same-origin");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("av", uidVia);
            request.AddParameter("__aaid", idTkqc);
            request.AddParameter("__user", uidVia);
            request.AddParameter("fb_dtsg", fb_dtsg);
            request.AddParameter("fb_api_req_friendly_name", "BillingHubPaymentMethodsBillableAccountSectionPaymentMethodsQuery");
            request.AddParameter("variables", "{\"paymentAccountID\":\"" + idTkqc + "\",\"channels\":[\"PERMISSION\"]}");
            request.AddParameter("doc_id", "8899973910108871");
            RestResponse response = await client.ExecuteAsync(request);

            string responseContent = response.Content ?? string.Empty;

            var match = Regex.Match(responseContent, "\"card_association_name\"\\s*:\\s*\"([^\"]+)\"");
            var match2 = Regex.Match(responseContent, "\"last_four_digits\"\\s*:\\s*\"([^\"]+)\"");

            if (responseContent.Contains("limit"))
            {
                return "VIA SPAM!";
            }


            if (match.Success)
            {
                return match.Groups[1].Value + " - " + match2.Groups[1].Value;
            }
            else
            {
                return "Không có thẻ!";
            }

        }


        public static async Task<string> checkCredit2(string cookie, string token, string idTkqc, string? proxy = null)
        {
            var options = new RestClientOptions("https://graph.facebook.com");

            if (proxy != null)
            {
                ProxyHelper.SetProxy(options, proxy);
            }

            var client = new RestClient(options);
            var request = new RestRequest("/v15.0/act_" + idTkqc + "?fields=all_payment_methods%7Bpm_credit_card%7Bdisplay_string,exp_month,exp_year,is_verified%7D%7D&access_token=" + token, Method.Get);

            request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/135.0.0.0 Safari/537.36");
            request.AddHeader("origin", "https://business.facebook.com");
            request.AddHeader("sec-fetch-site", "same-site");
            request.AddHeader("Cookie", cookie);

            RestResponse response = await client.ExecuteAsync(request);

            string responseContent = response.Content ?? string.Empty;

            var match = Regex.Match(responseContent, "\"display_string\"\\s*:\\s*\"([^\"]+)\"");

            if (match.Success)
            {
                return Regex.Unescape(match.Groups[1].Value);
            }


            return "Không có thẻ!";
        }

        public static async Task<string> checkCredit3(string cookie, string fb_dtsg, string idTkqc, string? proxy = null)
        {
            var options = new RestClientOptions("https://business.facebook.com")
            {
                MaxTimeout = -1,
            };

            if (proxy != null)
            {
                ProxyHelper.SetProxy(options, proxy);
            }

            var client = new RestClient(options);
            var request = new RestRequest("/api/graphql/", Method.Post);
            request.AddHeader("accept", "*/*");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("origin", "https://business.facebook.com");
            request.AddHeader("priority", "u=1, i");
            request.AddHeader("sec-ch-prefers-color-scheme", "light");
            request.AddHeader("sec-ch-ua", "\"Google Chrome\";v=\"135\", \"Not-A.Brand\";v=\"8\", \"Chromium\";v=\"135\"");
            request.AddHeader("sec-ch-ua-full-version-list", "\"Google Chrome\";v=\"135.0.7049.97\", \"Not-A.Brand\";v=\"8.0.0.0\", \"Chromium\";v=\"135.0.7049.97\"");
            request.AddHeader("sec-ch-ua-mobile", "?0");
            request.AddHeader("sec-ch-ua-model", "\"\"");
            request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
            request.AddHeader("sec-ch-ua-platform-version", "\"10.0.0\"");
            request.AddHeader("sec-fetch-dest", "empty");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-site", "same-origin");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("variables", "{\"paymentAccountID\":\"" + idTkqc + "\"}");
            request.AddParameter("doc_id", "5584576741653814");
            request.AddParameter("fb_dtsg", fb_dtsg);
            RestResponse response = await client.ExecuteAsync(request);

            string responseContent = response.Content ?? string.Empty;

            var match = Regex.Match(responseContent, "\"card_association_name\"\\s*:\\s*\"([^\"]+)\"");
            var match2 = Regex.Match(responseContent, "\"last_four_digits\"\\s*:\\s*\"([^\"]+)\"");

            if (responseContent.Contains("limit"))
            {
                return "VIA SPAM!";
            }


            if (match.Success)
            {
                return match.Groups[1].Value + " - " + match2.Groups[1].Value;
            }
            else
            {
                return "Không có thẻ!";
            }


        }

        public static async Task<string> checkXMSDT(string cookie, string? proxy = null)
        {
            string token = await TokenCookieDomain.getTokenEAABs(cookie, proxy);

            string idTkqc = await getIdPrimaryTkqc(cookie, token, proxy);

            var options = new RestClientOptions("https://adsmanager-graph.facebook.com")
            {
                MaxTimeout = -1,
            };

            if (proxy != null)
            {
                ProxyHelper.SetProxy(options, proxy);
            }

            var client = new RestClient(options);
            var request = new RestRequest("/v21.0/" + idTkqc + "/start_your_day_init_tasks?access_token=" + token, Method.Post);
            request.AddHeader("accept", "*/*");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("origin", "https://adsmanager.facebook.com");
            request.AddHeader("priority", "u=1, i");
            request.AddHeader("referer", "https://adsmanager.facebook.com/");
            request.AddHeader("sec-ch-ua-mobile", "?0");
            request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
            request.AddHeader("sec-fetch-dest", "empty");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-site", "same-site");
            request.AddHeader("Cookie", cookie);
            RestResponse response = await client.ExecuteAsync(request);

            string responseResult = response.Content ?? string.Empty;

            if (responseResult.Contains("PHONE_NUMBER_VERIFICATION"))
            {
                return "Chưa XMSDT!";
            }

            return "Đã XMSDT";
        }

        public static async Task<string> getIdPrimaryTkqc(string cookie, string token, string? proxy = null)
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
            var request = new RestRequest("/v22.0/me?fields=personal_ad_accounts.limit(1)%7Bid%7D&access_token=" + token, Method.Get);
            request.AddHeader("cookie", cookie);
            RestResponse response = await client.ExecuteAsync(request);

            string responseResult = response.Content ?? string.Empty;


            var match = Regex.Match(responseResult, "\"id\"\\s*:\\s*\"([^\"]+)\"");

            if (match.Success)
            {
                return match.Groups[1].Value;
            }

            return "Lỗi";
        }

        public static async Task<string> checkTKLT(string cookie, string idTkqc, string fb_dtsg, string? proxy = null)
        {
            var options = new RestClientOptions("https://business.facebook.com")
            {
                MaxTimeout = -1,
            };

            if (proxy != null && proxy.Length > 0)
            {
                ProxyHelper.SetProxy(options, proxy);
            }

            var client = new RestClient(options);
            var request = new RestRequest("/api/graphql/", Method.Post);
            request.AddHeader("accept", "*/*");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("origin", "https://business.facebook.com");
            request.AddHeader("priority", "u=1, i");
            request.AddHeader("sec-ch-prefers-color-scheme", "light");
            request.AddHeader("sec-ch-ua", "\"Google Chrome\";v=\"135\", \"Not-A.Brand\";v=\"8\", \"Chromium\";v=\"135\"");
            request.AddHeader("sec-ch-ua-full-version-list", "\"Google Chrome\";v=\"135.0.7049.97\", \"Not-A.Brand\";v=\"8.0.0.0\", \"Chromium\";v=\"135.0.7049.97\"");
            request.AddHeader("sec-ch-ua-mobile", "?0");
            request.AddHeader("sec-ch-ua-model", "\"\"");
            request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
            request.AddHeader("sec-ch-ua-platform-version", "\"10.0.0\"");
            request.AddHeader("sec-fetch-dest", "empty");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-site", "same-origin");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("variables", "{\"paymentAccountID\":\"" + idTkqc + "\"}");
            request.AddParameter("doc_id", "5584576741653814");
            request.AddParameter("fb_dtsg", fb_dtsg);
            RestResponse response = await client.ExecuteAsync(request);

            string responseContent = response.Content ?? string.Empty;

            JObject obj = JObject.Parse(responseContent);

            var paymentModes = obj["data"]?["billable_account_by_payment_account"]?["payment_modes"];

            int count = 0;

            if (paymentModes != null)
            {
                foreach (var mode in paymentModes)
                {
                    if (mode.ToString() == "SUPPORTS_PREPAY")
                    {
                        count++;
                    }
                    if (mode.ToString() == "SUPPORTS_POSTPAY")
                    {
                        count++;
                    }
                }
            }

            if (count == 2)
            {
                return "Tài khoản lưỡng tĩnh";
            }
            else if (count == 1)
            {
                return "Tài khoản 1 chiều";
            }
            else
            {
                return "Không phải TKLT";
            }
        }


        // check again tk 
        public static async Task<string> checkAgainTk(string cookie, string token, string idTkqc, string? proxy = null)
        {
            var options = new RestClientOptions("https://adsmanager-graph.facebook.com")
            {
                MaxTimeout = -1,
            };

            if (proxy != null)
            {
                ProxyHelper.SetProxy(options, proxy);
            }

            var client = new RestClient(options);
            var request = new RestRequest("/v19.0/act_" + idTkqc + "?access_token=" + token + "&fields=[%22id%22,%22name%22,%22account_id%22,%22account_status%22,%22currency%22,%22created_time%22,%22timezone_name%22,%22business_country_code%22,%22can_pay_now%22,%22current_unbilled_spend%22,%22adtrust_dsl%22,%22funding_source%22,%22tax_id%22,%22business_state%22,%22business_zip%22,%22user_tasks%22,%22current_addrafts%22,%22amount_spent%22,%22spend_cap%22,%22ads.fields(status,creative.fields(object_story_id,effective_object_story_id,%20status),delivery_status,adset_id,campaign_id,values).limit(300)%22,%22campaigns.fields(name,lifetime_budget,daily_budget,status,values).limit(300)%22,%22adsets.fields(status,campaign_id,lifetime_budget,daily_budget,lifetime_min_spend_target,lifetime_spend_cap,daily_min_spend_target,daily_spend_cap,start_time,end_time,values).limit(300)%22,%22adspaymentcycle.fields(threshold_amount).limit(1)%22,%22adspixels.fields(id,name)%22,%22default_values.fields(ad_group.fields(related_page_id))%22,%22prepay_account_balance%22,%22funding_source_details%22]&method=get&pretty=0", Method.Get);
            request.AddHeader("Cookie", cookie);
            RestResponse response = await client.ExecuteAsync(request);

            return response.Content ?? "Lỗi load lại...";
        }

    }



}
