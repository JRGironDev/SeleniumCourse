using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTest;

[TestFixture("admin", "password")]
public class NUnitTestDemo
{
    private IWebDriver _driver;
    private readonly string _userName;
    private readonly string _password;

    public NUnitTestDemo(string userName, string password)
    {
        _userName = userName;
        _password = password;
    }

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl("http://eaapp.somee.com/");
    }

    [TearDown]
    public void DisposeDriver()
    {
        _driver.Dispose();
    }

    [Test]
    [Category("SmokeTest")]
    public void EAWebSitePageObjectTest()
    {
        LoginPage loginPage = new LoginPage(_driver);
        loginPage.ClickLoginLink();
        loginPage.Login(_userName, _password);
    }

    [Test]
    [TestCase("chrome", "30")]
    public void TestBrowserVersion(string browser, string version)
    {
        Console.WriteLine("Browser: " + browser + " Version: " + version);
    }
}
