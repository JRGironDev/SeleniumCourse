using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        //Sudo code for setting up Selenium
        //1. Create a new instance of Selenium WebDriver
        IWebDriver driver = new ChromeDriver();
        //2. Navigate to the URL
        driver.Navigate().GoToUrl("https://www.google.com");
        //2a. Maximize the browser window
        driver.Manage().Window.Maximize();
        //3. Find the element
        IWebElement element = driver.FindElement(By.Name("q"));
        //4. Type in the element
        element.SendKeys("Selenium");
        //5. Click on the element
        element.SendKeys(Keys.Return);
    }

    [Test]
    public void EAWebSiteTest()
    {
        //1. Create a new instance of Selenium WebDriver
        IWebDriver driver = new ChromeDriver();
        //2. Navigate to the URL
        driver.Navigate().GoToUrl("http://eaapp.somee.com/");
        //3. Click the Login link
        IWebElement loginLink = driver.FindElement(By.Id("loginLink"));
        //4. Click the Login link
        loginLink.Click();
        //5. Find the username textbox
        IWebElement username = driver.FindElement(By.Name("UserName"));
        //6. Type in the username
        username.SendKeys("admin");
        //7. Find the password textbox
        IWebElement password = driver.FindElement(By.Id("Password"));
        //8. Type in the password
        password.SendKeys("password");
        //9. Identify the login button
        IWebElement loginButton = driver.FindElement(By.CssSelector("input[value='Log in']"));
        //10. Click the login button
        loginButton.Submit();
    }

    [Test]
    public void WorkingWithAdvancedControls()
    {
        //1. Create a new instance of Selenium WebDriver
        IWebDriver driver = new ChromeDriver();
        //2. Navigate to the URL
        driver.Navigate().GoToUrl("https://www.guateseguro.com/");
        //3. Find the button "Adquirir seguro"
        IWebElement adquirirSeguroButton = driver.FindElement(By.CssSelector("button[class='bg-seguro-accent px-5 py-4 rounded-lg self-center text-base text-white text-center font-bold drop-shadow-md hover:bg-pink-600 active:bg-pink-800 focus:outline-none focus:ring focus:ring-pink-500 disabled:hover:bg-seguro-accent disabled:opacity-75 md:self-start']"));
        //4. Click the button "Adquirir seguro"
        adquirirSeguroButton.Click();

        SeleniumCustomMethods.ClickElement(driver.FindElement(By.CssSelector("button[class='bg-seguro-accent px-5 py-4 rounded-lg self-center text-base text-white text-center font-bold drop-shadow-md hover:bg-pink-600 active:bg-pink-800 focus:outline-none focus:ring focus:ring-pink-500 disabled:hover:bg-seguro-accent disabled:opacity-75 md:self-start']")));

        SelectElement select = new SelectElement(driver.FindElement(By.Id("tipoDocumento")));
    }

    [Test]
    public void EAWebSiteShortTest()
    {
        //1. Create a new instance of Selenium WebDriver
        IWebDriver driver = new ChromeDriver();
        //2. Navigate to the URL
        driver.Navigate().GoToUrl("http://eaapp.somee.com/");
        //3. Click the Login link
        SeleniumCustomMethods.ClickElement(driver.FindElement(By.Id("loginLink")));
        //4. Type in the username
        SeleniumCustomMethods.EnterText(driver.FindElement(By.Name("UserName")), "admin");
        //5. Type in the password
        SeleniumCustomMethods.EnterText(driver.FindElement(By.Id("Password")), "password");
        //6. Identify the login button
        IWebElement loginButton = driver.FindElement(By.CssSelector("input[value='Log in']"));
        //7. Click the login button
        loginButton.Submit();
    }

    [Test]
    public void EAWebSitePageObjectTest()
    {
        //1. Create a new instance of Selenium WebDriver
        IWebDriver driver = new ChromeDriver();
        //2. Navigate to the URL
        driver.Navigate().GoToUrl("http://eaapp.somee.com/");
        //3. Create an instance of the LoginPage
        LoginPage loginPage = new LoginPage(driver);
        //4. Click the Login link
        loginPage.ClickLoginLink();
        //5. Type in the username
        loginPage.Login("admin", "password");
    }
}