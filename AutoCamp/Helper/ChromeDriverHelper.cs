using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading.Tasks;

namespace AutoCamp.Helper
{
    public static class ChromeDriverHelper
    {
        public static async Task<IWebDriver> CreateChromeDriver(string profilePath, string proxy = "")
        {
            try
            {
                var chromeDriverService = ChromeDriverService.CreateDefaultService();
                chromeDriverService.HideCommandPromptWindow = true;

                ChromeOptions options = new ChromeOptions();
                options.AddArguments("--disable-infobars");
                options.AddExcludedArgument("enable-automation");
                options.AddArguments(
                    "--disable-infobars",
                    "--disable-dev-shm-usage",
                    "--no-sandbox",
                    "--disable-popup-blocking",
                    "--disable-notifications",
                    "--window-size=920,920"
                );
                options.AddAdditionalOption("useAutomationExtension", false);

                // Thêm profile path
                options.AddArgument($"--user-data-dir={profilePath}");

                // Thêm proxy nếu có
                if (!string.IsNullOrEmpty(proxy))
                {
                    options.AddArgument($"--proxy-server={proxy}");
                }

                // Thêm extension nếu cần
                string extensionPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ext", "proxyAuth-1.1.0-chrome");
                if (Directory.Exists(extensionPath))
                {
                    options.AddArguments($"--load-extension={extensionPath}");
                    options.AddArgument("--disable-features=DisableLoadExtensionCommandLineSwitch");
                }

                return new ChromeDriver(chromeDriverService, options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi khởi tạo ChromeDriver: {ex.Message}");
            }
        }
    }
} 