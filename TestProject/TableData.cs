using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [Find(How = How.XPath, Selector = "//div[@class = 'div-table-row']")]
    public class TableData
    {
        [Find(How = How.XPath, Selector = @".//div[@class = 'div-table-col-id']", Extract = ExtractOperator.Text)]
        public string Id { get; set; }

        [Find(How = How.XPath, Selector = @".//input[@class = 'div-table-col-age']", Extract = ExtractOperator.Attribute, Attribute = "value")]
        public string Age { get; set; }

        [Find(How = How.XPath, Selector = @".//div[@class = 'div-table-col-name']", Extract = ExtractOperator.Text)]
        public string Name { get; set; }

        [Find(How = How.XPath, Selector = @".//div[@class = 'div-table-col-addr']", Extract = ExtractOperator.Text)]
        public string Address { get; set; }
    }
}
