using AutoCamp.domain;
using AutoCamp.Helper;
using AutoCamp.models;
using AutoCamp.sele;
using AutoCamp.ui;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using OpenQA.Selenium;

namespace AutoCamp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadFormData();
        }

        private void SaveFormData()
        {
            try
            {
                string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "form_config.txt");
                var configData = new
                {
                    Cookie = txtCookieVia.Text,
                    Token = txtToken.Text,
                    UseProxy = cbxProxy.Checked,
                    Proxy = txtProxyVia.Text
                };

                string jsonData = JsonConvert.SerializeObject(configData, Formatting.Indented);
                File.WriteAllText(configPath, jsonData);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu cấu hình: {ex.Message}");
            }
        }

        private void LoadFormData()
        {
            try
            {
                string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "form_config.txt");
                if (File.Exists(configPath))
                {
                    string jsonData = File.ReadAllText(configPath);
                    var configData = JsonConvert.DeserializeObject<dynamic>(jsonData);

                    txtCookieVia.Text = configData.Cookie?.ToString() ?? "";
                    txtToken.Text = configData.Token?.ToString() ?? "";
                    cbxProxy.Checked = configData.UseProxy?.ToObject<bool>() ?? false;
                    txtProxyVia.Text = configData.Proxy?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc cấu hình: {ex.Message}");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveFormData();
            // Đóng Chrome instance khi đóng form
            AddCreditChrome.CloseSharedDriver();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Form load event handler
        }

        private async void btnLoadInfoAdsUser_Click(object sender, EventArgs e)
        {

            try
            {
                btnLoadInfoAdsUser.Enabled = false;

                string? cookie = txtCookieVia.Text?.Trim();
                string? token = txtToken.Text?.Trim();

                if (string.IsNullOrEmpty(cookie) || string.IsNullOrEmpty(token))
                {
                    MessageBox.Show("Cookie, Token không được để trống");
                    return;
                }

                string proxy = "";

                if (cbxProxy.Checked)
                {
                    proxy = txtProxyVia.Text;
                }

                richTextBox1.Text = "Đang load tài khoản...";
                string result = await Task.Run(() => AdsDomain.getInfoTkqcUser(cookie, token, proxy));

                if (string.IsNullOrEmpty(result))
                {
                    richTextBox1.Text += "\nKhông nhận được dữ liệu từ server";
                    return;
                }

                JObject json = JObject.Parse(result);
                if (json["adaccounts"] == null)
                {
                    richTextBox1.Text += "\nDữ liệu tài khoản quảng cáo không tồn tại";
                    return;
                }

                var dataArray = json["adaccounts"].ToString();
                List<AdAccountModel> adAccountModels = JsonConvert.DeserializeObject<List<AdAccountModel>>(dataArray);

                if (adAccountModels == null || adAccountModels.Count == 0)
                {
                    richTextBox1.Text += "\nKhông có tài khoản quảng cáo nào";
                    return;
                }


                foreach (var account in adAccountModels)
                {
                    int rowIndex = adsAccountTable.Rows.Add();
                    DataGridViewRow row = adsAccountTable.Rows[rowIndex];

                    string status;
                    switch (account.AccountStatus)
                    {
                        case 1:
                            status = "Live";
                            break;
                        case 2:
                            status = "Die";
                            break;
                        case 3:
                            status = "Cần thanh toán";
                            break;
                        default:
                            status = "Không xác định";
                            break;
                    }

                    //row.Cells[0].Value = "1"; // Đánh dấu là được chọn
                    row.Cells["stt"].Value = rowIndex + 1;
                    row.Cells["nameTkqc"].Value = account.Name;
                    row.Cells["status"].Value = status;
                    row.Cells["country"].Value = account.TaxCountry;
                    row.Cells["currency"].Value = account.Currency;
                    row.Cells["timezone"].Value = account.TimezoneName;
                    row.Cells["id"].Value = account.AccountId;
                    row.Cells["dateCreated"].Value = account.CreatedTime;
                    row.Cells["budget"].Value = account.Balance;
                    row.Cells["threshold"].Value = account.Adspaymentcycle?.Data?[0]?.ThresholdAmount.ToString();
                    row.Cells["credit"].Value = account.FundingSourceDetails?.DisplayString;
                    row.Cells["isPrepay"].Value = account.IsPrepayAccount;
                    row.Cells["bill"].Value = account.NextBillDate;
                    row.Cells["limit"].Value = (account.AdtrustDsl > 1) ? account.AdtrustDsl.ToString() : "nolimit";
                }
                richTextBox1.Text += "\nLoad thành công!";

            }
            catch (JsonException ex)
            {
                richTextBox1.Text += "\nLỗi xử lý JSON!";
            }
            catch (Exception ex)
            {
                richTextBox1.Text += $"\nĐã xảy ra lỗi: {ex.Message}";
            }
            finally
            {
                btnLoadInfoAdsUser.Enabled = true;

            }

        }

        private async void btnManagerBm_Click(object sender, EventArgs e)
        {
            try
            {
                btnManagerBm.Enabled = false;
                cbbIdBm.Items.Clear();
                cbbIdBm.Text = "Nhấp nút để chọn Bm";

                string? cookie = txtCookieVia.Text?.Trim();
                string proxy = "";

                if (string.IsNullOrEmpty(cookie))
                {
                    MessageBox.Show("Cookie không được để trống");
                    return;
                }

                if (cbxProxy.Checked)
                {
                    proxy = txtProxyVia.Text;
                }

                richTextBox1.Text = "Đang load bm...";
                string result = await Task.Run(() => BmDomain.geiIdsBm(cookie, proxy));

                if (string.IsNullOrEmpty(result))
                {
                    richTextBox1.Text += "\nKhông nhận được dữ liệu từ server";
                    return;
                }

                JObject json = JObject.Parse(result);
                if (json["businesses"] == null || json["businesses"]["data"] == null)
                {
                    richTextBox1.Text += "\nKhông có BM nào!";
                    return;
                }

                var dataArray = json["businesses"]["data"].ToString();
                List<IdBmModel> IdBmModels = JsonConvert.DeserializeObject<List<IdBmModel>>(dataArray);

                if (IdBmModels == null || IdBmModels.Count == 0)
                {
                    richTextBox1.Text += "\nKhông có BM nào!";
                    return;
                }

                foreach (var bm in IdBmModels)
                {
                    cbbIdBm.Items.Add(bm.Id + " - " + bm.NameBm);
                }


                richTextBox1.Text += "\nLoad thành công!";

            }
            catch
            {
                richTextBox1.Text += "\nLỗi";
            }
            finally
            {
                btnManagerBm.Enabled = true;
            }

        }

        // done
        private async void btnLoadTKByBM_Click(object sender, EventArgs e)
        {
            if (cbxLoadAccountGroup.Checked)
            {
                try
                {
                    btnLoadTKByBM.Enabled = false;
                    string? cookie = txtCookieVia.Text?.Trim();
                    string? token = txtToken.Text?.Trim();
                    string idGroup = cbbGroup.SelectedItem.ToString() ?? string.Empty;
                    string proxy = "";

                    string resultIdGroup = idGroup.Split(" - ")[0];

                    if (string.IsNullOrEmpty(cookie))
                    {
                        MessageBox.Show("Cookie không được để trống");
                        return;
                    }

                    if (cbxProxy.Checked)
                    {
                        proxy = txtProxyVia.Text;
                    }

                    richTextBox1.Text = "Đang load tài khoản...";
                    string result = await Task.Run(() => BmDomain.getAdsAccountByGroup(cookie, token, resultIdGroup, proxy));

                    if (string.IsNullOrEmpty(result))
                    {
                        richTextBox1.Text += "\nKhông nhận được dữ liệu từ server";
                        return;
                    }

                    JObject json = JObject.Parse(result);
                    if (json["contained_adaccounts"] == null || json["contained_adaccounts"]["data"] == null)
                    {
                        richTextBox1.Text += "\nDữ liệu tài khoản quảng cáo không tồn tại";
                        return;
                    }

                    var dataArray = json["contained_adaccounts"]["data"].ToString();
                    List<AdAccountModel> adAccountModels = JsonConvert.DeserializeObject<List<AdAccountModel>>(dataArray);

                    if (adAccountModels == null || adAccountModels.Count == 0)
                    {
                        richTextBox1.Text += "\nKhông có tài khoản quảng cáo nào";
                        return;
                    }


                    foreach (var account in adAccountModels)
                    {
                        int rowIndex = adsAccountTable.Rows.Add();
                        DataGridViewRow row = adsAccountTable.Rows[rowIndex];

                        string status;
                        switch (account.AccountStatus)
                        {
                            case 1:
                                status = "Live";
                                break;
                            case 2:
                                status = "Die";
                                break;
                            case 3:
                                status = "Cần thanh toán";
                                break;
                            default:
                                status = "Không xác định";
                                break;
                        }

                        //row.Cells[0].Value = "1"; // Đánh dấu là được chọn
                        row.Cells["stt"].Value = rowIndex + 1;
                        row.Cells["nameTkqc"].Value = account.Name;
                        row.Cells["status"].Value = status;
                        row.Cells["country"].Value = account.TaxCountry;
                        row.Cells["currency"].Value = account.Currency;
                        row.Cells["timezone"].Value = account.TimezoneName;
                        row.Cells["id"].Value = account.AccountId;
                        row.Cells["dateCreated"].Value = account.CreatedTime;
                        row.Cells["budget"].Value = account.Balance;
                        row.Cells["isPrepay"].Value = account.IsPrepayAccount;
                        row.Cells["threshold"].Value = account.Adspaymentcycle?.Data?[0]?.ThresholdAmount.ToString();
                        row.Cells["credit"].Value = account.FundingSourceDetails?.DisplayString;
                        row.Cells["bill"].Value = account.NextBillDate;
                        row.Cells["limit"].Value = (account.AdtrustDsl > 1) ? account.AdtrustDsl.ToString() : "nolimit";
                    }


                    richTextBox1.Text += "\nLoad thành công!";

                }
                catch (JsonException ex)
                {
                    richTextBox1.Text += "\nLỗi xử lý JSON!";

                }
                catch (Exception ex)
                {
                    richTextBox1.Text += $"\nĐã xảy ra lỗi: {ex.Message}";
                }
                finally
                {
                    btnLoadTKByBM.Enabled = true;
                }
            }
            else
            {
                try
                {
                    btnLoadTKByBM.Enabled = false;
                    string? cookie = txtCookieVia.Text?.Trim();
                    string? token = txtToken.Text?.Trim();
                    string idBm = cbbIdBm.SelectedItem.ToString() ?? string.Empty;

                    if (idBm.Length == 0)
                    {
                        MessageBox.Show("Chưa có id bm");
                        return;
                    }

                    string proxy = "";

                    string resultIdBM = idBm.Split(" - ")[0];

                    if (string.IsNullOrEmpty(cookie) || string.IsNullOrEmpty(token))
                    {
                        MessageBox.Show("Cookie, Token không được để trống");
                        return;
                    }

                    if (cbxProxy.Checked)
                    {
                        proxy = txtProxyVia.Text;
                    }

                    richTextBox1.Text = "Đang load tài khoản...";
                    string result = await Task.Run(() => AdsDomain.getInfoTkqcByBm(cookie, token, resultIdBM, proxy));

                    if (string.IsNullOrEmpty(result))
                    {
                        richTextBox1.Text += "\nKhông nhận được dữ liệu từ server";
                        return;
                    }

                    JObject json = JObject.Parse(result);
                    if (json["client_ad_accounts"] == null)
                    {
                        richTextBox1.Text += "\nDữ liệu tài khoản quảng cáo không tồn tại";
                        return;
                    }

                    var dataArray = json["client_ad_accounts"].ToString();
                    List<AdAccountModel> adAccountModels = JsonConvert.DeserializeObject<List<AdAccountModel>>(dataArray);

                    if (adAccountModels == null || adAccountModels.Count == 0)
                    {
                        richTextBox1.Text += "\nKhông có tài khoản quảng cáo nào";
                        return;
                    }


                    foreach (var account in adAccountModels)
                    {
                        int rowIndex = adsAccountTable.Rows.Add();
                        DataGridViewRow row = adsAccountTable.Rows[rowIndex];

                        string status;
                        switch (account.AccountStatus)
                        {
                            case 1:
                                status = "Live";
                                break;
                            case 2:
                                status = "Die";
                                break;
                            case 3:
                                status = "Cần thanh toán";
                                break;
                            default:
                                status = "Không xác định";
                                break;
                        }

                        //row.Cells[0].Value = "1"; // Đánh dấu là được chọn
                        row.Cells["stt"].Value = rowIndex + 1;
                        row.Cells["nameTkqc"].Value = account.Name;
                        row.Cells["status"].Value = status;
                        row.Cells["country"].Value = account.TaxCountry;
                        row.Cells["currency"].Value = account.Currency;
                        row.Cells["timezone"].Value = account.TimezoneName;
                        row.Cells["id"].Value = account.AccountId;
                        row.Cells["dateCreated"].Value = account.CreatedTime;
                        row.Cells["budget"].Value = account.Balance;
                        row.Cells["threshold"].Value = account.Adspaymentcycle?.Data?[0]?.ThresholdAmount.ToString();
                        row.Cells["credit"].Value = account.FundingSourceDetails?.DisplayString;
                        row.Cells["isPrepay"].Value = account.IsPrepayAccount;
                        row.Cells["bill"].Value = account.NextBillDate;
                        row.Cells["limit"].Value = (account.AdtrustDsl > 1) ? account.AdtrustDsl.ToString() : "nolimit";
                    }


                    richTextBox1.Text += "\nLoad thành công!";

                }
                catch (JsonException ex)
                {
                    richTextBox1.Text += "\nLỗi xử lý JSON!";

                }
                catch (Exception ex)
                {
                    richTextBox1.Text += $"\nĐã xảy ra lỗi: {ex.Message}";
                }
                finally
                {
                    btnLoadTKByBM.Enabled = true;
                }
            }



        }

        private async void btnGetAllGroup_Click(object sender, EventArgs e)
        {
            try
            {
                cbbGroup.Items.Clear();
                cbbGroup.Text = "Nhấn nút để chọn Group";

                btnGetAllGroup.Enabled = false;
                string? cookie = txtCookieVia.Text?.Trim();
                string idBm = "";
                string proxy = "";

                if (cbbIdBm.Items.Count > 0)
                {
                    idBm = cbbIdBm.SelectedItem.ToString() ?? string.Empty;
                }

                string resultIdBM = idBm.Split(" - ")[0];

                if (string.IsNullOrEmpty(cookie))
                {
                    MessageBox.Show("Cookie không được để trống");
                    return;
                }

                if (cbxProxy.Checked)
                {
                    proxy = txtProxyVia.Text;
                }

                richTextBox1.Text += "\nĐang load group...";

                string result = await Task.Run(() => BmDomain.getGroupBm(cookie, resultIdBM, proxy));


                if (string.IsNullOrEmpty(result))
                {
                    richTextBox1.Text += "\nKhông nhận được dữ liệu từ server";
                    return;
                }

                JObject json = JObject.Parse(result);
                if (json["data"] == null)
                {
                    richTextBox1.Text += "\nKhông có dữ liệu, group nào";
                    return;
                }

                var dataArray = json["data"].ToString();
                List<GroupModel> groupModels = JsonConvert.DeserializeObject<List<GroupModel>>(dataArray);

                if (groupModels == null || groupModels.Count == 0)
                {
                    richTextBox1.Text += "\nKhông có Group nào";
                    return;
                }

                foreach (var group in groupModels)
                {
                    cbbGroup.Items.Add(group.Id + " - " + group.Name);
                }


                richTextBox1.Text += "\nLoad group thành công!";


            }
            catch (JsonException ex)
            {
                richTextBox1.Text += $"\nLỗi xử lý JSON: {ex.Message}";
            }
            catch (Exception ex)
            {
                richTextBox1.Text += $"\nĐã xảy ra lỗi: {ex.Message}";

            }
            finally
            {
                btnGetAllGroup.Enabled = true;
            }
        }

        private void btnSelectedAllData_Click(object sender, EventArgs e)
        {
            DataGridViewHelper.CheckAll(adsAccountTable, "cbxTable", true);
        }

        private void btnUnselectedAll_Click(object sender, EventArgs e)
        {
            DataGridViewHelper.CheckAll(adsAccountTable, "cbxTable", false);
        }

        private void btnSelectedBlackData_Click(object sender, EventArgs e)
        {
            DataGridViewHelper.CheckSelected(adsAccountTable, "cbxTable", true);
        }

        private void btnUnselectedBlackData_Click(object sender, EventArgs e)
        {
            DataGridViewHelper.CheckSelected(adsAccountTable, "cbxTable", false);
        }

        private void btnClearAllData_Click(object sender, EventArgs e)
        {
            adsAccountTable.Rows.Clear();
        }

        private void btnClearSelectedData_Click(object sender, EventArgs e)
        {
            DataGridViewHelper.RemoveSelectedRows(adsAccountTable);

        }


        // done
        private async void btnCheckCredit_Click(object sender, EventArgs e)
        {
            string proxy = "";

            if (cbxProxy.Checked)
            {
                proxy = txtProxyVia.Text;
            }

            richTextBox1.Text += "\nĐang check thẻ...";

            string cookie = txtCookieVia.Text ?? string.Empty;

            string fb_dtsg = await Task.Run(() => TokenCookieDomain.getFbDtsg(cookie, proxy));

            //string token = await Task.Run(() => TokenCookieDomain.getTokenEAABs(cookie, proxy));


            List<Task> tasks = new List<Task>();

            foreach (DataGridViewRow row in adsAccountTable.Rows)
            {
                if ((bool)row.Cells["cbxTable"].FormattedValue)
                {
                    // Copy row để dùng trong Task tránh closure issues
                    var currentRow = row;

                    var task = Task.Run(async () =>
                    {
                        try
                        {
                            string idTkqc = currentRow.Cells["id"].Value.ToString();
                            currentRow.Cells["credit"].Value = "Đang check thẻ...";

                            Thread.Sleep(new Random().Next(3000, 5000)); // Thêm delay ngẫu nhiên nhẹ

                            string result = await Task.Run(() => AdsDomain.checkCredit3(cookie, fb_dtsg, idTkqc, proxy));



                            // Cập nhật UI phải gọi từ thread chính
                            adsAccountTable.Invoke((MethodInvoker)delegate
                            {
                                currentRow.Cells["credit"].Value = result;
                            });
                        }
                        catch (Exception ex)
                        {
                            adsAccountTable.Invoke((MethodInvoker)delegate
                            {
                                currentRow.Cells["credit"].Value = "Lỗi: " + ex.Message;
                            });
                        }
                    });

                    tasks.Add(task);
                }
            }

            await Task.WhenAll(tasks);

            richTextBox1.Text += "\nCheck thẻ xong!";

        }

        private void txtSearchIdTkqc_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearchIdTkqc.Text.Trim();

            // Bỏ chọn tất cả các hàng đã chọn trước đó
            adsAccountTable.ClearSelection();

            if (string.IsNullOrEmpty(searchValue))
                return;

            // Duyệt qua từng hàng trong DataGridView
            foreach (DataGridViewRow row in adsAccountTable.Rows)
            {
                // Kiểm tra nếu ô trong cột "id" chứa giá trị cần tìm
                if (row.Cells["id"].Value != null &&
                    row.Cells["id"].Value.ToString().Contains(searchValue))
                {
                    // Chọn hàng tìm thấy và cuộn đến vị trí đó
                    row.Selected = true;
                    adsAccountTable.FirstDisplayedScrollingRowIndex = row.Index;
                    break; // Dừng lại sau khi tìm thấy kết quả đầu tiên
                           // Nếu muốn tìm tất cả các kết quả khớp, hãy xóa break này
                }
            }
        }

        private async void btnCheckXMSDT_Click(object sender, EventArgs e)
        {
            string proxy = "";
            richTextBox1.Text += "\nĐang kiểm tra XMSDT...";

            try
            {
                string cookie = txtCookieVia.Text;

                if (cookie.Length < 1)
                {
                    MessageBox.Show("Vui lòng điền cookie!");
                    return;
                }

                if (cbxProxy.Checked)
                {
                    proxy = txtProxyVia.Text;
                }

                string result = await Task.Run(() => AdsDomain.checkXMSDT(cookie, proxy));

                richTextBox1.Text += "\nĐã kiểm tra xong...";

                MessageBox.Show(result);

            }
            catch
            {

            }

        }

        private async void btnCheckTKLT_Click(object sender, EventArgs e)
        {

            string proxy = "";

            if (cbxProxy.Checked)
            {
                proxy = txtProxyVia.Text;
            }

            richTextBox1.Text += "\nĐang check TKLT...";

            string cookie = txtCookieVia.Text ?? string.Empty;

            if (cookie.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập cookie!");
                return;
            }

            string fb_dtsg = await Task.Run(() => TokenCookieDomain.getFbDtsg(cookie, proxy));

            //string token = await Task.Run(() => TokenCookieDomain.getTokenEAABs(cookie, proxy));


            List<Task> tasks = new List<Task>();

            foreach (DataGridViewRow row in adsAccountTable.Rows)
            {
                if ((bool)row.Cells["cbxTable"].FormattedValue)
                {
                    // Copy row để dùng trong Task tránh closure issues
                    var currentRow = row;

                    var task = Task.Run(async () =>
                    {
                        try
                        {
                            string idTkqc = currentRow.Cells["id"].Value.ToString();
                            currentRow.Cells["isPrepay"].Value = "Đang check TKLT...";

                            Thread.Sleep(new Random().Next(3000, 5000)); // Thêm delay ngẫu nhiên nhẹ

                            string result = await Task.Run(() => AdsDomain.checkTKLT(cookie, idTkqc, fb_dtsg, proxy));



                            // Cập nhật UI phải gọi từ thread chính
                            adsAccountTable.Invoke((MethodInvoker)delegate
                            {
                                currentRow.Cells["isPrepay"].Value = result;
                            });
                        }
                        catch (Exception ex)
                        {
                            adsAccountTable.Invoke((MethodInvoker)delegate
                            {
                                currentRow.Cells["isPrepay"].Value = "Lỗi: " + ex.Message;
                            });
                        }
                    });

                    tasks.Add(task);
                }
            }

            await Task.WhenAll(tasks);

            richTextBox1.Text += "\nCheck TKLT xong!";
        }

        private async void btnCampPe_Click(object sender, EventArgs e)
        {
            CampPE campPE = new CampPE();
            string textTarget = "";
            string cookie = txtCookieVia.Text;
            string proxy = "";
            string token = txtToken.Text;



            if (campPE.ShowDialog() == DialogResult.OK)
            {
                textTarget = campPE.target;
                if (string.IsNullOrEmpty(textTarget))
                {
                    MessageBox.Show("Vui lòng nhập target!");
                    return;
                }
            }

            if (cookie.Length == 0 || token.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập cookie, token!");
                return;
            }

            if (cbxProxy.Checked)
            {
                proxy = txtProxyVia.Text;
                if (string.IsNullOrEmpty(proxy))
                {
                    MessageBox.Show("Vui lòng nhập proxy!");
                    return;
                }
            }

            string fb_dtsg = await Task.Run(() => TokenCookieDomain.getFbDtsg(cookie, proxy));

            List<Task> tasks = new List<Task>();

            foreach (DataGridViewRow row in adsAccountTable.Rows)
            {
                if ((bool)row.Cells["cbxTable"].FormattedValue)
                {
                    // Copy row để dùng trong Task tránh closure issues
                    var currentRow = row;

                    var task = Task.Run(async () =>
                    {
                        try
                        {
                            string idTkqc = currentRow.Cells["id"].Value.ToString();

                            // Cập nhật UI phải gọi từ thread chính
                            adsAccountTable.Invoke((MethodInvoker)delegate
                            {
                                currentRow.Cells["process"].Value = "Đang đăng bản nháp...";
                            });

                            string result = await Task.Run(() => CampPEDomain.uploadDraftCamp(cookie, token, fb_dtsg, idTkqc, textTarget, proxy));

                            // Cập nhật UI phải gọi từ thread chính
                            adsAccountTable.Invoke((MethodInvoker)delegate
                            {
                                currentRow.Cells["process"].Value = result;
                            });
                        }
                        catch (Exception ex)
                        {
                            // Xử lý lỗi và cập nhật UI
                            adsAccountTable.Invoke((MethodInvoker)delegate
                            {
                                currentRow.Cells["process"].Value = "Lỗi: " + ex.Message;
                            });
                        }
                    });

                    tasks.Add(task);
                }
            }

            // Đợi tất cả các task hoàn thành
            await Task.WhenAll(tasks);
        }

        private async void btnDeleteCredit_Click(object sender, EventArgs e)
        {

        }

        private async void btnClearAllDraft_Click(object sender, EventArgs e)
        {
            string cookie = txtCookieVia.Text;
            string proxy = "";
            string token = txtToken.Text;


            if (cookie.Length == 0 || token.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập cookie, token!");
                return;
            }

            if (cbxProxy.Checked)
            {
                proxy = txtProxyVia.Text;
                if (string.IsNullOrEmpty(proxy))
                {
                    MessageBox.Show("Vui lòng nhập proxy!");
                    return;
                }
            }

            List<Task> tasks = new List<Task>();

            foreach (DataGridViewRow row in adsAccountTable.Rows)
            {
                if ((bool)row.Cells["cbxTable"].FormattedValue)
                {
                    // Copy row để dùng trong Task tránh closure issues
                    var currentRow = row;

                    var task = Task.Run(async () =>
                    {
                        try
                        {
                            string idTkqc = currentRow.Cells["id"].Value.ToString();

                            // Cập nhật UI phải gọi từ thread chính
                            adsAccountTable.Invoke((MethodInvoker)delegate
                            {
                                currentRow.Cells["process"].Value = "Đang xoá bản nháp...";
                            });

                            string result = await Task.Run(() => CampPEDomain.DeleteAllDraftPe(cookie, token, idTkqc, proxy));

                            // Cập nhật UI phải gọi từ thread chính
                            adsAccountTable.Invoke((MethodInvoker)delegate
                            {
                                currentRow.Cells["process"].Value = result;
                            });
                        }
                        catch (Exception ex)
                        {
                            // Xử lý lỗi và cập nhật UI
                            adsAccountTable.Invoke((MethodInvoker)delegate
                            {
                                currentRow.Cells["process"].Value = "Lỗi: " + ex.Message;
                            });
                        }
                    });

                    tasks.Add(task);
                }
            }

            // Đợi tất cả các task hoàn thành
            await Task.WhenAll(tasks);
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            string token = "EAABsbCS1iHgBOZCseF18xV6xo3QlbpGGJx5HggxpGa2fPzUDsRdvoelU62MU42RUFWQ1meRzygznuPD1tRBv3jZBNyZAuEfqi4XxHZBLTCsjLX9ZCZBcqEJ0FD9ZCnnBjbD1cexSZAEfryMUJLWpYeHZAdcb536ZBZAVL3rvUTbRbxA8bSP7Hgn0xPLSNycCyKHa33oMR9vFTMLYmEVQQZDZD";
            string cookie = "datr=SlEraNMUX6kctjyD47NwJAjz;sb=SlEraEF1ZBNQ9W6Qbu_7e7wQ;ps_l=1;ps_n=1;dpr=1.5;locale=en_US;c_user=100000566470040;cppo=1;wd=1707x932;b_user=61577073351295;presence=C%7B%22t3%22%3A%5B%5D%2C%22utc3%22%3A1748700779946%2C%22v%22%3A1%7D;fr=1wLcIz2MQHsqfyVg2.AWdmD4__BfeyzdXLiWwyVnhGLROtM-FrueOdl-QstSaaqXNjS4Q.BoOxCz..AAA.0.0.BoOxCz.AWcF4zSO7FFDyfD8jOZ22o9pfwk;xs=47%3AJDDQ1axDi91WJg%3A2%3A1748625207%3A-1%3A-1%3AC6rzUIv3_232Ig%3AAcXKpct4hDxYyaqISal7jQT6yhs16_bbRmKdSMGQMdI;alsfid={\"id\":\"fb13a3295\",\"timestamp\":1748705059380.8};";
            string idTkqc = "948225016638568";

            string result = await CampPEDomain.publicCampPeDraft(cookie, token, idTkqc);

            MessageBox.Show(result);
        }

        private void btnCampBpOptions_Click(object sender, EventArgs e)
        {
            CampBPOptionsForm campBPOptionsForm = new CampBPOptionsForm();
            campBPOptionsForm.ShowDialog();

        }

        private void btnViaConfig_Click(object sender, EventArgs e)
        {
            ViaForm viaForm = new ViaForm();
            viaForm.ShowDialog();
        }

        private void btnAddCreditOptions_Click(object sender, EventArgs e)
        {
            AddCreditOptionsForm addCreditOptionsForm = new AddCreditOptionsForm();
            addCreditOptionsForm.ShowDialog();
        }

        private async void btnAddCredit_Click(object sender, EventArgs e)
        {
            try
            {
                btnAddCredit.Enabled = false;
                richTextBox1.Text += "\nBắt đầu quá trình thêm thẻ...";

                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "credit_data.txt");
                if (!File.Exists(jsonPath))
                {
                    MessageBox.Show("Không tìm thấy file credit_data.txt");
                    return;
                }

                string jsonContent = await File.ReadAllTextAsync(jsonPath);
                CreditDataModel creditData = JsonConvert.DeserializeObject<CreditDataModel>(jsonContent);

                if (creditData == null)
                {
                    MessageBox.Show("Không thể đọc dữ liệu từ file credit_data.txt");
                    return;
                }

                // Lấy danh sách các tài khoản được chọn
                var selectedAccounts = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in adsAccountTable.Rows)
                {
                    if (row.Cells["cbxTable"].Value != null && (bool)row.Cells["cbxTable"].Value)
                    {
                        selectedAccounts.Add(row);
                        row.Cells["process"].Value = "Đang chờ...";
                    }
                }

                if (selectedAccounts.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một tài khoản!");
                    return;
                }

                richTextBox1.Text += $"\nTìm thấy {selectedAccounts.Count} tài khoản được chọn";

                string cookie = txtCookieVia.Text.Trim();
                string proxy = "";
                string filePath = "";
                string profilePathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "profile_path.txt");
                string fullCredit = creditData.CreditDataText.Trim();
                string fbdtsg = await TokenCookieDomain.getFbDtsg(cookie, proxy);

                if (File.Exists(profilePathFile))
                {
                    filePath = File.ReadAllText(profilePathFile).Trim();
                }

                if (cbxProxy.Checked)
                {
                    proxy = txtProxyVia.Text;
                }

                // Xử lý tuần tự từng tài khoản
                foreach (var row in selectedAccounts)
                {
                    try
                    {
                        string idTkqc = row.Cells["id"].Value?.ToString() ?? string.Empty;
                        if (string.IsNullOrEmpty(idTkqc))
                        {
                            row.Cells["process"].Value = "Không tìm thấy ID tài khoản";
                            continue;
                        }

                        // change info 
                        if (creditData.IsChangeInfo)
                        {
                            row.Cells["process"].Value = "Đang thay đổi thông tin...";

                            // Prepare data
                            string country = creditData.Country;
                            string subCountry = country.Substring(0, 2);

                            string currency = creditData.Currency;
                            int startIndexCurrency = currency.IndexOf("(") + 1;
                            int endIndexCurrency = currency.IndexOf(")");
                            string subCurrency = currency.Substring(startIndexCurrency, endIndexCurrency - startIndexCurrency);

                            string timezone = creditData.TimeZone;
                            int startIndexTimezone = timezone.IndexOf("{") + 1;
                            int endIndexTimezone = timezone.IndexOf("}");
                            string subTimezone = timezone.Substring(startIndexTimezone, endIndexTimezone - startIndexTimezone);

                            await AdsDomain.changeInfoTkqcAsync(row, cookie, fbdtsg, idTkqc, subCurrency, subTimezone, subCountry, proxy);

                            if (row.Cells["process"].Value != "Change thành công!")
                            {
                                row.Cells["process"].Value = "Change thất bại -> Dừng!";
                                continue;
                            }
                        }
                    
                        row.Cells["process"].Value = "Đang thêm thẻ...";

                        // Chạy tác vụ thêm thẻ với timeout để tránh treo form
                        var addCreditTask = AddCreditChrome.AddCreditByChrome(filePath, idTkqc, fullCredit, proxy);

                        // Đợi tác vụ hoàn thành hoặc hết thời gian (ví dụ: 90 giây)
                        var completedTask = await Task.WhenAny(addCreditTask, Task.Delay(TimeSpan.FromSeconds(90)));

                        if (completedTask == addCreditTask)
                        {
                            // Tác vụ hoàn thành trong thời gian cho phép
                            row.Cells["process"].Value = await addCreditTask;
                        }
                        else
                        {
                            // Tác vụ không hoàn thành (quá thời gian chờ)
                            row.Cells["process"].Value = "Lỗi: Quá trình thêm thẻ mất quá nhiều thời gian.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Kiểm tra xem có phải lỗi do trình duyệt bị đóng không
                        if (ex is OpenQA.Selenium.WebDriverException || ex.InnerException is OpenQA.Selenium.WebDriverException)
                        {
                            row.Cells["process"].Value = "Lỗi: Trình duyệt đã bị đóng hoặc không phản hồi.";
                        }
                        else
                        {
                            row.Cells["process"].Value = $"Lỗi: {ex.Message}";
                        }
                    }
                }

                richTextBox1.Text += "\nHoàn thành quá trình thêm thẻ!";
                
                // Đóng Chrome sau khi hoàn thành
                AddCreditChrome.CloseSharedDriver();
                richTextBox1.Text += "\nĐã đóng Chrome!";
            }
            catch (Exception ex)
            {
                richTextBox1.Text += $"\nLỗi: {ex.Message}";
                MessageBox.Show($"Lỗi khi xử lý: {ex.Message}");
            }
            finally
            {
                btnAddCredit.Enabled = true;
            }
        }

        private void btnCloseChrome_Click(object sender, EventArgs e)
        {
            try
            {
                AddCreditChrome.CloseSharedDriver();
                richTextBox1.Text += "\nĐã đóng Chrome!";
            }
            catch (Exception ex)
            {
                richTextBox1.Text += $"\nLỗi khi đóng Chrome: {ex.Message}";
            }
        }

        private async Task UpdateUIAsync(Action action)
        {
            if (adsAccountTable.InvokeRequired)
            {
                await Task.Run(() => adsAccountTable.Invoke(action));
            }
            else
            {
                action();
            }
        }


        // chọn via để load
        private void btnSelectVia_Click(object sender, EventArgs e)
        {
            SelectViaForm selectViaForm = new SelectViaForm();
            if (selectViaForm.ShowDialog() == DialogResult.OK && selectViaForm.SelectedProfileData != null)
            {
                txtCookieVia.Text = selectViaForm.SelectedProfileData.Cookie;
                txtToken.Text = selectViaForm.SelectedProfileData.Token;
                txtProxyVia.Text = selectViaForm.SelectedProfileData.Proxy;
                cbxProxy.Checked = true;
            }
        }

        private void btnOpenBill_Click(object sender, EventArgs e)
        {

        }

        private async void btnLoadAgain_Click(object sender, EventArgs e)
        {
            try
            {
                btnLoadAgain.Enabled = false;
                string cookie = txtCookieVia.Text;
                string token = txtToken.Text;
                string proxy = "";

                if (cookie.Length == 0 || token.Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập cookie, token!");
                    return;
                }

                if (cbxProxy.Checked)
                {
                    proxy = txtProxyVia.Text;
                }

                List<Task> tasks = new List<Task>();

                foreach (DataGridViewRow row in adsAccountTable.Rows)
                {
                    if ((bool)row.Cells["cbxTable"].FormattedValue)
                    {
                        // Copy row để dùng trong Task tránh closure issues
                        var currentRow = row;

                        var task = Task.Run(async () =>
                        {
                            try
                            {
                                string idTkqc = currentRow.Cells["id"].Value.ToString();
                                
                                // Cập nhật UI phải gọi từ thread chính
                                await UpdateUIAsync(() => currentRow.Cells["process"].Value = "Đang load lại...");

                                // Thêm delay ngẫu nhiên để tránh quá tải
                                await Task.Delay(new Random().Next(1000, 3000));

                                string result = await AdsDomain.checkAgainTk(cookie, token, idTkqc, proxy);
                                JObject json = JObject.Parse(result);

                                if (json == null)
                                {
                                    await UpdateUIAsync(() => currentRow.Cells["process"].Value = "Lỗi load lại...");
                                    return;
                                }

                                try
                                {
                                    // Xử lý an toàn các trường có thể không tồn tại
                                    string account_status = json["account_status"]?.ToString() ?? "0";
                                    string status = account_status switch
                                    {
                                        "1" => "Live",
                                        "2" => "Die",
                                        _ => "Không xác định"
                                    };

                                    // Lấy thông tin pixel an toàn
                                    string pixelId = json["adspixels"]?["data"]?[0]?["id"]?.ToString() ?? "";
                                    string pixelName = json["adspixels"]?["data"]?[0]?["name"]?.ToString() ?? "";
                                    string pixelValue = !string.IsNullOrEmpty(pixelId) && !string.IsNullOrEmpty(pixelName) 
                                        ? $"{pixelId}|{pixelName}" 
                                        : "";

                                    // Lấy thông tin funding source an toàn
                                    string fundingSource = json["funding_source_details"]?["display_string"]?.ToString() ?? "";

                                    // Lấy thông tin ads an toàn
                                    string pagePost = json["ads"]?["data"]?[0]?["creative"]?["effective_object_story_id"]?.ToString() ?? "";

                                    // Lấy thông tin adsets an toàn
                                    string startTime = json["adsets"]?["data"]?[0]?["start_time"]?.ToString() ?? "";


                                    string thresholdAmount = json["adspaymentcycle"]?["data"]?[0]?["threshold_amount"]?.ToString() ?? "";



                                    // Cập nhật UI với dữ liệu mới
                                    await UpdateUIAsync(() =>
                                    {
                                        currentRow.Cells["status"].Value = status;
                                        currentRow.Cells["country"].Value = json["business_country_code"]?.ToString() ?? "";
                                        currentRow.Cells["currency"].Value = json["currency"]?.ToString() ?? "";
                                        currentRow.Cells["timezone"].Value = json["timezone_name"]?.ToString() ?? "";
                                        currentRow.Cells["pixel"].Value = pixelValue;
                                        currentRow.Cells["credit"].Value = fundingSource;
                                        currentRow.Cells["pagePost"].Value = pagePost;
                                        currentRow.Cells["startTime"].Value = startTime;
                                        currentRow.Cells["threshold"].Value = thresholdAmount;
                                        currentRow.Cells["process"].Value = "Hoàn thành";

                                    });
                                }
                                catch (Exception ex)
                                {

                                }
                            }
                            catch (Exception ex)
                            {
                                await UpdateUIAsync(() => currentRow.Cells["process"].Value = $"Lỗi: {ex.Message}");
                            }
                        });

                        tasks.Add(task);
                    }
                }

                // Đợi tất cả các task hoàn thành
                await Task.WhenAll(tasks);
                richTextBox1.Text += "\nĐã hoàn thành load lại tất cả tài khoản!";
            }
            catch (Exception ex)
            {
                richTextBox1.Text += $"\nLỗi: {ex.Message}";
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
            finally
            {
                btnLoadAgain.Enabled = true;
            }
        }
    }
}
