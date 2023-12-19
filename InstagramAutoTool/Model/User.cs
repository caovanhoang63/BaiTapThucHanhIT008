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
        public static bool CLickToFirstPost(IWebDriver _driver,CancellationTokenSource _cancellationTokenSource)
        {
            try
            {
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                if (_cancellationTokenSource.IsCancellationRequested)
                    return false;
                var post = _driver.FindElement(By.XPath("//div[@class='_aagu']"));
                if (_cancellationTokenSource.IsCancellationRequested)
                    return false;
                post.Click();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            }
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