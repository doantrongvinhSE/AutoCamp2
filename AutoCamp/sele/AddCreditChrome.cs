using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AutoCamp.Helper;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;

namespace AutoCamp.sele
{
    public class AddCreditChrome
    {
        private const int DEFAULT_TIMEOUT_SECONDS = 60;
        private const int NAVIGATION_DELAY_MS = 1500;
        private const int FORM_LOAD_DELAY_MS = 2000;
        private const int SAVE_DELAY_MS = 25000;
        private const string DEFAULT_NAME = "WOLF SA";

        public async static Task<string> AddCreditByChrome(string filePath, string idTkqc, string fullcredit, string? proxy = null)
        {
            IWebDriver? driver = null;
            try
            {
                driver = await ChromeDriverHelper.CreateChromeDriver(filePath, proxy ?? "");
                var (cardNumber, expiration, securityCode) = ParseCreditInfo(fullcredit);

                if (!string.IsNullOrEmpty(proxy))
                {
                    await HandleProxySetup(driver, proxy);
                }

                return await ProcessCreditCardAddition(driver, idTkqc, cardNumber, expiration, securityCode);
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
            finally
            {
                driver?.Quit();
            }
        }

        private static (string cardNumber, string expiration, string securityCode) ParseCreditInfo(string fullcredit)
        {
            var parts = fullcredit.Split('|');
            if (parts.Length < 4)
                throw new ArgumentException("Invalid credit card format");

            return (
                cardNumber: parts[0],
                expiration: parts[1] + parts[2],
                securityCode: parts[3]
            );
        }

        private static async Task HandleProxySetup(IWebDriver driver, string proxy)
        {
            driver.Navigate().GoToUrl($"about:blank?proxy={proxy}");
            await Task.Delay(NAVIGATION_DELAY_MS);
            driver.Navigate().GoToUrl("https://api.myip.com/");
            await Task.Delay(NAVIGATION_DELAY_MS);
        }

        private static async Task<string> ProcessCreditCardAddition(IWebDriver driver, string idTkqc, string cardNumber, string expiration, string securityCode)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(DEFAULT_TIMEOUT_SECONDS));
            
            try
            {
                driver.Navigate().GoToUrl($"https://business.facebook.com/billing_hub/payment_settings/?placement=ads_manager&asset_id={idTkqc}");

                Thread.Sleep(2000);

                // xoá phần tử verify
                try {
                    var verifyElement = driver.FindElement(By.XPath("/html/body/span/div"));

                    // Replace the problematic line with the following:
                    driver.ExecuteJavaScript("arguments[0].remove();", verifyElement);
                } catch (Exception ex) {
                    Console.WriteLine("Không tìm thấy phần tử verify");
                }                


                if (driver.Url.Contains("loginpage"))
                {
                    return "Checkpoint";
                }
                
                var addButton = await WaitForElement(wait, By.XPath("//*[text()='Add payment method']"));
                if (addButton == null)
                    throw new Exception("Could not find 'Add payment method' button");

                addButton.Click();
                await Task.Delay(FORM_LOAD_DELAY_MS);

                var nextButton = await WaitForElement(wait, By.XPath("//*[text()='Next']"));
                if (nextButton == null)
                    throw new Exception("Could not find 'Next' button");

                nextButton.Click();
                
                var nameElement = await WaitForElement(wait, By.Name("firstName"));
                if (nameElement == null)
                    throw new Exception("Could not find name input field");

                await FillCreditCardForm(driver, nameElement, cardNumber, expiration, securityCode);
                await Task.Delay(SAVE_DELAY_MS);


                // check need
                try
                {
                    var needVerifyElement = driver.FindElement(By.XPath("//*[text()='Verify card']"));
                    if (needVerifyElement != null)
                    {
                        return "Add need verify";
                    }
                }
                catch
                {
                }

                // check thành công hay không 
                driver.Navigate().Refresh();
                Thread.Sleep(5000);

                // xoá phần tử verify
                try
                {
                    var verifyElement2 = driver.FindElement(By.XPath("/html/body/span/div"));

                    // Replace the problematic line with the following:
                    driver.ExecuteJavaScript("arguments[0].remove();", verifyElement2);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Không tìm thấy phần tử verify");
                }


                var addButtonCheck = await WaitForElement(wait, By.XPath("//*[text()='Add payment method']"));
                if (addButtonCheck == null)
                    throw new Exception("Could not find name input field");



                try
                {
                    var creditCardElement = driver.FindElement(By.XPath($"//*[text()='Visa · {cardNumber.Split("|")[0].Substring(cardNumber.Split("|")[0].Length - 4)}']"));
                    if (creditCardElement != null) return "Thêm thẻ thành công";
                } catch (Exception ex) {
                    return "Thêm thẻ thất bại";
                }


                return "Thêm thẻ thành công";
            }
            catch (Exception ex)
            {
                return $"Error during credit card addition: {ex.Message}";
            }
        }

        private static async Task FillCreditCardForm(IWebDriver driver, IWebElement nameElement, string cardNumber, string expiration, string securityCode)
        {
            // Helper function to type with random delays
            async Task TypeWithRandomDelay(IWebElement element, string text)
            {
                foreach (char c in text)
                {
                    element.SendKeys(c.ToString());
                    await Task.Delay(new Random().Next(50, 150)); // Random delay between 50-150ms
                }
            }

            await TypeWithRandomDelay(nameElement, DEFAULT_NAME);
            await TypeWithRandomDelay(driver.FindElement(By.Name("cardNumber")), cardNumber);
            await TypeWithRandomDelay(driver.FindElement(By.Name("expiration")), expiration);
            await TypeWithRandomDelay(driver.FindElement(By.Name("securityCode")), securityCode);
            
            var saveButton = driver.FindElement(By.XPath("//*[text()='Save']"));
            saveButton.Click();
        }

        private static async Task<IWebElement?> WaitForElement(WebDriverWait wait, By by)
        {
            try
            {
                return wait.Until(driver =>
                {
                    try
                    {
                        var element = driver.FindElement(by);
                        return element.Displayed && element.Enabled ? element : null;
                    }
                    catch
                    {
                        return null;
                    }
                });
            }
            catch
            {
                return null;
            }
        }
    }
}
