using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace ProcessComunication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        String fileName = "test.txt";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btCreate_Click(object sender, RoutedEventArgs e)
        {
            Process process = Process.Start("C:Users/Davis/Desktop/Repositorios/comunicacion-entre-procesos-2-davisbd100/ProcessComunication/ProcessComunication/bin/Debug/ProcessComunication.exe");
        }

        private void btSend_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (FileStream fs = File.Create(fileName))
            {
                byte[] text = new UTF8Encoding(true).GetBytes(tbSend.Text);
                fs.Write(text, 0, text.Length);
            }
            tbSend.Text = "";
        }

        private void btRead_Click(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    tblRead.Text = s;
                }
            }
        }
    }
}
