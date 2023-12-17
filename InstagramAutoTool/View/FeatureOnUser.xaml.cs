using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using CheckBox = System.Windows.Controls.CheckBox;
using MessageBox = System.Windows.MessageBox;

namespace InstagramAutoTool.View
{
    public partial class FeatureOnUser : Page
    {
        private MainWindow _mainWindow;
        private List<string> _listUsers;
        public List<string> ListUsers => _listUsers;
        private Timer _timer;
        public FeatureOnUser(MainWindow mainWindow)
        {
            InitializeComponent();
            _listUsers = new List<string>();
            this._mainWindow = mainWindow;
        }

        public FeatureOnUser()
        {
            InitializeComponent();
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
            if (!CheckHaveUserDest())
            {
                MessageBox.Show("Vui lòng nhập tài khoản đích");
                return ;
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
            if (PostNum.Text == "" && UnlimitPostNum.IsChecked==false )
            {
                MessageBox.Show("Vui lòng chọn số lượng bài viết");
                return;
            }
            int x = _mainWindow.ListAccount.Count;
            MessageBox.Show(x.ToString());
            int y = ListUsers.Count;
            MessageBox.Show(y.ToString());
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
               
                
                // à không mình phải sửa vòng lặp từ ngoài này mới đúng chứ , hàm RunBuff vẫn chạy cho từng user , có đều là mình sẽ chạy nhiều hàm RunBuff 
                if (listFunc[2])
                {
                    foreach(var user in ListUsers )
                    {
                        await _mainWindow.Selenium.RunBuff(user, limit, listFunc, comment);

                    }
                }
                else 
                    foreach(var user in ListUsers)
                    {
                        await _mainWindow.Selenium.RunBuff(user, limit, listFunc);

                    }

                _mainWindow.Selenium.Stop();
                _mainWindow.StopTimer();
                _mainWindow.StopButton.IsEnabled = false;
            }
        }
        
        private async void RunCrawlerButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.StartTimer();
            if (!_mainWindow.CheckHaveUserAccount())
            {
                MessageBox.Show("Vui lòng nhập tài khoản của bạn");
                _mainWindow.StopTimer();
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
                _mainWindow.StopTimer();
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
                _mainWindow.StopTimer();
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
        private FlowDocument _document;
        private void MultiUsers_Unchecked(object sender, RoutedEventArgs e)
        {
            UserNameDest.IsEnabled = false;
             
            ImportMultiUsersDialog dialog;

            //check for dialog is opened before
            if (_document != null)
            {
                //create with cache
                dialog = new ImportMultiUsersDialog(_document);
            }
            else
            {
                //If the dialog box hasn't been opened before, create a new dialog box
                dialog = new ImportMultiUsersDialog();
            }

            if (dialog.ShowDialog() != true)
            {
                UserNameDest.IsEnabled = true;
                
                MultiUsers.IsChecked = false;
                return;
            }
            _listUsers.Clear();
            foreach (var line in dialog.Lines)
            {
                
                _listUsers.Add(line);
            }
            //cache text in richtextbox of dialog
            _document = dialog.Document;
        }

        private void MultiUsers_Checked(object sender, RoutedEventArgs e)
        {

            UserNameDest.IsEnabled = true;
             
            _listUsers.Clear();
        }
        public bool CheckHaveUserDest()
        {
            if (UserNameDest.Text == String.Empty && _listUsers.Count == 0)
                return false;
            if (MultiUsers.IsChecked != true && _listUsers.Count==0)
            {
                _listUsers.Add(UserNameDest.Text);
            }
            return true;
        }

    }
}