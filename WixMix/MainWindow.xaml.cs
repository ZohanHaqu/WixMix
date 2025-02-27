using System;
using System.IO;
using System.Windows;

namespace WixMix
{
    public partial class MainWindow : Window
    {
        private string currentFilePath;

        public MainWindow()
        {
            InitializeComponent();
        }

        // New File
        private void NewFile_Click(object sender, RoutedEventArgs e)
        {
            WixTextBox.Clear();
            currentFilePath = null;
        }

        // Open File
        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            var openDialog = new Microsoft.Win32.OpenFileDialog();
            openDialog.Filter = "Wix Files (*.wxs)|*.wxs|All Files (*.*)|*.*";
            if (openDialog.ShowDialog() == true)
            {
                currentFilePath = openDialog.FileName;
                WixTextBox.Text = File.ReadAllText(currentFilePath);
            }
        }

        // Save File
        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                SaveAsFile_Click(sender, e);
            }
            else
            {
                File.WriteAllText(currentFilePath, WixTextBox.Text);
            }
        }

        // Save As File
        private void SaveAsFile_Click(object sender, RoutedEventArgs e)
        {
            var saveDialog = new Microsoft.Win32.SaveFileDialog();
            saveDialog.Filter = "Wix Files (*.wxs)|*.wxs|All Files (*.*)|*.*";
            if (saveDialog.ShowDialog() == true)
            {
                currentFilePath = saveDialog.FileName;
                File.WriteAllText(currentFilePath, WixTextBox.Text);
            }
        }

        // Exit Application
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Edit Actions
        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            if (WixTextBox.CanUndo)
                WixTextBox.Undo();
        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {
            if (WixTextBox.CanRedo)
                WixTextBox.Redo();
        }

        private void Cut_Click(object sender, RoutedEventArgs e)
        {
            WixTextBox.Cut();
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            WixTextBox.Copy();
        }

        private void Paste_Click(object sender, RoutedEventArgs e)
        {
            WixTextBox.Paste();
        }

        // Zoom In / Zoom Out
        private void ZoomIn_Click(object sender, RoutedEventArgs e)
        {
            WixTextBox.FontSize += 2;
        }

        private void ZoomOut_Click(object sender, RoutedEventArgs e)
        {
            WixTextBox.FontSize -= 2;
        }

        // About Dialog
        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("WixMix IDE\nVersion 1.0\nA basic Wix Toolset editor.", "About WixMix", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
