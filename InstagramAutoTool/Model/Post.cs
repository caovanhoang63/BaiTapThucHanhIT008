﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Markup;
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
        public static async Task CommentPost(IWebDriver _driver, RuningHelper _runingHelper, string comment)
        {
            try
            {
                await Task.Delay(300);
                IWebElement textarea = _driver.FindElement(By.TagName("textarea"));
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
        public static async Task LikePost(IWebDriver _driver, RuningHelper _runingHelper)
        {
            try
            {
                await Task.Delay(300);
                var likeContainer = _driver.FindElement(By.XPath("//span[@class='_aamw']"));
                var likeButton = likeContainer.FindElement(By.TagName("div"));
                var label = likeButton.FindElement(By.TagName("svg"));
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
        public static async Task DownLoadAllImage(IWebDriver _driver, string folderPath, string userDest)
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

            } while (await NavigateToNextImage(container));

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

        public static async Task DownLoadAllComment(IWebDriver _driver, string folderPath, string userDest)
        {
           List<string> comment = new List<string>(); 
            try
            {
                var containUser = _driver.FindElements(By.XPath("//a[@class='x1i10hfl xjqpnuy xa49m3k xqeqjp1 x2hbi6w xdl72j9 x2lah0s xe8uvvx xdj266r x11i5rnm xat24cr x1mh8g0r" +
                    " x2lwn1j xeuugli x1hl2dhg xggy1nq x1ja2u2z x1t137rt x1q0g3np x1lku1pv x1a2a7pz x6s0dn4 xjyslct x1ejq31n xd10rxx x1sy0etr x17r0tee x9f619 x1ypdohk" +
                    " x1f6kntn xwhw2v2 xl56j7k x17ydfre x2b8uid xlyipyv x87ps6o x14atkfc xcdnw81 x1i0vuye xjbqb8w xm3z3ea x1x8b98j x131883w x16mih1h x972fbf xcfux6l x1qhh985 " +
                    "xm0m39n xt0psk2 xt7dq6l xexx8yu x4uap5 x18d9i69 xkhd6sd x1n2onr6 x1n5bzlp xqnirrm xj34u2y x568u83']"));
                await Task.Delay(1000);
                 

                var containComment = _driver.FindElements(By.XPath("//span[@class='_ap3a _aaco _aacu _aacx _aad7 _aade']"));
                await Task.Delay(1000);
               
                for ( int i = 0; i < containComment.Count; i++)
                {
                    comment.Add( containUser[i+1].Text + ": " +containComment[i].Text );
                }
                
                try
                {

                    File.WriteAllLines(@"C:\\Users\\ADMIN\\OneDrive\\Máy tính\\New folder", comment);

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi lưu dữ liệu vào tệp tin: {ex.Message}");
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            
        }
    }
}