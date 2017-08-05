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
using System.Windows.Shapes;

namespace chatApplication_Client
{
    /// <summary>
    /// Interaction logic for SignupWindow.xaml
    /// </summary>
    public partial class SignupWindow : Window
    {
        public SignupWindow()
        {
            InitializeComponent();
        }

        private void Signup_Click(object sender, RoutedEventArgs e)
        {
            if (usernameText.Text.Length == 0 || userPasswordText.Text.Length == 0 || firstNameText.Text.Length == 0
                || lastNameText.Text.Length == 0 || emailText.Text.Length == 0)
            {
                MessageBox.Show("All fields must be filled in order to register");
                return;
            }
        }
    }
}
