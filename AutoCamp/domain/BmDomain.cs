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
    public class BmDomain
    {
        public static async Task<string> geiIdsBm(string cookie, string? proxy = null)
        {
            string token = await TokenCookieDomain.getTokenEAABs(cookie, proxy);


            var options = new RestClientOptions();

            if (proxy != null)
            {
                ProxyHelper.SetProxy(options, proxy);
            }

            var client = new RestClient(options);
            var request = new RestRequest("https://graph.facebook.com/v22.0/me?fields=businesses.limit(100)%7Bname%7D&access_token=" + token, Method.Get);
            request.AddHeader("cookie", cookie);
            RestResponse response = await client.ExecuteAsync(request);

            return response.Content ?? String.Empty;
        }

        public static async Task<string> getGroupBm(string cookie, string idBm, string? proxy = null)
        {
            string token = await TokenCookieDomain.getTokenEAABs(cookie, proxy);


            var options = new RestClientOptions();
            var client = new RestClient(options);
            var request = new RestRequest("https://graph.facebook.com/v22.0/" + idBm + "/business_asset_groups?fields=name%2Cid&limit=100&access_token=" + token, Method.Get);
            request.AddHeader("cookie", cookie);
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);

            return response.Content ?? String.Empty;
        }


        public static async Task<string> getAdsAccountByGroup(string cookie, string token, string idGroup, string? proxy = null)
        {

            var options = new RestClientOptions();

            if (proxy != null)
            {
                ProxyHelper.SetProxy(options, proxy);
            }

            var client = new RestClient(options);
            var request = new RestRequest("https://graph.facebook.com/v22.0/" + idGroup + "?fields=contained_adaccounts.limit(300)%7Baccount_id%2Caccount_status%2Cadtrust_dsl%2Cname%2Camount_spent%2Cbalance%2Cis_prepay_account%2Ccreated_time%2Ctimezone_name%2Ccurrency%2Ctax_country%2Cnext_bill_date%2Cfunding_source_details%2Cadspaymentcycle%7D&access_token=" + token, Method.Get);
            request.AddHeader("cookie", cookie);
            RestResponse response = await client.ExecuteAsync(request);

            return response.Content ?? string.Empty;
        }


        public static async Task<string> getIdAssetsAsync(string cookie, string idBM, string idTkqc, string dtsg, string? proxy = null)
        {
            var options = new RestClientOptions()
            {
                Timeout = TimeSpan.FromSeconds(60),
            };

            string uidVia = HelperUtils.ExtractUserIdFromCookie(cookie);

            ProxyHelper.SetProxy(options, proxy);


            var client = new RestClient(options);
            var request = new RestRequest("https://business.facebook.com/api/graphql", Method.Post);
            request.AddHeader("accept", "*/*");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-site", "same-origin");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("av", uidVia);
            request.AddParameter("__aaid", "0");
            request.AddParameter("__bid", idBM);
            request.AddParameter("__user", uidVia);
            request.AddParameter("fb_dtsg", dtsg);
            request.AddParameter("variables", "{\"assetFilters\":{\"whatsapp_business_account_statuses\":[\"ACTIVE\"]},\"assetTypes\":[\"AD_ACCOUNT\"],\"businessID\":\"" + idBM + "\",\"count\":14,\"cursor\":null,\"globalFilters\":{},\"orderBy\":null,\"searchTerm\":\"" + idTkqc + "\",\"shouldCountAdmin\":false,\"id\":\"" + idBM + "\"}");

            request.AddParameter("doc_id", "8839900382783313");
            RestResponse response = await client.ExecuteAsync(request);

            string pattern = @"""assetID"":""(\d+)""";
            Regex regex = new Regex(pattern);

            Match match = Regex.Match(response.Content, pattern);


            if (match.Success)
            {
                string assetID = match.Groups[1].Value;
                return assetID;
            }

            return "Lỗi";
        }

        // check thẻ
       public async static Task<string> getFullInfoTkqc(string cookie, string token, string idTkqc,string? proxy = null)
        {

            var options = new RestClientOptions()
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("https://graph.facebook.com/v15.0/act_"+idTkqc+"?fields=business%2Cowner_business%2Cname%2Caccount_id%2Cdisable_reason%2Caccount_status%2Ccurrency%2Cadspaymentcycle%2Cadtrust_dsl%2Cbalance%2Camount_spent%2Caccount_currency_ratio_to_usd%2Cusers%2Call_payment_methods%7Bpm_credit_card%7Bdisplay_string%2Cexp_month%2Cexp_year%2Cis_verified%7D%7D%2Ccreated_time%2Cnext_bill_date%2Ctimezone_name%2Ctimezone_offset_hours_utc%2Cinsights.date_preset(maximum)%7Bspend%7D%2Cuserpermissions%2Cowner%2Cis_prepay_account%0D%0A&summary=true&access_token=" + token, Method.Get);
            request.AddHeader("Cookie", cookie);
            RestResponse response = await client.ExecuteAsync(request);

            return response.Content ?? string.Empty;
        }
    }
}
