using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace HuffmanV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBrowseFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Display expected extension(default) and filter for those file types
            dlg.DefaultExt = ".c";
            dlg.Filter = "C Files |*.c|All Files |*.*";

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                //Open document
                string filename = dlg.FileName;
                txtFilePathName.Text = filename;
                
            }
        }

        private void btnLoadFile_Click(object sender, RoutedEventArgs e)
        {
            //load file as string using ASCII encoding into dataFull
            StreamReader sr = new StreamReader(txtFilePathName.Text, Encoding.ASCII);
            string dataFull = sr.ReadToEnd();
            //release file
            sr.Close(); 
            //show file contents in text box
            //txtFilePreview.Text = dataFull;

            int start = dataFull.IndexOf("{");
            int end = dataFull.IndexOf("}");
            dataFull = dataFull.Substring(start +1, end - start - 2).Trim();
            
            //show in text AFTER clearing out the garbage
            txtFilePreview.Text = dataFull;
            
            //split by ',' to an int array and clean up whitespace and /n/r
            int[] dataSplit = dataFull.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(a => Convert.ToInt32(a)).ToArray();

            List<int> dataListSorted = dataSplit.OfType<int>().ToList();
            dataListSorted.Sort();
                        
            //add to listbox
            foreach (int data in dataListSorted)
            {
                lstData.Items.Add(data);
            }

            


        }

    }
}

public class Values
{
    public int Position;
    public int Value;
    public int Count;
}