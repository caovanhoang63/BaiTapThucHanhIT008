using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using static InstagramAutoTool.View.MainWindow;

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
        public static async Task LikePostByLink(IWebDriver _driver, RuningHelper _runingHelper)
        {
            try
            {
                await Task.Delay(300);
                var likeContainer = _driver.FindElement(By.XPath("//span[@class='xp7jhwk']"));
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
        public static async Task DownLoadAllImage(IWebDriver _driver, string folderPath, string userDest, RuningHelper _runingHelper)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            HashSet<string> links = new HashSet<string>();
            Console.WriteLine("Done");

            IWebElement container;
            try
            {

                container=  _driver.FindElement(By.XPath("//div[@class='_aamn']"));
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
                        Console.WriteLine("Done1");
                    }
                }
                catch
                {
                    continue;
                }

            } while (await NavigateToNextImage(container));

            Console.WriteLine("Done");
            using (WebClient webClient = new WebClient())
            {
                int i = 1;
                foreach (var link in links)
                {
                    Console.WriteLine(link);
                    await Task.Run(() =>
                    {
                        webClient.DownloadFile(new Uri(link), folderPath + "\\_"+ userDest + "_" + i + ".jpg");
                        _runingHelper.ImageDownload+=1;
                        Console.WriteLine(i);
                    });
                    i++;
                }
            }
        }

        public static async Task DownLoadAllImageByLink(IWebDriver _driver, string folderPath,string userDest, RuningHelper _runingHelper)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            HashSet<string> links = new HashSet<string>();
            Console.WriteLine("Done");

            IWebElement container;
            try
            {

                container = _driver.FindElement(By.XPath("//div[@class='x1lliihq xh8yej3']"));
            }
            catch
            {
                container = _driver.FindElement(By.XPath("//div[contains(@class, '_aagv')"));
            }
            do
            {
                try
                {
                    var imgs = container.FindElements(By.TagName("img"));
                    foreach (var img in imgs)
                    {
                        links.Add(img.GetAttribute("src"));
                        Console.WriteLine("Done1");
                    }
                }
                catch
                {
                    continue;
                }

            } while (await NavigateToNextImage(container));

            Console.WriteLine("Done");
            using (WebClient webClient = new WebClient())
            {
                int i = 1;
                foreach (var link in links)
                {
                    await Task.Run(() =>
                    {
                        webClient.DownloadFile(new Uri(link), folderPath + "\\" + "img_" + i + ".jpg");
                        _runingHelper.ImageDownload += 1;
                        Console.WriteLine(i);
                    });
                    i++;
                }

            }
        }

        private static async Task<bool> NavigateToNextImage(IWebElement container)
        {
            try
            {
                var nextButton = container.FindElement(By.XPath("//button[@class=' _afxw _al46 _al47']"));

                nextButton.Click();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static async Task DownLoadAllComment(IWebDriver _driver, string folderPath, RuningHelper _runingHelper)
        {
            List<string> comments = new List<string>(); 
            try
            {
                IWebElement  Container = _driver.FindElement(By.XPath("//ul[@class='_a9z6 _a9za']"));
                await Task.Delay(1000);

                // load comment 
                while (true)
                {
                    try
                    {
                        _driver.FindElement(By.XPath("/html/body/div[7]/div[1]/div/div[3]/div/div/div/div/div[2]/div/article/div/div[2]/div/div/div[2]/div[1]/ul/div[3]/div/div/li/div/button")).Click();
                        await Task.Delay(500);
                    }
                    catch
                    {
                        break;
                    }
                }
                // get element contain comment 
                ReadOnlyCollection<IWebElement> commentSpans =  Container.FindElements(By.XPath("" +
                    "//span[@class='_ap3a _aaco _aacu _aacx _aad7 _aade']"));
                await Task.Delay(1000);

                // get element contain username
                ReadOnlyCollection<IWebElement> username = Container.FindElements(By.XPath(""+"//a[@class='x1i10hfl xjqpnuy xa49m3k xqeqjp1 x2hbi6w xdl72j9 x2lah0s xe8uvvx xdj266r x11i5rnm xat24cr " +
                    "x1mh8g0r x2lwn1j xeuugli x1hl2dhg xggy1nq x1ja2u2z x1t137rt x1q0g3np x1lku1pv x1a2a7pz x6s0dn4 xjyslct x1ejq31n xd10rxx x1sy0etr x17r0tee x9f619 x1ypdohk x1f6kntn xwhw2v2 " +
                    "xl56j7k x17ydfre x2b8uid xlyipyv x87ps6o x14atkfc xcdnw81 x1i0vuye xjbqb8w xm3z3ea x1x8b98j x131883w x16mih1h x972fbf xcfux6l x1qhh985 xm0m39n xt0psk2 xt7dq6l xexx8yu x4uap5 " +
                    "x18d9i69 xkhd6sd x1n2onr6 x1n5bzlp xqnirrm xj34u2y x568u83']"));
                await Task.Delay(1000);


                for (int i = 0; i < commentSpans.Count; i++)

                {
                    comments.Add( username[i+1].Text +": " +commentSpans[i].Text);
                    _runingHelper.CommentDownload+=1;
                }
                try
                {
                    await Task.Run(() =>
                    {
                        File.WriteAllLines(folderPath + "\\" + "userDest" + ".txt", comments);
                    });
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

        public static string GetDescription(IWebDriver _driver)
        {
            try
            {
                string descriptionElement =
                    _driver.FindElement(By.XPath("//h1[@class='_ap3a _aaco _aacu _aacx _aad7 _aade']")).Text;
                return descriptionElement;

            }
            catch
            {
                return null;
            }
        }

        public static async Task DownloadDescription(IWebDriver _driver, string folderPath)
        {
            string description = GetDescription(_driver);
            if (description == null)
                return;
            
            await Task.Run(() =>
            {
                File.WriteAllText(folderPath + "\\" + "description" + ".txt", description);
            });
            
        }

        public static async Task DownLoadAllCommentByLink(IWebDriver _driver, string folderPath, string userDest, RuningHelper _runingHelper)
        {
            List<string> comments = new List<string>();
            try
            {
                IWebElement scrollDiv =
                    _driver.FindElement(By.CssSelector("div.x5yr21d.xw2csxc.x1odjw0f.x1n2onr6"));
                IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)_driver;

                
                
                
                int x = 2000;
                int curCount = scrollDiv.FindElements(By.XPath(
                    "//span[@class='x1lliihq x1plvlek xryxfnj x1n2onr6 x193iq5w xeuugli x1fj9vlw x13faqbe x1vvkbs x1s928wv xhkezso x1gmr53x x1cpjm7i x1fgarty x1943h6x x1i0vuye xvs91rp xo1l8bm x5n08af x10wh9bi x1wdrske x8viiok x18hxmgj']")).Count;

                int count = curCount;
                while (true)
                {
                    javaScriptExecutor.ExecuteScript("arguments[0].scroll(0,arguments[1])",
                        scrollDiv,x);

                    Thread.Sleep(2000);
                    
                    curCount = scrollDiv.FindElements(By.XPath(
                        "//span[@class='x1lliihq x1plvlek xryxfnj x1n2onr6 x193iq5w xeuugli x1fj9vlw x13faqbe x1vvkbs x1s928wv xhkezso x1gmr53x x1cpjm7i x1fgarty x1943h6x x1i0vuye xvs91rp xo1l8bm x5n08af x10wh9bi x1wdrske x8viiok x18hxmgj']")).Count;

                    
                    if (count == curCount)
                        break;
                    count = curCount;
                    x += 2000;
                }


                var list = scrollDiv.FindElements(By.XPath(
                    "//span[@class='x1lliihq x1plvlek xryxfnj x1n2onr6 x193iq5w xeuugli x1fj9vlw x13faqbe x1vvkbs x1s928wv xhkezso x1gmr53x x1cpjm7i x1fgarty x1943h6x x1i0vuye xvs91rp xo1l8bm x5n08af x10wh9bi x1wdrske x8viiok x18hxmgj']"));

                for (int i = 1; i < list.Count -1; i+=2)
                {
                    comments.Add(list[i].Text + ":" + list[i+1].Text);
                    _runingHelper.CommentDownload += 1;
                }
                
                try
                {
                    await Task.Run(() =>
                    {
                        File.WriteAllLines(folderPath + "\\" + "comments" + ".txt", comments);
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi lưu dữ liệu vào tệp tin: {ex.Message}");
                }
            }
            catch (Exception e)
            {
            }

        }

    }
}