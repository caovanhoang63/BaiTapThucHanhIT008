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
using RichTextBox = System.Windows.Forms.RichTextBox;

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
        public List<Pair<string, string>> ListAccount => _listAccount;
        
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

        public bool Login(string username = null,string password = null)
        {
            try
            {
                _selenium = new Selenium(_cancellationTokenSource);
                if (username == null)
                {
                    _selenium.Login(_listAccount[0].First,_listAccount[0].Second);
                }
                else 
                    _selenium.Login(username,password);
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

        private FlowDocument _document;
        
        private void MultiAccount_OnChecked(object sender, RoutedEventArgs e)
        {
            UserName.IsEnabled = false;
            Password.IsEnabled = false;

            ImportTextDialog dialog;
            
            
            if (_document != null)
            {
                dialog = new ImportTextDialog(_document);
            }
            else
            {
                dialog = new ImportTextDialog();
            }
            
            if (dialog.ShowDialog() != true)
            {
                UserName.IsEnabled = true;
                Password.IsEnabled = true;
                MultiAccount.IsChecked = false;
                return;
            }
            _listAccount.Clear();
            foreach (var line in dialog.Lines)
            {
                string[] acount = line.Trim().Split(' ');
                if (acount.Length != 2)
                {
                    MessageBox.Show("Nhập tài khoản không đúng định dạng");
                    UserName.IsEnabled = true;
                    Password.IsEnabled = true;
                    MultiAccount.IsChecked = false;
                    return;
                }
                _listAccount.Add(new Pair<string, string>(acount[0],acount[1]));
            }

            _document = dialog.Document;
        }

        private void MultiAccount_OnUnChecked(object sender, RoutedEventArgs e)
        {
            UserName.IsEnabled = true;
            Password.IsEnabled = true;
            _listAccount.Clear();
        }

        public bool CheckHaveUserAccount()
        {
            if (UserName.Text == String.Empty && _listAccount.Count == 0  )
                return false;
            if (MultiAccount.IsChecked != true) 
            {
                _listAccount.Add(new Pair<string, string>(UserName.Text,Password.Password));
            }
            return true;
        }
    }
}