using System;
using System.IO;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
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

            wait.Until((d) => {
                return driver.FindElement(By.CssSelector(".login-page")); }).Click();

            IWebElement emailInput = wait.Until(
                (d) => { return driver.FindElement(By.Id("id_username")); });
            emailInput.Clear();
            emailInput.SendKeys(email);

            IWebElement passwordInput = wait.Until(
                (d) => { return driver.FindElement(By.Id("id_password")); });
            passwordInput.Clear();
            passwordInput.SendKeys(password);

            wait.Until((d) => {
                return driver.FindElement(By.Id("btn_login"));
            }).Click();

            IWebElement nameButtonHeader = wait.Until(
                (d) => { return driver.FindElement(By.CssSelector(".user-avatar")); });
            nameButtonHeader.Click();

            IWebElement editAccountButtonHeader = wait.Until(
                (d) => { return driver.FindElement(By.PartialLinkText("Account settings")); });
            editAccountButtonHeader.Click();

            driver.SwitchTo().Window(driver.WindowHandles.LastOrDefault());

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            IWebElement editProfileButtonEditPage = wait.Until(
                (d) => { return driver.FindElement(By.CssSelector(".link[href='/settings/profile/']")); });
            js.ExecuteScript("arguments[0].click();", editProfileButtonEditPage);

            string newLastName = "Lv-553.SET1";
            string lastName = "Levinska";

            IWebElement lastNameInput = wait.Until(
                (d) => { return driver.FindElement(By.Id("last_name")); });
            js.ExecuteScript("arguments[0].value = ' ';", lastNameInput);
            js.ExecuteScript("arguments[0].value = '" + newLastName + "';", lastNameInput);

            IWebElement profileSaveButton = wait.Until(
               (d) => { return driver.FindElement(By.Id("profile_save")); });
            js.ExecuteScript("arguments[0].click();", profileSaveButton);
            profileSaveButton.Click();

            IWebElement nameButtonHeaderProfilePage = wait.Until(
                (d) => { return driver.FindElement(By.CssSelector(".name")); });
            js.ExecuteScript("arguments[0].click();", nameButtonHeaderProfilePage);

            IWebElement editAccountButtonHeaderProfilePage = wait.Until(
                (d) => { return driver.FindElement(By.PartialLinkText("Account Settings")); });
            js.ExecuteScript("arguments[0].click();", editAccountButtonHeaderProfilePage);

            string[] actualFullName = driver.FindElement(
                By.CssSelector(".name")).Text.Split(" ");

            Console.WriteLine("actualLastName = " + actualFullName [1]);
            Assert.AreEqual(newLastName, actualFullName [1]);

            //set previous last name
            editProfileButtonEditPage = wait.Until(
                (d) => { return driver.FindElement(By.CssSelector(".link[href='/settings/profile/']")); });
            js.ExecuteScript("arguments[0].click();", editProfileButtonEditPage);

            lastNameInput = wait.Until(
                (d) => { return driver.FindElement(By.Id("last_name")); });
            js.ExecuteScript("arguments[0].value = ' ';", lastNameInput);
            js.ExecuteScript("arguments[0].value = '" + lastName + "';", lastNameInput);

            profileSaveButton = wait.Until(
               (d) => { return driver.FindElement(By.Id("profile_save")); });
            js.ExecuteScript("arguments[0].click();", profileSaveButton);

            nameButtonHeaderProfilePage = wait.Until(
                (d) => { return driver.FindElement(By.CssSelector(".name")); });
            js.ExecuteScript("arguments[0].click();", nameButtonHeaderProfilePage);

            editAccountButtonHeaderProfilePage = wait.Until(
                (d) => { return driver.FindElement(By.PartialLinkText("Account Settings")); });
            js.ExecuteScript("arguments[0].click();", editAccountButtonHeaderProfilePage);

            string [] actualFullNameNew = driver.FindElement(
                By.CssSelector(".name")).Text.Split(" ");
            Assert.AreEqual(lastName, actualFullNameNew[1]);
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }
    }
}
