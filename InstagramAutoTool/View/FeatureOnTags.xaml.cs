using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using CheckBox = System.Windows.Controls.CheckBox;
using MessageBox = System.Windows.MessageBox;

namespace InstagramAutoTool.View
{
    public partial class FeatureOnTags : Page
    {
        private MainWindow _mainWindow;

        public FeatureOnTags(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }
        private async void RunCrawlerButton_OnClick(object sender, RoutedEventArgs e)
        {

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            var result = folderBrowserDialog.ShowDialog();

            if (result != System.Windows.Forms.DialogResult.OK)
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
                    await _mainWindow.Selenium.RunCrawByHashTag(UserNameDest.Text, listFunc, folderPath);
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