using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest;

public static class SeleniumCustomMethods
{
    public static void ClickElement(this IWebElement locator)
    {
        locator.Click();
    }

    public static void SubmitElement(this IWebElement locator)
    {
        locator.Submit();
    }

    public static void EnterText(this IWebElement locator, string text)
    {
        locator.Clear();
        locator.SendKeys(text);
    }

    public static void SelectDropDownByText(IWebElement locator, string text)
    {
        SelectElement selectElement = new SelectElement(locator);
        selectElement.SelectByText(text);
    }

    public static void SelectDropDownByValue(IWebElement locator, string value)
    {
        SelectElement selectElement = new SelectElement(locator);
        selectElement.SelectByText(value);
    }

    public static void MultiSelectDropDown(IWebElement locator, string[] value)
    {
        SelectElement selectElement = new SelectElement(locator);
        foreach (string item in value)
        {
            selectElement.SelectByText(item);
        }
    }

    public static List<string> GetAllSelectedLists(IWebElement locator)
    {
        List<string> options = new List<string>();
        SelectElement multiSelect = new SelectElement(locator);
        IList<IWebElement> selectedOption = multiSelect.AllSelectedOptions;
        foreach (IWebElement option in selectedOption)
        {
            options.Add(option.Text);
        }
        return options;
    }
}
