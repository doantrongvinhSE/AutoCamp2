using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCamp.models
{
    public class AccountInfoModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("account_status")]
        public int AccountStatus { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("adtrust_dsl")]
        public int AdtrustDsl { get; set; }

        [JsonProperty("balance")]
        public string Balance { get; set; }

        [JsonProperty("amount_spent")]
        public string AmountSpent { get; set; }

        [JsonProperty("created_time")]
        public string CreatedTime { get; set; }

        [JsonProperty("next_bill_date")]
        public string NextBillDate { get; set; }

        [JsonProperty("timezone_name")]
        public string TimezoneName { get; set; }

        public string CreditCardDisplayString { get; set; }
        public bool HasManageTask { get; set; }
    }
}
