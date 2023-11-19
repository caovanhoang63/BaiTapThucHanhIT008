using System;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Windows;

namespace InstagramAutoTool.View
{
    public partial class CommentInputDialog : Window
    {
        public CommentInputDialog()
        {
            InitializeComponent();
            _comment = String.Empty;
            _accept = false;
        }

        private string _comment;
        private bool _accept;
        public string Comment => _comment;
        public bool Accept => _accept;
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            _comment = CommentTextBox.Text;
            if (_comment.Trim() == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập bình luận");
                return;
            }

            _accept = true;
            DialogResult = true;
        }

        private void CommentInputDialog_OnClosing(object sender, CancelEventArgs e)
        {
            DialogResult = false;
        }
    }
}