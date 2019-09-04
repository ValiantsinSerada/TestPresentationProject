using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestProject
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = true)]
    public class FindAttribute : Attribute
    {
        public How How { get; set; }

        public string Selector { get; set; }

        public ExtractOperator Extract { get; set; }

        public string Attribute { get; set; }

        public By By
        {
            get
            {
                switch (How)
                {
                    case How.XPath:
                        return By.XPath(Selector);
                    case How.Id:
                        return By.Id(Selector);
                    case How.Name:
                        return By.Name(Selector);
                    case How.TagName:
                        return By.TagName(Selector);
                    case How.ClassName:
                        return By.ClassName(Selector);
                    case How.CssSelector:
                        return By.CssSelector(Selector);
                    case How.LinkText:
                        return By.LinkText(Selector);
                    case How.PartialLinkText:
                        return By.PartialLinkText(Selector);
                    case How.Custom:
                        break;
                }

                throw new InvalidOperationException($"Unknown method {How}");
            }
        }
    }
}
