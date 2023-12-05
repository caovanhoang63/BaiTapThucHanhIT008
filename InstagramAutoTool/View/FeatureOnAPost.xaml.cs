using System.Windows.Controls;

namespace InstagramAutoTool.View
{
    public partial class FeatureOnAPost : Page
    {
        private MainWindow _mainWindow;
        public FeatureOnAPost(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }
    }
}