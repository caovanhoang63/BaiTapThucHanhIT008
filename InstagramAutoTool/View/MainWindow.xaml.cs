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
        
        public MainWindow()
        {
            InitializeComponent();
            _cancellationTokenSource = new CancellationTokenSource();
            
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

        public Selenium Selenium => _selenium;

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
    }
}