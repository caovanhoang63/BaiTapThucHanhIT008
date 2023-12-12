using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using Microsoft.Win32;

namespace InstagramAutoTool.View
{
    public partial class ImportTextDialog : Window
    {
        private string[] _lines;

        public string[] Lines => _lines;
        
        public ImportTextDialog()
        {
            InitializeComponent();
        }
        
        
        

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            string richText = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd).Text;

            _lines =  richText.Trim().Split('\n');
            
            DialogResult = true;
        }


        private void Import_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
                
            openFileDialog.Filter = "File|*.txt;...";
            if (openFileDialog.ShowDialog() == true)
            {
                if (openFileDialog.CheckPathExists)
                {
                    using (StreamReader streamReader = new StreamReader(openFileDialog.FileName))
                    {
                        string line;
                        while ( (line =  streamReader.ReadLine()) != null)
                        {
                            RichTextBox.Document.Blocks.Add( new Paragraph(new Run(line)));
                        }
                    }
                }
            }

        }
    }
}