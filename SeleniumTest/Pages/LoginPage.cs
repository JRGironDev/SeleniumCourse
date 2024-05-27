using OpenQA.Selenium;

namespace SeleniumTest;

public class LoginPage
{
    private readonly IWebDriver driver;
    
    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    IWebElement LoginLink => driver.FindElement(By.Id("loginLink"));

    IWebElement TxtUserName => driver.FindElement(By.Name("UserName"));

    IWebElement TxtPassword => driver.FindElement(By.Id("Password"));

    IWebElement BtnLogin => driver.FindElement(By.CssSelector("input[value='Log in']"));

    IWebElement LinkEmployeeDetails => driver.FindElement(By.LinkText("Employee Details"));

    IWebElement LinkManageUsers => driver.FindElement(By.LinkText("Manage Users"));

    IWebElement LinkLogOff => driver.FindElement(By.LinkText("Log off"));

    public void ClickLoginLink()
    {
        LoginLink.ClickElement();
    }

    public void Login(string userName, string password)
    {
        TxtUserName.EnterText(userName);
        TxtPassword.EnterText(password);
        BtnLogin.Submit();  
    }

    public bool IsLoggedIn()
    {
        return LinkEmployeeDetails.Displayed;
    }
}
