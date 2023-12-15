using System;
using System.Collections.Generic;
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
    public partial class FeatureOnTags : Page
    {
        private MainWindow _mainWindow;
        private List<string> _listHashTags;
        
        
        public FeatureOnTags(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _listHashTags = new List<string>();
        }

        private async void RunCrawlerButton_OnClick(object sender, RoutedEventArgs e)
        {
            
            if (!_mainWindow.CheckHaveUserAccount())
            {
                MessageBox.Show("Vui lòng nhập tài khoản của bạn");
                return;
            }
            
            if (!CheckHaveHashTag())
            {
                MessageBox.Show("Vui lòng nhập các hashtag cần craw");
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
            bool[] listFunc = { false, false,false };
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
                    if (cb.Name == "DownloadDescription")
                        listFunc[2] = true;
                }
            }

            if (!listFunc.Contains(true))
            {
                MessageBox.Show("Vui lòng chọn chức năng");
                return;
            }

            if (!_mainWindow.Login())
            {
                MessageBox.Show("Đang nhập thất bại");
                return;
            }
            
            await Task.Delay(4000);

            try
            {
                int limit = 0;
                if (PostNum.IsEnabled)
                    limit = int.Parse(PostNum.Text);
                else
                    limit = -1; 
                await _mainWindow.Selenium.RunCrawByHashTag(_listHashTags, limit,listFunc, folderPath);
                
                
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            _mainWindow.Selenium.Stop();
            _mainWindow.StopButton.IsEnabled = false;
            
        }



        private FlowDocument _document;
        private void MultiHashTagToggleButton_OnUnchecked(object sender, RoutedEventArgs e)
        {
            _listHashTags.Clear();
            HashTagTextBox.IsEnabled = true;
        }

        private void MultiHashTagToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            _listHashTags.Clear();
            ImportTextDialog dialog = new ImportTextDialog();
            //check for dialog is opened before
            if (_document != null)
            {
                //create with cache
                dialog = new ImportTextDialog(_document);
            }
            else
            {
                //If the dialog box hasn't been opened before, create a new dialog box
                dialog = new ImportTextDialog();
            }

            if (dialog.ShowDialog() != true)
            {
                MultiHashTagToggleButton.IsChecked = false;
                return;
            }

            foreach (var line in dialog.Lines)
            {
                _listHashTags.Add(line.Trim());
            }

            HashTagTextBox.IsEnabled = false;
            
            //cache text in richtextbox of dialog
            _document = dialog.Document;
        }
        
        
        
        //Limit number of post needs to craw
        private void UnlimitedPostNum_OnChecked(object sender, RoutedEventArgs e)
        {
            PostNum.IsEnabled = false;
        }

        private void UnlimitedPostNum_UnChecked(object sender, RoutedEventArgs e)
        {
            PostNum.IsEnabled =true;
        }
        
        
        private bool CheckHaveHashTag()
        {
            if (HashTagTextBox.Text == String.Empty && _listHashTags.Count == 0  )
                return false;
            if (MultiHashTagToggleButton.IsChecked != true) 
            {
                _listHashTags.Add(HashTagTextBox.Text);
            }
            Console.WriteLine(_listHashTags[0]);
            return true;
        }




    }
}