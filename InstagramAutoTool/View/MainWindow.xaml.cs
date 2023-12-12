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
using System.Windows.Forms;
using System.Windows.Threading;
using InstagramAutoTool.Model;
using Microsoft.Win32;
using CheckBox = System.Windows.Controls.CheckBox;
using MessageBox = System.Windows.MessageBox;

namespace InstagramAutoTool.View
{
    public partial class MainWindow : Window
    {

        private Selenium _selenium;
        private CancellationTokenSource _cancellationTokenSource;
        private DispatcherTimer _timer;
        
        private FeatureOnUser _userPage;
        private FeatureOnAPost _postPage;
        private FeatureOnTags _tagsPage;
        private List<Pair<string, string>> _listAccount;
        public Selenium Selenium => _selenium;

        
        public MainWindow()
        {
            InitializeComponent();
            _cancellationTokenSource = new CancellationTokenSource();
            _listAccount = new List<Pair<string, string>>();
            
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1),
            };
            _timer.Tick += TimerOnTick;

            _userPage = new FeatureOnUser(this);
            _postPage = new FeatureOnAPost(this);
            _tagsPage = new FeatureOnTags(this);
            
            FeatureFrame.Navigate(_userPage);

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

        public bool Login()
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
        
        
        
        
        private void StopButton_OnClick(object sender, RoutedEventArgs e)
        {
            _cancellationTokenSource?.Cancel();
            _selenium.Stop();
            _timer.Stop();
        }

        private void UserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void userListBoxItem_OnSelected(object sender, RoutedEventArgs e)
        {
            try
            {
                FeatureFrame.Navigate(_userPage);

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }


        private void tagsListBoxItem_OnSelected(object sender, RoutedEventArgs e)
        {
            FeatureFrame.Navigate(_tagsPage);

        }

        private void postListBoxItem_OnSelected(object sender, RoutedEventArgs e)
        {
            FeatureFrame.Navigate(_postPage);
        }

        private void MultiAccount_OnChecked(object sender, RoutedEventArgs e)
        {
            UserName.IsEnabled = false;
            Password.IsEnabled = false;
            ImportTextDialog dialog = new ImportTextDialog();
            if (dialog.ShowDialog() != true)
            {
                UserName.IsEnabled = true;
                Password.IsEnabled = true;
                MultiAccount.IsChecked = false;
                return;
            }

            foreach (var line in dialog.Lines)
            {
                string[] acount = line.Trim().Split(' ');
                if (acount.Length != 2)
                {
                    MessageBox.Show("Nhập tài khoản không đúng định dạng");
                    return;
                }
                _listAccount.Add(new Pair<string, string>(acount[0],acount[1]));
            }

            foreach (var account in _listAccount)
            {
                Console.WriteLine(account.First + " "+ account.Second);
            }
        }

        private void MultiAccount_OnUnChecked(object sender, RoutedEventArgs e)
        {
            UserName.IsEnabled = true;
            Password.IsEnabled = true;
        }
    }
}