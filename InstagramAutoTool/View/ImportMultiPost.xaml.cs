using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace InstagramAutoTool.View
{
    /// <summary>
    /// Interaction logic for ImportMultiPost.xaml
    /// </summary>
    public partial class ImportMultiPost : Window
    {
        private FlowDocument _document = null;
        private string[] _lines;
        public string[] Lines => _lines;
        public ImportMultiPost()
        {
            InitializeComponent();
        }
        public ImportMultiPost(FlowDocument document)
        {
            InitializeComponent();
            _document = document;
        }


        public FlowDocument Document
        {
            get
            {
                return RichTextBox.Document;
            }
            set
            {
                RichTextBox.Document = value;
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            string richText = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd).Text;
            _lines = richText.Trim().Split('\n');
            if (richText.Length <= 2)
            {
                MessageBox.Show("Vui lòng nhập link post");

            }
            MessageBox.Show(richText);
            DialogResult = true;

        }

        private void Import_OnClick(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "File|*.txt;...";
            {
                if (openFileDialog.CheckPathExists)
                {
                    RichTextBox.Document.Blocks.Clear();
                    using (StreamReader streamReader = new StreamReader(openFileDialog.FileName))
                    {
                        string line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            RichTextBox.Document.Blocks.Add(new Paragraph(new Run(line)));
                        }
                    }
                }
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (_document != null)
            {
                string richText = new TextRange(_document.ContentStart, _document.ContentEnd).Text;
                RichTextBox.Selection.Text = richText;
            }
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
