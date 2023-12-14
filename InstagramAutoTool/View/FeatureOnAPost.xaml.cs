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
    public partial class FeatureOnAPost : Page
    {
        private MainWindow _mainWindow;
        public FeatureOnAPost(MainWindow mainWindow)
        {
            InitializeComponent();
            this._mainWindow = mainWindow;
        }

        private async void RunBuffByLink_Click(object sender, RoutedEventArgs e)
        {
            if (!_mainWindow.CheckHaveUserAccount())
            {
                MessageBox.Show("Vui lòng nhập tài khoản của bạn");
                return;
            }
            _mainWindow.StartTimer();
            _mainWindow.StopButton.IsEnabled = true;
            bool[] listFunc = { false, false };
            string comment = string.Empty;
            foreach (var child in BuffCheckList.Children)
            {
                if (child is CheckBox cb)
                {
                    if (cb.IsChecked == null || !(bool)cb.IsChecked)
                        continue;

                    if (cb.Name == "Like")
                        listFunc[0] = true;
                    if (cb.Name == "Comment")
                    {
                        CommentInputDialog commentInputDialog = new CommentInputDialog();
                        commentInputDialog.ShowDialog();
                        bool result = commentInputDialog.Accept;

                        if (!result)
                            return;
                        comment = commentInputDialog.Comment;
                        Console.WriteLine(comment);
                        listFunc[1] = true;
                    }
                }

            }
            if (!listFunc.Contains(true))
            {
                MessageBox.Show("Vui lòng chọn chức năng");
                _mainWindow.StopTimer();
                return;
            }
            foreach (var account in _mainWindow.ListAccount)
            {
                if (!_mainWindow.Login(account.First, account.Second))
                {
                    MessageBox.Show("Đăng nhập không thành công!");
                    _mainWindow.StopTimer();
                    _mainWindow.Selenium.Stop();
                    continue;
                }
                await Task.Delay(1000);

                if (listFunc[1])
                {
                    await _mainWindow.Selenium.RunBuffAPost(UserNameDest.Text, listFunc, comment);
                }
                else
                    await _mainWindow.Selenium.RunBuffAPost(UserNameDest.Text, listFunc);
                _mainWindow.StopTimer();
                _mainWindow.Selenium.Stop();
                _mainWindow.StopButton.IsEnabled = false;
            }


        }

        private void Like_Checked(object sender, RoutedEventArgs e)
        {

        }
        private async void DownloadByLink_Click(object sender, RoutedEventArgs e)
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
                    if (cb.IsChecked == null || !(bool)cb.IsChecked)
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
                    await _mainWindow.Selenium.RunCrawAPost(UserNameDest.Text, listFunc, folderPath);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
                _mainWindow.Selenium.Stop();
                _mainWindow.StopButton.IsEnabled = false;

            }

        }

    }
}