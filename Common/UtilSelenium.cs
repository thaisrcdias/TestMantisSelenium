using OpenQA.Selenium;
using System;

namespace TestMantisSelenium.Common
{
    public static class UtilSelenium
    {
        public static Func<IWebDriver, bool> ElementIsVisible(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    return element.Displayed;
                }
                catch (Exception)
                {
                    // If element is null, stale or if it cannot be located
                    return false;
                }
            };
        }

    }
}
