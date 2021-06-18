using Microsoft.Edge.SeleniumTools;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading;

namespace HashKiller_API
{
    public class HashKiller
    {
        public HashKillerResult Get(string hash)
        {
            EdgeDriverService driverService = EdgeDriverService.CreateChromiumService();
            EdgeOptions options = new EdgeOptions();
            driverService.HideCommandPromptWindow = true;
            options.UseChromium = true;
            options.AddArgument("headless");
            options.AddArgument("disable-gpu");
            EdgeDriver driver = new EdgeDriver(driverService, options, new TimeSpan(0, 2, 0));
            try
            {
                driver.Navigate().GoToUrl("https://hashkiller.ru");
                Thread.Sleep(6550);
                var hashelement = driver.FindElementByXPath("//input[@id='HForm']");
                hashelement.SendKeys(hash);
                string cap = Regex.Match(driver.PageSource, "Решите пример: (.*) =").Groups[1].Value;
                var ansver = Calculator.Calc(cap).ToString();
                var captchaelement = driver.FindElementByXPath("//input[@placeholder='Ответ числом']");
                captchaelement.SendKeys(Convert.ToInt32(ansver).ToString());
                var buttonelemt = driver.FindElementByXPath("//button[@id='submit-button']");
                buttonelemt.Click();
                HashKillerResult result = new HashKillerResult();
                result.Password = driver.FindElementByXPath("//td[@class='center']//input[@name='hash']").GetAttribute("value");
                result.Hash = hash;
                driver.Quit();
                return result;
            }
            catch
            {
                HashKillerResult result = new HashKillerResult();
                result.Password = "";
                result.Hash = "";
                driver.Quit();
                return result;
            }

        }
        public static class Calculator
        {
            // Создадим статический экземпляр DataTable, чтобы каждый раз не инициализировать его заново
            private static DataTable Table { get; } = new DataTable();

            // Наш метод подсчета
            // Добавьте отлов ошибок по вкусу)
            public static double Calc(string Expression) => Convert.ToDouble(Table.Compute(Expression, string.Empty));
        }
    }

    public class HashKillerResult
    {
        public string Hash;        
        public string Password;
    }
}
