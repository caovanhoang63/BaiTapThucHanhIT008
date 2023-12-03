using System;
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
    }
}