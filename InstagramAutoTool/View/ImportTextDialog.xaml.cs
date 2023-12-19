using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using InstagramAutoTool.Model;
using Microsoft.Win32;

namespace InstagramAutoTool.View
{
    public partial class ImportTextDialog : Window
    {
        private string[] _lines;
        private FlowDocument _document = null;
        public string[] Lines => _lines;
        

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

        public ImportTextDialog()
        {
            InitializeComponent();
        }
        public ImportTextDialog(FlowDocument document)
        {
            InitializeComponent();
            _document = document;
        }
        
        
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            string richText = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd).Text;

            _lines = richText.Trim().Split('\n');
            
            DialogResult = true;
        }


        private void Import_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "File|*.txt;...";
            if (openFileDialog.ShowDialog() != true)
                return;

            if (!openFileDialog.CheckPathExists)
                return;
            
            RichTextBox.Document.Blocks.Clear();
            using (StreamReader streamReader = new StreamReader(openFileDialog.FileName))
            {
                string line;
                while ( (line =  streamReader.ReadLine()) != null)
                {
                    RichTextBox.Document.Blocks.Add( new Paragraph(new Run(line)));
                }
            }
        }


        private void ImportTextDialog_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (_document != null)
            {
                string richText = new TextRange(_document.ContentStart, _document.ContentEnd).Text;
                RichTextBox.Selection.Text = richText;
            }
        }
    }
}