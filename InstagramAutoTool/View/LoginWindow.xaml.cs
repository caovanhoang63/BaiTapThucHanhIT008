using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Dynamic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Threading;
using InstagramAutoTool.Model;

namespace InstagramAutoTool.View
{
    public partial class LoginWindow : Window
    {

        private Selenium _selenium;
        private CancellationTokenSource _cancellationTokenSource;
        private DispatcherTimer _timer;
        public LoginWindow()
        {
            InitializeComponent();
            _cancellationTokenSource = new CancellationTokenSource();
            
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1),
            };
            _timer.Tick += TimerOnTick;
            
        }

        private void TimerOnTick(Object sender, EventArgs e)
        {
            try
            {
                RunningInforStackPanel.DataContext = _selenium.RuningHelper;
                // Console.WriteLine(_selenium.RuningHelper.Like);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

        }
        
        private bool Login()
        {
            try
            {
                _selenium = new Selenium(_cancellationTokenSource);
                _selenium.Login(UserName.Text,Password.Password);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        
        private async void RunBuffButton_OnClick(object sender, RoutedEventArgs e)
        {
            StopButton.IsEnabled = true;
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
            
            if (!Login())
            {
                MessageBox.Show("Đăng nhập không thành công!");
                return;
            }
            else
            {
                await Task.Delay(4000);
                _timer.Start();

                if (listFunc[2])
                {
                    await  _selenium.RunBuff(UserNameDest.Text, listFunc, comment);
                }
                else 
                    await  _selenium.RunBuff(UserNameDest.Text, listFunc);
                _selenium.Stop();
            }
            
            StopButton.IsEnabled = false;
            _timer.Stop();
            
        }
        
        private void StopButton_OnClick(object sender, RoutedEventArgs e)
        {
            _cancellationTokenSource?.Cancel();
            _selenium.Stop();
            _timer.Stop();
        }
        
        private void RunCrawlerButton_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (var child in CrawlerCheckList.Children)
            {
                if (child is CheckBox cb)
                {
                    if (cb.IsChecked != null && (bool)cb.IsChecked)
                    {
                        Console.WriteLine(cb.Content);
                    }
                }
            }
        }

    }
}