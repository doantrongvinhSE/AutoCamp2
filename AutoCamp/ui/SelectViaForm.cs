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
using AutoCamp.Helper;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace AutoCamp.ui
{
    public partial class SelectViaForm : Form
    {
        private IWebDriver? driver;
        public ProfileData? SelectedProfileData { get; private set; }

        public SelectViaForm()
        {
            InitializeComponent();
        }

        private void btnLoadProfile_Click(object sender, EventArgs e)
        {
            string pathRoot = txtPathRoot.Text.Trim();

            if (string.IsNullOrEmpty(pathRoot))
            {
                MessageBox.Show("Vui lòng nhập đường dẫn profile!");
                return;
            }

            if (!Directory.Exists(pathRoot))
            {
                MessageBox.Show("Đường dẫn không tồn tại!");
                return;
            }

            try
            {
                // Clear existing items
                cbbProfile.Items.Clear();

                // Get all subdirectories (profiles) in the root path
                string[] profiles = Directory.GetDirectories(pathRoot);

                if (profiles.Length == 0)
                {
                    MessageBox.Show("Không tìm thấy profile nào!");
                    return;
                }

                // Add each profile to the ComboBox
                foreach (string profile in profiles)
                {
                    string profileName = Path.GetFileName(profile);
                    cbbProfile.Items.Add(profileName);
                }

                // Select the first profile if available
                if (cbbProfile.Items.Count > 0)
                {
                    cbbProfile.SelectedIndex = 0;
                }

                MessageBox.Show($"Đã tải {cbbProfile.Items.Count} profile!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải profile: {ex.Message}");
            }
        }

        // load profile, lấy cookie, token, link profile
        private async void btnLoadVia_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbProfile.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn profile!");
                    return;
                }

                string pathProfile = Path.Combine(txtPathRoot.Text.Trim(), cbbProfile.SelectedItem.ToString());

                string proxy = "";
                // Đọc proxy từ file proxyData.txt nếu tồn tại
                string proxyDataPath = Path.Combine(pathProfile, "proxyData.txt");
                if (File.Exists(proxyDataPath))
                {
                    proxy = File.ReadAllText(proxyDataPath).Trim();
                }

                if (!Directory.Exists(pathProfile))
                {
                    MessageBox.Show("Profile không tồn tại!");
                    return;
                }

                btnLoadVia.Enabled = false;
                btnLoadVia.Text = "Đang mở...";

                // Khởi tạo ChromeDriver với profile đã chọn
                driver = await ChromeDriverHelper.CreateChromeDriver(pathProfile, proxy);

                if (!string.IsNullOrEmpty(proxy))
                {
                    driver.Navigate().GoToUrl("about:blank?proxy=" + proxy);
                    await Task.Delay(1500);
                    driver.Navigate().GoToUrl("https://api.myip.com/");
                    await Task.Delay(1000);
                }

                driver.Navigate().GoToUrl("https://adsmanager.facebook.com/adsmanager/manage/campaigns");
                await Task.Delay(2000);



                // Lấy cookie và token từ profile
                var cookies = driver.Manage().Cookies.AllCookies;
                string cookieString = string.Join("; ", cookies.Select(c => $"{c.Name}={c.Value}"));

                // TODO: Lấy token từ localStorage hoặc cookie
                string resToken = driver.PageSource; // Implement token extraction logic here

                string token = "";

                if (!string.IsNullOrEmpty(resToken))
                {
                    string pattern = @"_accessToken=""(EAAB[a-zA-Z0-9]+)""";
                    Match match = Regex.Match(resToken, pattern);
                    if (match.Success)
                    {
                        token =  match.Groups[1].Value;
                    }
                }

                // Tạo đối tượng ProfileData
                var profileData = new ProfileData
                {
                    Cookie = cookieString,
                    PathProfile = pathProfile,
                    Token = token,
                    Proxy = proxy,
                    LastUpdated = DateTime.Now
                };

                // Lưu dữ liệu vào property để truyền về Form1
                SelectedProfileData = profileData;

                // Lưu đường dẫn profile vào file profile_path.txt
                string profilePathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "profile_path.txt");
                File.WriteAllText(profilePathFile, pathProfile);

                this.DialogResult = DialogResult.OK;
                this.Close();

                MessageBox.Show("Load via thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở profile: {ex.Message}");
            }
            finally
            {
                btnLoadVia.Enabled = true;
                btnLoadVia.Text = "Load Via";
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            
            // Đóng driver khi form đóng
            if (driver != null)
            {
                try
                {
                    driver.Quit();
                    driver.Dispose();
                }
                catch { }
            }
        }
    }
}
