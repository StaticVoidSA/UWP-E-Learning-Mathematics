using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWP_Maths_Quiz_New.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP_MyCTU_Maths_Quiz
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterPage : Page
    {
        Database db;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            SystemNavigationManager.GetForCurrentView().BackRequested += RegisterPage_BackRequested;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            SystemNavigationManager.GetForCurrentView().BackRequested -= RegisterPage_BackRequested;
        }

        private void RegisterPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        public RegisterPage()
        {
            this.InitializeComponent();
            db = new Database();
        }


        private void RegisterBackButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginPage));
        }

        private async void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            if (VerifyInput())
            {
                var message = new MessageDialog("Please enter a user name and password");
                await message.ShowAsync();
            }
            else
            {
                // TODO: Submit new user
                int code = db.Register(new User()
                {
                    UserName = txtUser.Text.Trim(),
                    Password = txtPassword.Password
                });

                if (code == -1)
                {
                    var message = new MessageDialog("Register Failed!");
                    await message.ShowAsync();
                    Frame.Navigate(typeof(HomePage));
                }
                else
                {
                    var message = new MessageDialog("Register Success!");
                    await message.ShowAsync();
                    Frame.Navigate(typeof(LoginPage));
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
    }
}
