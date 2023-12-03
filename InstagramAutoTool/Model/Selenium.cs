﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net  ;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
 


namespace InstagramAutoTool.Model
{
    public class Selenium
    {
        private readonly IWebDriver _driver;
        private readonly IJavaScriptExecutor _javaScriptExecutor;
        private Actions _action;
        private CancellationTokenSource _cancellationTokenSource;
        private RuningHelper _runingHelper;


        public Selenium(string userProfile,CancellationTokenSource cancellationTokenSource)
        {
            var options = new ChromeOptions();
            options.AddArgument("test-type");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("no-sandbox");
            options.AddArgument("disable-infobars");
            //options.AddArgument("--headless"); //hide browser
            options.AddArgument("--start-maximized");
            //options.AddArgument("--window-size=1100,300");
            //options.AddUserProfilePreference("profile.default_content_setting_values.images", 2);
            
            // Profile [Change:User name]
            options.AddArgument(@"user-data-dir=C:\Users\ADMIN\AppData\Local\Google\Chrome\User Data");
            var service = ChromeDriverService.CreateDefaultService();
            _driver = new ChromeDriver(service, options);
            
            _runingHelper = new RuningHelper(); 
            _cancellationTokenSource = cancellationTokenSource;

            
        }
        
        public Selenium(CancellationTokenSource cancellationTokenSource)
        {
            //Start Config for  Webdriver
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            ChromeOptions options = new ChromeOptions();
            
            //option config
            options.AddArgument("test-type");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("no-sandbox");
            options.AddArgument("disable-infobars");
            options.AddArgument("--start-maximized");


            // ProxyConfig proxy = new ProxyConfig();
            // options.Proxy = proxy.Proxy;
            //End Config
            
            
            _driver = new ChromeDriver(service,options);
            _runingHelper = new RuningHelper();
            
            _javaScriptExecutor = (IJavaScriptExecutor)_driver;
            _action = new Actions(_driver);
            
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            _driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);
            
            _cancellationTokenSource = cancellationTokenSource;
            
            // ProxyAuthentication();
            _driver.Manage().Network.StartMonitoring();
        }

        public IWebDriver Driver => _driver;


        public RuningHelper RuningHelper => _runingHelper;


        private void ProxyAuthentication()
        {
            NetworkAuthenticationHandler handler = new NetworkAuthenticationHandler()
            {
                UriMatcher = d => true, //d.Host.Contains("your-host.com")
                Credentials = new PasswordCredentials("vgwqlxby", "cz2bxmm9p7e1")
            };
            _driver.Manage().Network.AddAuthenticationHandler(handler);

        }
        
        /// <summary>
        /// Stop driver
        /// </summary>
        public void Stop()
        {
            try
            {
                _driver.Quit();
                _driver.Manage().Network.StopMonitoring();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Close()
        {
            _driver.Close();
        }
        
        
        /// <summary>
        /// Login to instagram
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void Login(string userName, string password)
        {
            
            _driver.Navigate().GoToUrl("https://www.instagram.com/");
            var userNameInput = _driver.FindElement(By.Name("username"));
            userNameInput.SendKeys(userName);

            var passwordInput = _driver.FindElement(By.Name("password"));
            passwordInput.SendKeys(password);
            
            var loginButton = _driver.FindElements(By.TagName("button"));
            loginButton[1].Click();
            Thread.Sleep(5000);
        }
        
        
        /// <summary>
        /// Runs functions in ListFunc until last userDest's Post
        /// </summary >
        /// <param name="userDest"></param>
        /// <param name="listFunc"></param>
        /// <param name="comment"></param>
        public async Task RunBuff(string userDest,bool[] listFunc, string comment = null)
        {
            _driver.Navigate().GoToUrl("https://www.instagram.com/" + userDest + "/");

            if (listFunc[1])
            {
                await User.AutoFollow(_driver,_runingHelper);
            }
            
            User.CLickToFirstPost(_driver,_cancellationTokenSource);

            string postLink;
            string prevLink = string.Empty;
            while (true)
            {
                if (_cancellationTokenSource.IsCancellationRequested)
                    return;

                if (listFunc[0])
                {
                    await (Post.LikePost(_driver,_runingHelper));
                }

                if (listFunc[2])
                {
                    await Post.CommentPost(_driver,_runingHelper,comment);          
                }
                
                postLink = await NavigateToNextPost();

                //Start Stop condition
                if (postLink == prevLink)
                    return;
                prevLink = postLink;
                //End Stop condition
            }
        }

        /// <summary>
        /// RunCraw
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public async Task RunCraw(string userDest, bool[] listFunc, string folderPath)
        {
            _driver.Navigate().GoToUrl("https://www.instagram.com/" + userDest + "/");
 
            // function dow all images
            List<string> Link = new List<string>();

            string userNameFolder =  folderPath + "\\" + userDest;

            if (!Directory.Exists(userNameFolder))
            {
                Directory.CreateDirectory(userNameFolder);
            }
            string postLink;
            string prevLink = string.Empty; 
            await Task.Delay(300);

            User.CLickToFirstPost(_driver, _cancellationTokenSource);
            await Task.Delay(500);
            int count = 1;
            while (true)
            {
                string postFolder = userNameFolder + "\\" +"post_" + count;
                if (!Directory.Exists(postFolder))
                {
                    Directory.CreateDirectory(postFolder);
                }
                if (listFunc[0])
                     await Post.DownLoadAllImage(_driver,postFolder,userDest);
                postLink = await NavigateToNextPost();
                if (postLink == prevLink)
                    return;
                prevLink = postLink;
                count++;
            }
        }



        /// <summary>
        /// Navigate to the next post by pressing Right Arrow Key
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        private  Task<string> NavigateToNextPost()
        {
            string link;
            try
            {
                _action.SendKeys(Keys.ArrowRight);
                _action.Build().Perform();
                link = _driver.Url;
            }
            catch (Exception e)
            {
                link = null;
            }
            return Task.FromResult(link);
        }
    }
    
}