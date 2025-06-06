using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AutoCamp.Helper;

namespace AutoCamp.sele
{
    public class AddCreditChrome
    {
        public async static Task<string> AddCreditByChrome(string filePath, string idTkqc, string fullcredit, string? proxy = null)
        {
            try
            {
                var driver = await ChromeDriverHelper.CreateChromeDriver(filePath, proxy ?? "");

                if (!string.IsNullOrEmpty(proxy))
                {
                    driver.Navigate().GoToUrl("about:blank?proxy=" + proxy);
                    await Task.Delay(1500);
                    driver.Navigate().GoToUrl("https://api.myip.com/");
                    await Task.Delay(1000);
                }


                try
                {
                    driver.Navigate().GoToUrl("https://business.facebook.com/billing_hub/accounts/details/?asset_id=" + idTkqc);
                    Thread.Sleep(2000000);
                    
                    driver.Quit();
                }
                catch
                {
                    driver.Quit();
                    return "Lỗi";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "success";
        }
    }
}
