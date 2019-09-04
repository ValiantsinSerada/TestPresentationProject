using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestProject
{
    public static class WebDriverExtensions
    {
        public static void WaitUntilVisible(this IWebDriver driver, By element)
        {
            new WebDriverWait(driver, new TimeSpan(0, 0, 0, 10)).Until(ExpectedConditions.ElementIsVisible(element));
        }

        public static IList<T> ExtractTableData<T>(this IWebDriver driver)
            where T : new()
        {
            var attr = typeof(T).GetCustomAttribute<FindAttribute>();
            if (attr == null)
            {
                throw new ArgumentException($"Generic parameter <T> ({typeof(T).FullName}) should be attributed by {typeof(FindAttribute).FullName}");
            }

            var rowElements = driver.FindElements(attr.By);
            return rowElements.Select(ConvertToRowData<T>).ToList();
        }

        private static T ConvertToRowData<T>(IWebElement rowElement)
            where T : new()
        {
            T result = new T();

            foreach (var property in result.GetType().GetProperties())
            {
                var attrs = property.GetCustomAttributes<FindAttribute>();
                foreach (var attr in attrs)
                {
                    var cellElement = rowElement.FindElements(attr.By).FirstOrDefault();
                    if (cellElement != null)
                    {
                        switch (attr.Extract)
                        {
                            case ExtractOperator.Text:
                                property.SetValue(result, cellElement.Text);
                                break;
                            case ExtractOperator.Attribute:
                                var value = cellElement.GetAttribute(attr.Attribute);
                                property.SetValue(result, value);
                                break;
                        }
                    }
                }
            }

            return result;
        }
    }
}
