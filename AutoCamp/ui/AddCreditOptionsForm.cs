using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace AutoCamp.ui
{
    public partial class AddCreditOptionsForm : Form
    {
        private const string CREDIT_DATA_FILE = "credit_data.txt";

        private class CreditData
        {
            public string CreditDataText { get; set; } = string.Empty;
            public bool IsChangeInfo { get; set; }
            public string Country { get; set; } = string.Empty;
            public string Currency { get; set; } = string.Empty;
            public string TimeZone { get; set; } = string.Empty;
        }

        public AddCreditOptionsForm()
        {
            InitializeComponent();
            LoadCreditData();
        }

        private void LoadCreditData()
        {
            try
            {
                if (File.Exists(CREDIT_DATA_FILE))
                {
                    string jsonData = File.ReadAllText(CREDIT_DATA_FILE);
                    var creditData = JsonConvert.DeserializeObject<CreditData>(jsonData);
                    
                    if (creditData != null)
                    {
                        txtCreditData.Text = creditData.CreditDataText;
                        cbChangeInfo.Checked = creditData.IsChangeInfo;
                        if (!string.IsNullOrEmpty(creditData.Country))
                            cbbCountry.SelectedItem = creditData.Country;
                        if (!string.IsNullOrEmpty(creditData.Currency))
                            cbbCurrency.SelectedItem = creditData.Currency;
                        if (!string.IsNullOrEmpty(creditData.TimeZone))
                            cbbTimezone.SelectedItem = creditData.TimeZone;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnSaveCreditData_Click(object sender, EventArgs e)
        {
            try
            {
                var creditData = new CreditData
                {
                    CreditDataText = txtCreditData.Text,
                    IsChangeInfo = cbChangeInfo.Checked,
                    Country = cbbCountry.SelectedItem?.ToString() ?? string.Empty,
                    Currency = cbbCurrency.SelectedItem?.ToString() ?? string.Empty,
                    TimeZone = cbbTimezone.SelectedItem?.ToString() ?? string.Empty
                };

                string jsonData = JsonConvert.SerializeObject(creditData, Formatting.Indented);
                File.WriteAllText(CREDIT_DATA_FILE, jsonData);
                MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
