using System.Text.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTest;

public class DataDrivenTest
{
    private IWebDriver _driver;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl("http://eaapp.somee.com/");

        ReadJsonFile();
    }

    [TearDown]
    public void DisposeDriver()
    {
        _driver.Dispose();
    }

    [Test]
    [Category("ddt")]
    [TestCaseSource(nameof(Login))]
    public void EAWebSitePageObjectTest(LoginModel loginModel)
    {
        //Arrange
        LoginPage loginPage = new LoginPage(_driver);

        //Act
        loginPage.ClickLoginLink();

        if (loginModel != null && loginModel.UserName != null && loginModel.Password != null)
        {
            loginPage.Login(loginModel.UserName, loginModel.Password);
        }

        //Assert
        bool IsLoggedIn = loginPage.IsLoggedIn();
        Assert.That(IsLoggedIn, Is.True);

        
    }

    public static IEnumerable<LoginModel> Login()
    {
        yield return new LoginModel()
        {
            UserName = "admin",
            Password = "password1"
        };
    }

    public static IEnumerable<LoginModel> LoginJsonDataSource()
    {
        string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "/Users/josequinonez/C#/Selenium/SeleniumTest/login.json");
        string? jsonString = File.ReadAllText(jsonFilePath);
        LoginModel? loginModel = JsonSerializer.Deserialize<LoginModel>(jsonString);

        if (loginModel != null)
        {
            yield return loginModel;
        }
    }

    private static void ReadJsonFile()
    {
        string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "/Users/josequinonez/C#/Selenium/SeleniumTest/login.json");
        string? jsonString = File.ReadAllText(jsonFilePath);
        LoginModel? loginModel = JsonSerializer.Deserialize<LoginModel>(jsonString);

        Console.WriteLine("UserName: " + loginModel?.UserName + " Password: " + loginModel?.Password);
    }

    [Test]
    [Category("ddt")]
    public void TestWithPOMWithJsondata()
    {
        string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "/Users/josequinonez/C#/Selenium/SeleniumTest/login.json");
        string? jsonString = File.ReadAllText(jsonFilePath);
        LoginModel? loginModel = JsonSerializer.Deserialize<LoginModel>(jsonString);
        LoginPage loginPage = new LoginPage(_driver);
        loginPage.ClickLoginLink();
        if (loginModel != null && loginModel.UserName != null && loginModel.Password != null)
        {
            loginPage.Login(loginModel.UserName, loginModel.Password);
        }
    }
}
