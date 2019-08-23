using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using UWP_Maths_Quiz_New.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP_MyCTU_Maths_Quiz
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        Database db;

        public LoginPage()
        {
            this.InitializeComponent();
            db = new Database();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (VerifyInput())
            {
                var message = new MessageDialog("Please enter your username and password.");
                await message.ShowAsync();
            }
            else
            {
                if (db.Login(txtUser.Text, txtPassword.Password))
                {
                    var message = new MessageDialog("Login Success!");
                    await message.ShowAsync();
                    Frame.Navigate(typeof(OptionsPage));
                }
                else
                {
                    var message = new MessageDialog("Login Failed!");
                    await message.ShowAsync();
                    Frame.Navigate(typeof(RegisterPage));
                }
            }
        }

        private bool VerifyInput()
        {
            bool isUserEmpty = String.IsNullOrEmpty(txtUser.Text);
            bool isPasswordEmpty = String.IsNullOrEmpty(txtPassword.Password);

            if (isUserEmpty || isPasswordEmpty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegisterPage));
        }
    }
}
