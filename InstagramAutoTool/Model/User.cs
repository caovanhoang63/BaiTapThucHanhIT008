using System;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace InstagramAutoTool.Model
{
    public class User
    {
        /// <summary>
        /// Click to the first post of the userDest
        /// </summary>
        public static void CLickToFirstPost(IWebDriver _driver,CancellationTokenSource _cancellationTokenSource)
        {
            
            if (_cancellationTokenSource.IsCancellationRequested)
                return;
            
            var post =  _driver.FindElement(By.XPath("//div[@class='_aabd _aa8k  _al3l']"));
            if (_cancellationTokenSource.IsCancellationRequested)
                return;
            post.Click();
        }
        
        
        /// <summary>
        /// Auto Follow user
        /// </summary>
        public static Task AutoFollow(IWebDriver _driver,RuningHelper _runingHelper)
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

            return Task.CompletedTask;
        }
    }
}