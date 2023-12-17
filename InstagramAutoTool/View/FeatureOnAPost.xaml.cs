using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using InstagramAutoTool.Model;
using CheckBox = System.Windows.Controls.CheckBox;
using MessageBox = System.Windows.MessageBox;

namespace InstagramAutoTool.View
{
    public partial class FeatureOnAPost : Page
    {
        private MainWindow _mainWindow;
        private List<string> _listPost;
        public List<string> ListPost => _listPost;
        public FeatureOnAPost(MainWindow mainWindow)
        {
            InitializeComponent();
            _listPost = new List<string>();
            this._mainWindow = mainWindow;
        }

        private async void RunBuffByLink_Click(object sender, RoutedEventArgs e)
        {
            if (!_mainWindow.CheckHaveUserAccount())
            {
                MessageBox.Show("Vui lòng nhập tài khoản của bạn");
                return;
            }
            if(!CheckPostLink())
            {
                MessageBox.Show("Vui lòng nhập link bài post");
                return;
            }
            _mainWindow.StartTimer();
            _mainWindow.StopButton.IsEnabled = true;
            bool[] listFunc = { false, false };
            string comment = string.Empty;

            int y = ListPost.Count;
            MessageBox.Show(y.ToString());

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
                    foreach(var post in _listPost) 
                    {
                        await _mainWindow.Selenium.RunBuffAPost(post, listFunc, comment);
                    }
                }
                else
                    foreach (var post in _listPost)
                    {
                        await _mainWindow.Selenium.RunBuffAPost(post, listFunc);
                    }
            }
            _mainWindow.StopTimer();
            _mainWindow.Selenium.Stop();
            _mainWindow.StopButton.IsEnabled = false;
        }

        private async void DownloadByLink_Click(object sender, RoutedEventArgs e)
        {
            if (!_mainWindow.CheckHaveUserAccount())
            {
                MessageBox.Show("Vui lòng nhập tài khoản của bạn");
                return;
            }
            if (!CheckPostLink())
            {
                MessageBox.Show("Vui lòng nhập link bài post");
                return;
            }

            _mainWindow.StartTimer();
            _mainWindow.StopButton.IsEnabled = true;

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
            int i = 1;

            if (!_mainWindow.Login())
            {
                MessageBox.Show("Đăng nhập không thành công!");
            }

            else
            {
                foreach (var post in _listPost)
                {
                    await Task.Delay(4000);
                    try
                    {
                        await _mainWindow.Selenium.RunCrawAPost(post, listFunc, folderPath, i);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                    }

                    i++;

                }
                _mainWindow.Selenium.Stop();
                _mainWindow.StopTimer();
                _mainWindow.StopButton.IsEnabled = false;

            }
        }

        private FlowDocument _document;

        private void MultiPost_Checked(object sender, RoutedEventArgs e)
        {
            LinkPost.IsEnabled = false;
            ImportMultiPost dialog;
            //Check dialog opened before
            if (_document != null)
            {
                //Create with document
                dialog = new ImportMultiPost(_document);
            }
            else
            {
                //Create new 
                dialog = new ImportMultiPost();
            }

            if (dialog.ShowDialog() != true)
            {
                LinkPost.IsEnabled = true;
                MultiPost.IsChecked = false;
                return;
            }
            _listPost.Clear();
            foreach (var line in dialog.Lines)
            {
                _listPost.Add(line);
            }
            _document = dialog.Document;

        }
        private void MultiPost_Unchecked(object sender, RoutedEventArgs e)
        {
            LinkPost.IsEnabled = true;
            _listPost.Clear();
        }
        public bool CheckPostLink()
        {
            if (LinkPost.Text == String.Empty && _listPost.Count == 0)
                return false;
            if (MultiPost.IsChecked != true)
            {
                _listPost.Clear();
                _listPost.Add(LinkPost.Text);
            }
            return true;
        }

    }
}