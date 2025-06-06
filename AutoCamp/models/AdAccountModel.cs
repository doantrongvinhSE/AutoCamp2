using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AutoCamp.models
{
    public class AdAccountModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("account_status")]
        public int AccountStatus { get; set; }

        [JsonProperty("tax_country")]
        public string TaxCountry { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("timezone_name")]
        public string TimezoneName { get; set; }

        [JsonProperty("is_prepay_account")]
        public bool IsPrepayAccount { get; set; }


        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("balance")]
        public string Balance { get; set; }

        [JsonProperty("next_bill_date")]
        public DateTime NextBillDate { get; set; }

        [JsonProperty("adtrust_dsl")]
        public double AdtrustDsl { get; set; }

        [JsonProperty("user_tasks")]
        public List<string> UserTasks { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

    }
}
