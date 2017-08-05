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

namespace chatApplication_Client
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

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if(userNameText.Text.Length == 0 || userNamePassword.Text.Length == 0)
            {
                MessageBox.Show("user name and password cant be empty");
                return;
            }
        }

        private void Signup_Click(object sender, RoutedEventArgs e)
        {
            var signUpWindow = new SignupWindow();
            signUpWindow.ShowDialog(); 
        }
    }
}
