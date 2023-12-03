using System;
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
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(@"C:\Users\ADMIN\Downloads\chromedriver-win32\chromedriver-win32", "chromedriver.exe");
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
            
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
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
            Thread.Sleep(30000);
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
                var autoFollowTask = Task.Run(AutoFollow);
                await autoFollowTask;
            }
            
            CLickToFirstPost();

            string postLink;
            string prevLink = string.Empty;
            while (true)
            {
                if (_cancellationTokenSource.IsCancellationRequested)
                    return;

                if (listFunc[0])
                {
                    await Task.Run(LikePost);
                }

                if (listFunc[2])
                {
                    await CommentPost(comment);          
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


             _javaScriptExecutor.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
           // CLickToFirstPost();
            Thread.Sleep(300);


            var images = _driver.FindElements(By.TagName("img"));

            List<string> imageSrcList = new List<string>();

            foreach (var image in images)
            {
                string src = image.GetAttribute("src");
                imageSrcList.Add(src);


            }
            int counter = 0;
            foreach (string src in imageSrcList)
            {
                if (true)
                {
                    // Xây dựng đường dẫn đầy đủ để lưu trữ hình ảnh
                    string saveAs = Path.Combine(folderPath, counter + ".jpg");
                     
                    try
                    {
                        // Tải về hình ảnh và lưu vào thư mục
                        using (WebClient client = new WebClient())
                        {
                            client.DownloadFile(new Uri(src), folderPath+ "\\_" +counter + ".jpg");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error downloading image: {ex.Message}");
                        // Bạn có thể xử lý hoặc bỏ qua lỗi tùy thuộc vào yêu cầu của bạn
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid URI: {src}");
                }

                // Tăng giá trị của counter
                counter++;
            
            }
        }
            /// <summary>
            /// Auto Follow user
            /// </summary>
            private void AutoFollow()
        {
            try
            {
                var followButton = _driver.FindElement(By.XPath("//button[@class=' _acan _acap _acas _aj1- _ap30']"));
                followButton.Click();
                _runingHelper.Follow++;
                Console.WriteLine("Follow thành công");
            }
            catch
            {
                Console.WriteLine("Đã được follow trước đó");
            }
        }


        /// <summary>
        /// Auto LikePost
        /// </summary>
        private async Task LikePost()
        {
            try
            {
                await Task.Delay(300);
                var likeContainer = _driver.FindElement(By.XPath("//span[@class='_aamw']"));
                var likeButton = likeContainer.FindElement(By.TagName("div"));
                var label =  likeButton.FindElement(By.TagName("svg"));
                await Task.Delay(300);
                if (label.GetAttribute("aria-label") == "Like")
                {
                    likeButton.Click();
                    _runingHelper.Like += 1;
                }
                await Task.Delay(300);
            }
            catch (Exception e)
            {
                Console.WriteLine("Liked");
            }
        }


        
        /// <summary>
        /// Auto Comment Post
        /// </summary>
        /// <param name="comment"></param>
        private async Task CommentPost(string comment)
        {
            try
            {
                await Task.Delay(300);
                IWebElement textarea =  _driver.FindElement(By.TagName("textarea"));
                textarea.Click();
                textarea = _driver.FindElement(By.TagName("textarea"));
                textarea.SendKeys(comment);
                await Task.Delay(500);
                Actions actions = new Actions(_driver);
                actions.SendKeys(Keys.Enter);
                actions.Build().Perform();
                await Task.Delay(500);
                _runingHelper.Comment++;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
        
        
        
        /// <summary>
        /// Click to the first post of the userDest
        /// </summary>
        private void CLickToFirstPost()
        {
            if (_cancellationTokenSource.IsCancellationRequested)
                return;

            if (_cancellationTokenSource.IsCancellationRequested)
                return;
            
            var post =  _driver.FindElement(By.XPath("//div[@class='_aabd _aa8k  _al3l']"));
            if (_cancellationTokenSource.IsCancellationRequested)
                return;
            post.Click();
        }

        
        /// <summary>
        /// Navigate to the next post by pressing Right Arrow Key
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        private Task<string> NavigateToNextPost()
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