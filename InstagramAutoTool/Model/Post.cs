using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace InstagramAutoTool.Model
{
    public class Post
    {
        /// <summary>
        /// Auto Comment Post
        /// </summary>
        /// <param name="comment"></param>
        public static async Task CommentPost(IWebDriver _driver,RuningHelper _runingHelper,string comment)
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
        /// Auto LikePost
        /// </summary>
        public static async Task LikePost(IWebDriver _driver,RuningHelper _runingHelper)
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
        /// This function downloads all images from a post
        /// </summary>
        /// <param name="_driver"></param>
        /// <param name="folderPath"></param>
        /// <param name="userDest"></param>
        public static async Task DownLoadAllImage(IWebDriver _driver,string folderPath,string userDest)
        {
            HashSet<string> links = new HashSet<string>();
            IWebElement container;
            try
            {
                container= _driver.FindElement(By.XPath("//div[@class='_aamn']"));
            }
            catch
            {
                container= _driver.FindElement(By.XPath("//div[contains(@class, '_aatk') and contains(@class,'_aatl')]"));
            }
            do
            {
                try
                {
                    var imgs = container.FindElements(By.TagName("img"));
                    foreach (var img in imgs)
                    {
                        links.Add(img.GetAttribute("src"));
                    }
                }
                catch
                {
                    continue;
                }
                
            } while ( await NavigateToNextImage(container));

            using (WebClient webClient = new WebClient())
            {
                int i = 1;
                foreach (var link in links)
                {
                    Console.WriteLine(link);
                    webClient.DownloadFile(new Uri(link), folderPath + "\\_"+ userDest + "_" + i + ".jpg");
                    Console.WriteLine("-------------------------------------");
                    i++;
                }
            }
        }
        
        
        private static async Task<bool> NavigateToNextImage(IWebElement container)
        {
            try
            {
                await Task.Delay(300);

                var nextButton = container.FindElement(By.XPath("//button[@class=' _afxw _al46 _al47']"));
                
                await Task.Delay(300);
                
                nextButton.Click();
                
                await Task.Delay(300);
                
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
    }
}