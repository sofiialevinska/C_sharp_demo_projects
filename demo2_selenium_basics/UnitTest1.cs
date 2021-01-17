using System;
using System.IO;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace demo2_selenium_basics
{
    [TestFixture]
    public class SeleniumFirst
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [SetUp]
        public void SetUp ()
        {
            driver.Navigate().GoToUrl("https://prezi.com");
        }


        //[Test]
        public void Prezi_login_emptyCredo_Test()
        {
            IWebElement loginButtonMainPage = wait.Until(
                (d) => { return driver.FindElement(By.CssSelector(".login-page")); });
            loginButtonMainPage.Click();

            IWebElement loginButtonLoginPage = wait.Until(
                (d) => { return driver.FindElement(By.Id("btn_login")); });
            loginButtonLoginPage.Click();

            IWebElement alertMessageLoginPage = wait.Until(
                (d) => { return driver.FindElement(By.CssSelector(".alert.alert-danger")); });
            string actualMessage = alertMessageLoginPage.Text;

            string expectedMessage = "The e-mail or password you entered is incorrect";
            Assert.IsTrue(actualMessage.Contains(expectedMessage));
        }

        //[Test]
        public void Prezi_login_validData_Test()
        {
            string email;
            string password;
            try
            {
                string readPath = @"/Users/sofiiageletukha/Desktop/Coding/SETtest/hw/demo2/demo2/demo2_selenium_basics/secure_data.txt";

                using (StreamReader sr = new StreamReader(readPath, System.Text.Encoding.Default))
                {
                    email = sr.ReadLine();
                    password = sr.ReadLine();
                }
            }
            catch
            {
                throw new Exception("Error with reading data from file");
            }

            IWebElement loginButtonMainPage = wait.Until(
                (d) => { return driver.FindElement(By.CssSelector(".login-page")); });
            loginButtonMainPage.Click();


            IWebElement emailInput = wait.Until(
                (d) => { return driver.FindElement(By.Id("id_username")); });
            emailInput.Clear();
            emailInput.SendKeys(email);

            IWebElement passwordInput = wait.Until(
                (d) => { return driver.FindElement(By.Id("id_password")); });
            passwordInput.Clear();
            passwordInput.SendKeys(password);

            IWebElement loginButtonLoginPage = wait.Until(
                (d) => { return driver.FindElement(By.Id("btn_login")); });
            loginButtonLoginPage.Click();

            IWebElement successMessage = wait.Until(
                (d) => { return driver.FindElement(By.CssSelector(".TitleContainer-sc-1hxzs9i-0")); });
            string actualMessage = successMessage.Text;

            string expectedMessage = "let’s create something amazing today!";

            Assert.IsTrue(actualMessage.Contains(expectedMessage));
        }

        [Test]
        public void Prezi_createProject_Test()
        {
            string email;
            string password;
            try
            {
                string readPath = @"/Users/sofiiageletukha/Desktop/Coding/SETtest/hw/demo2/demo2/demo2_selenium_basics/secure_data.txt";

                using (StreamReader sr = new StreamReader(readPath, System.Text.Encoding.Default))
                {
                    email = sr.ReadLine();
                    password = sr.ReadLine();
                }
            }
            catch
            {
                throw new Exception("Error with reading data from file");
            }

            IWebElement loginButtonMainPage = wait.Until(
                (d) => { return driver.FindElement(By.CssSelector(".login-page")); });
            loginButtonMainPage.Click();


            IWebElement emailInput = wait.Until(
                (d) => { return driver.FindElement(By.Id("id_username")); });
            emailInput.Clear();
            emailInput.SendKeys(email);

            IWebElement passwordInput = wait.Until(
                (d) => { return driver.FindElement(By.Id("id_password")); });
            passwordInput.Clear();
            passwordInput.SendKeys(password);

            IWebElement loginButtonLoginPage = wait.Until(
                (d) => { return driver.FindElement(By.Id("btn_login")); });
            loginButtonLoginPage.Click();


        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }
    }
}
