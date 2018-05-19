using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;


namespace BrowserEfficiencyTest
{
    class IsMuni : Scenario
    {

        public IsMuni()
        {
            this.Name = "IsMuni";
        }

        public override void Run(RemoteWebDriver driver, string browser, CredentialManager credentialManager, ResponsivenessTimer timer)
        {
            driver.NavigateToUrl("https://www.muni.cz/");
            driver.WaitForPageLoad();

            ICapabilities capabalities = ((RemoteWebDriver)driver).Capabilities;

            if (capabalities.BrowserName == "chrome")
            {
                driver.TypeIntoField(driver.FindElementByXPath("//*[@id='search']"), "Software quality" + Keys.Enter);
            }
            else
            {
                driver.TypeIntoField(driver.FindElementByXPath("//*[@id='search']"), "Software quality");
                driver.ClickElement(driver.FindElementByClassName("btn-icon icon icon-search"));
            }

            driver.WaitForPageLoad();
            driver.Wait(10);

            driver.ClickElement(driver.FindElementByXPath("//*[@id=\"___gcse_0\"]/div/div/div/div[5]/div[2]/div/div/div[1]/div[1]/div[1]/div/a"));
            driver.WaitForPageLoad();
        }
    }
}
