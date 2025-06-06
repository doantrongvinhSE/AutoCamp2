using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using AutoCamp.models;
using AutoCamp.Helper;

namespace AutoCamp.ui
{
    public partial class ViaForm : Form
    {
        public ViaForm()
        {
            InitializeComponent();
            LoadViaData(); // Load dữ liệu khi form được khởi tạo
        }


        // btn load data
        private void btnLoadDataVia_Click(object sender, EventArgs e)
        {
            string textData = txtViaData.Text;
            if (string.IsNullOrWhiteSpace(textData))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu vào ô văn bản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] arr = textData.Split("|");

            lbUidVia.Text = arr[0];
            txtPasswordVia.Text = arr[1];

            if (arr[2].Length == 32)
            {
                lb2Fa.Text = arr[2];
            }

            foreach (string item in arr)
            {
                if (item.Contains("c_user"))
                {
                    txtCookie.Text = item;
                    break;
                }
            }

        }

        private async void btnLoginVia_Click(object sender, EventArgs e)
        {
            try
            {
                btnLoginVia.Enabled = false;
                string proxy = "";
                string uid = lbUidVia.Text.Trim() ?? string.Empty;
                string cookie = txtCookie.Text.Trim() ?? string.Empty;
                string txtPathRoot = txtPathFileRoot.Text.Trim() ?? string.Empty;

                if (string.IsNullOrEmpty(txtPathRoot))
                {
                    MessageBox.Show("Vui lòng nhập đường dẫn profile!");
                    return;
                }

                if (string.IsNullOrEmpty(uid))
                {
                    MessageBox.Show("Vui lòng nhập UID!");
                    return;
                }

                // Kiểm tra xem profile đã tồn tại chưa
                string profilePath = Path.Combine(txtPathRoot, uid);
                if (Directory.Exists(profilePath))
                {
                    var result = MessageBox.Show(
                        $"Profile với UID {uid} đã tồn tại. Bạn có muốn ghi đè không?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.No)
                    {
                        return;
                    }

                    // Xóa thư mục cũ nếu người dùng chọn ghi đè
                    try
                    {
                        Directory.Delete(profilePath, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Không thể xóa profile cũ: {ex.Message}");
                        return;
                    }
                }

                // Tạo profile Chrome mới trong thư mục con với tên là uid
                string createResult = await ChromeProfileHelper.CreateChromeProfile(txtPathRoot, uid);
                if (!createResult.Contains("thành công"))
                {
                    MessageBox.Show(createResult);
                    return;
                }

                // Lưu proxy vào file proxyData.txt nếu có proxy
                if (cbxProxy.Checked && !string.IsNullOrEmpty(txtProxy.Text))
                {
                    string proxyDataPath = Path.Combine(txtPathRoot, uid, "proxyData.txt");
                    File.WriteAllText(proxyDataPath, txtProxy.Text);
                }

                if (cbxProxy.Checked)
                {
                    proxy = txtProxy.Text;
                }

                // Khởi tạo ChromeDriver với profile
                using (var driver = await ChromeDriverHelper.CreateChromeDriver(profilePath, proxy))
                {
                    try
                    {
                        // Kiểm tra proxy nếu có
                        if (!string.IsNullOrEmpty(proxy))
                        {
                            driver.Navigate().GoToUrl("about:blank?proxy=" + proxy);
                            await Task.Delay(1500);
                            driver.Navigate().GoToUrl("https://api.myip.com/");
                            await Task.Delay(1000);
                        }

                        // Truy cập Facebook
                        driver.Navigate().GoToUrl("https://www.facebook.com/");
                        await Task.Delay(2500);

                        // Xóa cookies cũ
                        driver.Manage().Cookies.DeleteAllCookies();

                        // Thêm cookies mới
                        if (!string.IsNullOrEmpty(cookie))
                        {
                            string[] cookieParts = cookie.Split(';');
                            foreach (var part in cookieParts)
                            {
                                var trimmed = part.Trim();
                                if (string.IsNullOrEmpty(trimmed)) continue;

                                var keyValue = trimmed.Split('=', 2);
                                if (keyValue.Length != 2) continue;

                                string name = keyValue[0];
                                string value = keyValue[1];

                                driver.Manage().Cookies.AddCookie(new OpenQA.Selenium.Cookie(name, value, ".facebook.com", "/", DateTime.Now.AddDays(1)));
                            }

                            // Refresh trang sau khi thêm cookies
                            driver.Navigate().GoToUrl("https://www.facebook.com/");
                            await Task.Delay(2500);
                        }

                        MessageBox.Show("Hoàn thành!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi thao tác với Chrome: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
            finally
            {
                btnLoginVia.Enabled = true;
            }
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = txtPathFileRoot.Text.Trim() ?? string.Empty;
                string cookie = txtCookie.Text.Trim() ?? string.Empty;
                string proxy = txtProxy.Text.Trim() ?? string.Empty;
                string uid = lbUidVia.Text.Trim() ?? string.Empty;
                string password = txtPasswordVia.Text.Trim() ?? string.Empty;
                string token = lb2Fa.Text.Trim() ?? string.Empty;
                bool isProxy = cbxProxy.Checked;

                var viaData = new ViaDataModel
                {
                    FilePath = filePath,
                    Cookie = cookie,
                    Proxy = proxy,
                    Uid = uid,
                    Password = password,
                    Token = token,
                    IsProxy = isProxy
                };

                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "via_data.txt");
                string jsonContent = JsonConvert.SerializeObject(viaData, Formatting.Indented);
                File.WriteAllText(jsonPath, jsonContent);

                MessageBox.Show("Lưu dữ liệu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu dữ liệu: {ex.Message}");
            }
        }

        private void LoadViaData()
        {
            try
            {
                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "via_data.txt");
                if (!File.Exists(jsonPath))
                {
                    return;
                }

                string jsonContent = File.ReadAllText(jsonPath);
                var viaData = JsonConvert.DeserializeObject<ViaDataModel>(jsonContent);

                if (viaData != null)
                {
                    txtPathFileRoot.Text = viaData.FilePath;
                    txtCookie.Text = viaData.Cookie;
                    txtProxy.Text = viaData.Proxy;
                    lbUidVia.Text = viaData.Uid;
                    txtPasswordVia.Text = viaData.Password;
                    lb2Fa.Text = viaData.Token;
                    cbxProxy.Checked = viaData.IsProxy;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc dữ liệu: {ex.Message}");
            }
        }
    }
}
