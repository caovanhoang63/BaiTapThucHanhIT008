using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using InstagramAutoTool.Model;
using CheckBox = System.Windows.Controls.CheckBox;
using MessageBox = System.Windows.MessageBox;

namespace InstagramAutoTool.View
{
    public partial class FeatureOnUser : Page
    {
        private MainWindow _mainWindow;
        private Timer _timer;
        public FeatureOnUser(MainWindow mainWindow)
        {
            InitializeComponent();
            this._mainWindow = mainWindow;
        }
        
        private async void RunBuffButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.StartTimer();
            if (!_mainWindow.CheckHaveUserAccount())
            {
                MessageBox.Show("Vui lòng nhập tài khoản của bạn");
                _mainWindow.StopTimer();
                return;
            }
            
            _mainWindow.StopButton.IsEnabled = true;
            bool[] listFunc = {false,false,false} ;
            string comment = string.Empty;
            foreach (var child in BuffCheckList.Children)
            {
                if (child is CheckBox cb)
                {
                    if (cb.IsChecked == null  || !(bool)cb.IsChecked)
                        continue;
                    
                    if (cb.Name == "Like")
                        listFunc[0] = true;
                    if (cb.Name == "Follow")
                        listFunc[1] = true;
                    if (cb.Name == "Comment")
                    {
                        CommentInputDialog commentInputDialog = new CommentInputDialog();
                        commentInputDialog.ShowDialog();
                        bool result = commentInputDialog.Accept;
 
                        if (!result)
                            return;
                        comment = commentInputDialog.Comment;
                        Console.WriteLine(comment);
                        listFunc[2] = true;
                    }
                }
            }
            
            if (!listFunc.Contains(true))
            {
                MessageBox.Show("Vui lòng chọn chức năng");
                return;
            }
            foreach (var account in _mainWindow.ListAccount)
            { 
                if (!_mainWindow.Login(account.First,account.Second))
                {
                    MessageBox.Show("Đăng nhập không thành công!");
                    _mainWindow.StopTimer();
                    _mainWindow.Selenium.Stop();
                    continue;
                }
                await Task.Delay(4000);
                int limit = 0;
                
                if (PostNum.IsEnabled)
                    limit = int.Parse(PostNum.Text);
                else
                    limit = -1;
                if (listFunc[2])
                {
                    await  _mainWindow.Selenium.RunBuff(UserNameDest.Text,limit ,listFunc, comment);
                }
                else 
                    await  _mainWindow.Selenium.RunBuff(UserNameDest.Text,limit ,listFunc);
                
                _mainWindow.Selenium.Stop();
                _mainWindow.StopTimer();
                _mainWindow.StopButton.IsEnabled = false;
            }
        }
        
        private async void RunCrawlerButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!_mainWindow.CheckHaveUserAccount())
            {
                MessageBox.Show("Vui lòng nhập tài khoản của bạn");
                return;
            }
            
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            var result = folderBrowserDialog.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }
            
            string folderPath = folderBrowserDialog.SelectedPath;
            _mainWindow.StopButton.IsEnabled = true;
            bool[] listFunc = { false, false };
            foreach (var child in CrawlerCheckList.Children)
            {
                if (child is CheckBox cb)
                {
                    if (cb.IsChecked == null  || !(bool)cb.IsChecked)
                        continue;

                    if (cb.Name == "DownloadImage")
                        listFunc[0] = true;
                    if (cb.Name == "DownloadComment")
                        listFunc[1] = true;
                }
            }

            if (!listFunc.Contains(true))
            {
                MessageBox.Show("Vui lòng chọn chức năng");
                return;
            }
            //  Console.WriteLine("Run");
            if (!_mainWindow.Login())
            {
                MessageBox.Show("Đăng nhập không thành công!");
            }
            else
            {
                await Task.Delay(4000);
                try
                {
                    int limit;
                    if (PostNum.IsEnabled)
                        limit = int.Parse(PostNum.Text);
                    else
                        limit = -1;
                    await _mainWindow.Selenium.RunCraw(UserNameDest.Text,limit, listFunc, folderPath);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
                _mainWindow.Selenium.Stop();
                _mainWindow.StopButton.IsEnabled = false;

            }
        }

        private void UnlimitedPostNum_OnChecked(object sender, RoutedEventArgs e)
        {
            PostNum.IsEnabled = false;
        }

        private void UnlimitedPostNum_UnChecked(object sender, RoutedEventArgs e)
        {
            PostNum.IsEnabled =true;

        }


    }
}