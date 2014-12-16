using Microsoft.Win32;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BA_ImageToByteArray
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

        private string LoadFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            string path = String.Empty;

            if (ofd.ShowDialog().Value)
            {
                path = ofd.FileName;
            }

            return path;
        }

        private byte[] GetPhoto(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] data = new byte[fs.Length];

            fs.Read(data, 0, (int)fs.Length);
            fs.Close();

            return data;
        }

        private string ByteArrayToString(string path)
        {
            byte[] bytes = GetPhoto(path);
            string result = "0x";

            result += BitConverter.ToString(bytes).Replace("-", String.Empty);

            return result;
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            string path = LoadFile();

            txbPath.Text = path;

            if (!path.Equals(String.Empty))
            {
                txtOutput.Text = ByteArrayToString(path);
            }
        }
    }
}
