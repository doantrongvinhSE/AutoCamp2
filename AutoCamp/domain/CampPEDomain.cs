using AutoCamp.Helper;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AutoCamp.domain
{
    public class CampPEDomain
    {
        public static async Task<String> uploadDraftCamp(string cookie, string token, string fb_dtsg, string idTkqc, string textFile ,string? proxy = null)
        {
            string uidVia = HelperUtils.ExtractUserIdFromCookie(cookie);


            var options = new RestClientOptions("https://adsmanager.facebook.com")
            {
                MaxTimeout = -1,
            };

            if (proxy != null)
            {
                ProxyHelper.SetProxy(options, proxy);
            }

            var client = new RestClient(options);
            var request = new RestRequest("/adsmanager/loadtsv/?ads_manager_write_regions=true&_callFlowletID=0&_triggerFlowletID=39129&qpl_active_flow_instance_ids=270216139_e0f0b5cb279b02ab02a,270219019_e0f1eef39c9fbe61299&qpl_active_e2e_trace_ids=270216139_f35000bac6dfad52b", Method.Post);
            request.AddHeader("accept", "*/*");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("origin", "https://adsmanager.facebook.com");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-site", "same-origin");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("account_id", idTkqc);
            request.AddParameter("app_id", "119211728144504");
            request.AddParameter("import_session_token", "fa30cbe9e63004716");
            request.AddParameter("tsv", textFile);
            request.AddParameter("__aaid", idTkqc);
            request.AddParameter("__user", uidVia);
            request.AddParameter("__a", "1");
            request.AddParameter("fb_dtsg", fb_dtsg);
            request.AddParameter("lsd", "u-87ToDqgg90rlXouPB9Pb");
            RestResponse response = await client.ExecuteAsync(request);
    
            string responseContent = response.Content ?? string.Empty;

            string result = "";

            Task.Delay(8000).Wait();

            if (responseContent.Contains("async_session_id"))
            {
                 result = await checkStatusUpDraftPe(cookie, token, idTkqc, proxy);
                 return result;
            }


            return "Đăng bản nháp thất bại!";
        }
    
    
        public async static Task<string> getAddraftId(string cookie, string token, string idTKQC ,string? proxy = null)
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
            var request = new RestRequest("/v22.0/act_"+ idTKQC + "/current_addrafts?access_token=" + token, Method.Get);
            request.AddHeader("cookie", cookie);
            RestResponse response = await client.ExecuteAsync(request);

            string result = response.Content;

            JObject obj = JObject.Parse(result);


            string id = "";

            try
            {
                 id = (string)obj["data"]?[0]?["id"];

            } catch
            {
                return "Lỗi lấy id draft";
            }

            return id;
        }


        public async static Task<string> getIdCampAdsDraft(string cookie, string token, string idTkqc, string? proxy = null)
        {
            string idDraft = await getAddraftId(cookie, token, idTkqc, proxy);

            var options = new RestClientOptions("https://graph.facebook.com")
            {
                MaxTimeout = -1,
            };

            ProxyHelper.SetProxy(options, proxy);

            var client = new RestClient(options);
            var request = new RestRequest("/v12.0/" + idDraft + "/addraft_fragments?access_token=" + token, Method.Get);
            request.AddHeader("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
            request.AddHeader("accept-language", "en-US,en;q=0.9,vi;q=0.8");
            request.AddHeader("cache-control", "max-age=0");
            request.AddHeader("priority", "u=0, i");
            request.AddHeader("sec-ch-ua", "\"Chromium\";v=\"136\", \"Google Chrome\";v=\"136\", \"Not.A/Brand\";v=\"99\"");
            request.AddHeader("sec-ch-ua-mobile", "?0");
            request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
            request.AddHeader("sec-fetch-dest", "document");
            request.AddHeader("sec-fetch-mode", "navigate");
            request.AddHeader("sec-fetch-site", "none");
            request.AddHeader("sec-fetch-user", "?1");
            request.AddHeader("upgrade-insecure-requests", "1");
            request.AddHeader("Cookie", cookie);
            RestResponse response = await client.ExecuteAsync(request);

            string result = response.Content ?? string.Empty;

            try
            {
                JObject obj = JObject.Parse(result);
                var dataArray = obj["data"] as JArray;

                if (dataArray == null || dataArray.Count == 0)
                    return "Lỗi lấy id";

                var idList = dataArray
                    .Take(3)
                    .Select(item => (string?)item?["id"])
                    .Where(id => !string.IsNullOrEmpty(id));

                string id = string.Join("|", idList);

                return string.IsNullOrEmpty(id) ? "Lỗi lấy id" : id;
            }
            catch
            {
                return "Lỗi lấy id";
            }

        }



        public async static Task<string> checkStatusUpDraftPe(string cookie, string token, string idTkqc, string? proxy = null)
        {
            string idDraft = await getAddraftId(cookie, token, idTkqc, proxy);

            var options = new RestClientOptions("https://graph.facebook.com")
            {
                MaxTimeout = -1,
            };

            ProxyHelper.SetProxy(options, proxy);

            var client = new RestClient(options);
            var request = new RestRequest("/v12.0/"+ idDraft + "/addraft_fragments?access_token=" + token, Method.Get);
            request.AddHeader("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
            request.AddHeader("accept-language", "en-US,en;q=0.9,vi;q=0.8");
            request.AddHeader("cache-control", "max-age=0");
            request.AddHeader("priority", "u=0, i");
            request.AddHeader("sec-ch-ua", "\"Chromium\";v=\"136\", \"Google Chrome\";v=\"136\", \"Not.A/Brand\";v=\"99\"");
            request.AddHeader("sec-ch-ua-mobile", "?0");
            request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
            request.AddHeader("sec-fetch-dest", "document");
            request.AddHeader("sec-fetch-mode", "navigate");
            request.AddHeader("sec-fetch-site", "none");
            request.AddHeader("sec-fetch-user", "?1");
            request.AddHeader("upgrade-insecure-requests", "1");
            request.AddHeader("Cookie", cookie);
            RestResponse response = await client.ExecuteAsync(request);

            string result = response.Content;

            JObject obj = JObject.Parse(result);


            string id = "";

            try
            {
                id = (string)obj["data"]?[0]?["id"];

            }
            catch
            {
                return "Đăng bản nháp thất bại";
            }

            if (id.Length > 0)
            {
                return "Đăng bản nháp thành công!";

            }

            return "Đăng bản nháp thất bại!";

        }


        public async static Task<string> DeleteAllDraftPe(string cookie, string token, string idTkqc, string? proxy = null)
        {
            string draft_id = await getAddraftId(cookie, token, idTkqc, proxy);


            var options = new RestClientOptions("https://adsmanager-graph.facebook.com")
            {
                MaxTimeout = -1,
            };

            ProxyHelper.SetProxy(options, proxy);   


            var client = new RestClient(options);
            var request = new RestRequest("/v21.0/"+draft_id+"/discard_fragments?_reqName=object%3Adraft_id%2Fdiscard_fragments&access_token=" + token, Method.Post);
            request.AddHeader("origin", "https://adsmanager.facebook.com");
            request.AddHeader("priority", "u=1, i");
            request.AddHeader("referer", "https://adsmanager.facebook.com/");
            request.AddHeader("sec-ch-ua-mobile", "?0");
            request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
            request.AddHeader("sec-fetch-dest", "empty");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-site", "same-site");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("__ad_account_id", idTkqc);
            request.AddParameter("_reqName", "object:draft_id/discard_fragments");
            request.AddParameter("_reqSrc", "AdsDraftDataManager");
            RestResponse response = await client.ExecuteAsync(request);

            string result = response.Content;

            if (result.Contains("success"))
            {
                return "Xóa bản nháp thành công!";
            }


            return "Xóa bản nháp thất bại!";

        }


        public async static Task<string> publicCampPeDraft(string cookie, string token, string idTkqc, string? proxy = null)
        {
            string draft_id = await getAddraftId(cookie, token, idTkqc, proxy);

            string idCampDraft = await getIdCampAdsDraft(cookie, token, idTkqc, proxy);

            string[] arr = idCampDraft.Split('|');


            var options = new RestClientOptions("https://adsmanager-graph.facebook.com")
            {
                MaxTimeout = -1,
            };

            if (proxy != null) {
                ProxyHelper.SetProxy(options, proxy);
            }

            var client = new RestClient(options);
            var request = new RestRequest("/v21.0/"+ draft_id + "/publish?_reqName=object%3Adraft_id%2Fpublish&access_token=" + token, Method.Post);
            request.AddHeader("accept", "*/*");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("origin", "https://adsmanager.facebook.com");
            request.AddHeader("priority", "u=1, i");
            request.AddHeader("referer", "https://adsmanager.facebook.com/");
            request.AddHeader("sec-ch-ua", "\"Chromium\";v=\"136\", \"Google Chrome\";v=\"136\", \"Not.A/Brand\";v=\"99\"");
            request.AddHeader("sec-ch-ua-mobile", "?0");
            request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
            request.AddHeader("sec-fetch-dest", "empty");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-site", "same-site");
            request.AddHeader("Cookie", cookie);
            request.AddParameter("__ad_account_id", draft_id);
            request.AddParameter("_reqName", "object:draft_id/publish");
            request.AddParameter("_reqSrc", "AdsDraftPublishDataManager");
            request.AddParameter("fragments", "[\"" + arr[2] + "\",\"" + arr[1] + "\",\"" + arr[0] +"\"]");
            request.AddParameter("ignore_errors", "true");
            request.AddParameter("include_fragment_statuses", "true");
            request.AddParameter("include_headers", "false");
            request.AddParameter("method", "post");
            RestResponse response = await client.ExecuteAsync(request);

            return response.Content ?? string.Empty;
        }
    }
}
