using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace FirstTests
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // Khởi tạo trình duyệt Google Chrome
            driver = new ChromeDriver();
            // Phóng to toàn màn hình trình duyệt
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            // 1. Điều hướng đến trang web Google
            driver.Navigate().GoToUrl("https://google.com");

            // 2. Tìm ô tìm kiếm của Google bằng Name (ô tìm kiếm có thuộc tính name='q')
            IWebElement searchBox = driver.FindElement(By.Name("q"));

            // 3. Nhập từ khóa cần tìm kiếm và nhấn Enter
            searchBox.SendKeys("Lập trình C# nâng cao");
            searchBox.SendKeys(Keys.Enter);

            // 4. Tạm dừng 5 giây để bạn kịp quan sát kết quả tìm kiếm trước khi tắt
            Thread.Sleep(5000);
        }

        [TearDown]
        public void CloseBrowser()
        {
            // Tắt trình duyệt sau khi test xong
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}