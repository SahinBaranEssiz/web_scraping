using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web_scraping
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://regowholesale.com/collections/all/products/bounty-regular-paper-towels-15pk");
            var csv = new StringBuilder();

            for (int i = 0; i < 1189; i++)
            {
                //Name
                var produckt_name = driver.FindElement(By.XPath("//*[@class=\"product-meta__title heading h1\"]"));
                //Price
                var produckt_price = driver.FindElement(By.XPath("//div[@class=\"price-list\"]/span"));
                //sku
                var produckt_sku = driver.FindElement(By.XPath("//*[@class=\"product-meta__sku-number\"]"));

                var first = produckt_name.Text;
                var second = produckt_price.Text;
                var third = produckt_sku.Text;
                var newLine = string.Format("{0},{1},{2}", first, second, third);
                csv.AppendLine(newLine);


                Console.WriteLine(i);
                driver.FindElement(By.XPath("//*[@id=\"shopify-section-product-template\"]/section/div/div[1]/div/span[" + ((i == 0) ? 1 : 2) + "]/a")).Click();
            
            }

            File.WriteAllText(@"C:\Users\şahin\Desktop\verikazima\csv\regowholesale.csv", csv.ToString());

            driver.Quit();

        }
    }
}
