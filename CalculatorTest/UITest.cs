using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Annotations;

namespace CalculatorTest
{
    [TestClass]
    public class UITest
    {
        private readonly string WinAppDriverURI = "http://127.0.0.1:4723";
        private readonly string DeviceName = "WindowsPC";
        private string AppPath = GetAssemblyPath();

        AppiumOptions _options = null;
        WindowsDriver<WindowsElement> _session = null;

        
        [TestMethod]
        public void UITest1()
        {
            var actions = new Actions(_session);

            /* "1 + 2 = 3"のテスト. */
            _session.FindElementByAccessibilityId("NumButton1").Click();
            _session.FindElementByAccessibilityId("PlusButton").Click();
            _session.FindElementByAccessibilityId("NumButton2").Click();
            _session.FindElementByAccessibilityId("EqualButton").Click();

            string digits = _session.FindElementByAccessibilityId("DisplayTextBox").Text;

            Assert.AreEqual(digits, "4");
            Thread.Sleep(1000);
        }


        /// <summary>
        /// アセンブリのパスを取得する.
        /// </summary>
        /// <returns></returns>
        private static string GetAssemblyPath()
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            return Directory.GetParent(assembly.Location) + @"\Calculator.exe";
        }

        [TestInitialize]
        public void TestInitialize()
        {
            Debug.WriteLine("TestInitialize() start.");

            /* Appiumに対するオプション設定 */
            _options = new AppiumOptions();
            _options.AddAdditionalCapability("app", AppPath);
            _options.AddAdditionalCapability("DeviceName", DeviceName);

            /* セッションの生成 */
            _session = new WindowsDriver<WindowsElement>(new Uri(WinAppDriverURI), _options);

            Thread.Sleep(1000);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Debug.WriteLine("TestCleanup() start.");

            _session.Quit();
            _session = null;
        }

    }




}
