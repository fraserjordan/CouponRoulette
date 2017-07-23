using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Business.Tests
{
    public class SimpleCouponsBusinessTests
    {
        public static readonly string siteUrl = "https://simplecouponsbusiness.co.nz/";

        [Test]
        public void NavigateToRegisterPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl(siteUrl);

                IWebElement registerButton = driver.FindElement(By.Id("RegisterLink"));
                registerButton.Click();

                Assert.AreEqual("Register - Simple Coupons", driver.Title);
                Assert.AreEqual(siteUrl + "Account/Register", driver.Url);
            }
        }

        [Test]
        public void SubmitRegisterForm()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl(siteUrl);

                IWebElement registerButton = driver.FindElement(By.Id("RegisterLink"));
                registerButton.Click();

                IWebElement emailInput = driver.FindElement(By.Name("Email"));
                emailInput.SendKeys("fraser.jord@gmail.com");

                IWebElement passwordInput = driver.FindElement(By.Name("Password"));
                passwordInput.SendKeys("P@ssw0rd");

                IWebElement confirmPasswordInput = driver.FindElement(By.Name("ConfirmPassword"));
                confirmPasswordInput.SendKeys("P@ssw0rd");

                IWebElement businessAddressInput = driver.FindElement(By.Id("BusinessAddress"));
                businessAddressInput.SendKeys("burger");

                IWebElement submitButton = driver.FindElement(By.ClassName("ManageActionButton"));
                Assert.AreEqual(true, submitButton.Enabled);
            }
        }
    }
}
