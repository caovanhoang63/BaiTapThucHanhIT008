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
        private List<Pair<string,string>> _listSourceAcount;
        
        
        
        
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
            _driver = new ChromeDriver(service,options);
            _runingHelper = new RuningHelper();
            
            _javaScriptExecutor = (IJavaScriptExecutor)_driver;
            _action = new Actions(_driver);
            
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            _driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(30);
            
            _cancellationTokenSource = cancellationTokenSource;
            
            // ProxyAuthentication();
            _driver.Manage().Network.StartMonitoring();
        }

        public IWebDriver Driver => _driver;

        public RuningHelper RuningHelper => _runingHelper;

        /// <summary>
        /// Stop driver
        /// </summary>
        public void Stop()
        {
            try
            {
                _driver.Manage().Network.StopMonitoring();
                _driver.Quit();
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
            try
            {
                _driver.Navigate().GoToUrl("https://www.instagram.com/");
                var userNameInput = _driver.FindElement(By.Name("username"));
                userNameInput.SendKeys(userName);

                var passwordInput = _driver.FindElement(By.Name("password"));
                passwordInput.SendKeys(password);
            
                var loginButton = _driver.FindElements(By.TagName("button"));
                loginButton[1].Click();

                Thread.Sleep(5000);
                
                if (_driver.Url == "https://www.instagram.com/")
                {
                    throw new Exception();
                }

            }
            catch (Exception e)
            {
                throw new Exception();
            }

        }
        
        
        /// <summary>
        /// Runs functions in ListFunc until last userDest's Post
        /// </summary >
        /// <param name="userDest"></param>
        /// <param name="listFunc"></param>
        /// <param name="comment"></param>
        /// 

        
        public async Task RunBuff(string userDest,int limit,bool[] listFunc , string comment = null)
        {

            try
            {
                _driver.Navigate().GoToUrl("https://www.instagram.com/" + userDest + "/");

                if (listFunc[1])
                {
                    await User.AutoFollow(_driver,_runingHelper);
                }

                if (listFunc[0] == false && listFunc[2] == false)
                    return;

                if (!User.CLickToFirstPost(_driver, _cancellationTokenSource))
                    return;
                

        

                string postLink;
                string prevLink = string.Empty;
                int count = 1;
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

                    if (postLink == prevLink)
                        return;
                    prevLink = postLink;
                    count++;

            
                    if (limit != -1 && count >limit)
                        return;
                }
            }
            catch (Exception e)
            {
                ShowErrorMessageBox();
            }
        }
        public async Task RunBuffAPost(string url, bool[] listFunc, string comment = null)
        {
            try
            {
                _driver.Navigate().GoToUrl(url);
                if (_cancellationTokenSource.IsCancellationRequested)
                    return;

                if (listFunc[0])
                {
                    await (Post.LikePostByLink(_driver, _runingHelper));
                }

                if (listFunc[1])
                {
                    await Post.CommentPost(_driver, _runingHelper, comment);
                }
            }
            catch (Exception e)
            {   
                ShowErrorMessageBox();
            }


        }

        /// <summary>
        /// RunCraw
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        /// 
      
        public async Task RunCraw(string userDest,int limit ,bool[] listFunc, string folderPath)
        {
            try
            {
                _driver.Navigate().GoToUrl("https://www.instagram.com/" + userDest + "/");
                // function dow all images
                List<string> link = new List<string>();

                string userNameFolder = folderPath + "\\"+ userDest;

                if (!Directory.Exists(userNameFolder))
                {
                    Directory.CreateDirectory(userNameFolder);
                }
                string postLink;
                string prevLink = string.Empty;
                await Task.Delay(300);


                if (!User.CLickToFirstPost(_driver, _cancellationTokenSource))
                    return;
            
                await Task.Delay(500);
                int count = 1;
                while (true)
                {
                    string postFolder = userNameFolder + "\\" +"post_" + count;
            
                    if (!Directory.Exists(postFolder))
                        Directory.CreateDirectory(postFolder);
            
                    if (listFunc[0])
                        await Post.DownLoadAllImage(_driver, postFolder, userDest, _runingHelper);
                    if(listFunc[1])
                        await Post.DownLoadAllComment(_driver, postFolder, _runingHelper);

                    if (listFunc[2])
                        await Post.DownloadDescription(_driver, postFolder);
                    
                    postLink = await NavigateToNextPost();
                    if (postLink == prevLink)
                        return;
                    prevLink = postLink;
                    count++;

                    if (limit != -1 && count > limit)
                        return;
                }
            }
            catch
            {
                ShowErrorMessageBox();
            }
        }


        public async Task RunCrawAPost(string url, bool[] listFunc, string folderPath)
        {
            try
            {
                _driver.Navigate().GoToUrl(url);
                string userNameFolder = folderPath + "\\" + "PostCraw";

                if (!Directory.Exists(userNameFolder))
                {
                    Directory.CreateDirectory(userNameFolder);
                }
                await Task.Delay(300);

                string postFolder = userNameFolder + "\\" + url.Substring(28);

                if (!Directory.Exists(postFolder))
                    Directory.CreateDirectory(postFolder);

                if (listFunc[0])
                    await Post.DownLoadAllImageByLink(_driver, postFolder, url, _runingHelper);
                if (listFunc[1])
                    await Post.DownLoadAllCommentByLink(_driver, postFolder, url, _runingHelper);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ShowErrorMessageBox();
            }
            
        }



        public async Task RunCrawByHashTag(List<string> listHashTag,int limit ,bool[] listFunc, string folderPath)
        {
            try
            {
                _driver.Navigate().GoToUrl("https://www.instagram.com/" + "explore/tags" + "/" + listHashTag[0]);
            
                // function dow all images

                string userNameFolder = folderPath + "\\"+ listHashTag[0];

                if (!Directory.Exists(userNameFolder))
                {
                    Directory.CreateDirectory(userNameFolder);
                }
                
                string postLink;
                string prevLink = string.Empty;
                await Task.Delay(500);

                
                if(!User.CLickToFirstPost(_driver, _cancellationTokenSource)) return;
                
                await Task.Delay(500);
                int count = 1;
                while (true)
                {
                    string postFolder = userNameFolder + "\\" +"post_" + count;
                    
                    if (!Directory.Exists(postFolder))
                        Directory.CreateDirectory(postFolder);

                    string description = Post.GetDescription(_driver).ToLower();

                    
                    bool flag = true;
                    
                    foreach (var hashtag in listHashTag)
                    {
                        if (!description.Contains("#" + hashtag.ToLower())  )
                        {
                            flag = false;
                            break;
                        }
                    }

                    await Task.Delay(1000);
                    
                    if (flag)
                    {
                        //Run functions
                        if (listFunc[0])
                            await Post.DownLoadAllImage(_driver, postFolder, "", _runingHelper);
                            
                        if(listFunc[1])
                            await Post.DownLoadAllComment(_driver, postFolder, _runingHelper);

                        if (listFunc[2])
                            await Post.DownloadDescription(_driver, postFolder);

                        count++;
                    }
                    
                    postLink = await NavigateToNextPost();
                    if (postLink == prevLink)
                    {
                        _driver.Navigate().GoToUrl("https://www.instagram.com/" + "explore/tags" + "/" + listHashTag[0]);
                        User.CLickToFirstPost(_driver, _cancellationTokenSource);
                    }
                    
                    prevLink = postLink;
                    if (limit != -1 && count > limit)
                        return;
                }
            }
            catch (Exception e)
            {
                ShowErrorMessageBox();
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

        
        /// <summary>
        /// Show a dialog message box, when have any error in runtime
        /// </summary>
        private void ShowErrorMessageBox()
        {
            MessageBox.Show("Đã có lỗi xảy ra trong quá trình chạy!\n Vui lòng kiểm tra lại!");
            _driver.Quit();
        }
        
        
    }
    
}