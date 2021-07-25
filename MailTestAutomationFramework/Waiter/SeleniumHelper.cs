using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Linq;
using System.Reflection;

namespace Waiter
{
    public static class SeleniumHelper
    {
        public static By GetByXpath(Type page, string webElementFieldName)
        {
            FieldInfo fieldInfo = page.GetField(webElementFieldName);

            FindsByAttribute attribute = (FindsByAttribute)fieldInfo
                .GetCustomAttributes(typeof(FindsByAttribute), false)
                .FirstOrDefault();

            return By.XPath(attribute.Using);
        }
    }
}
