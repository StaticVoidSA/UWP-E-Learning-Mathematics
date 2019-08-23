using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWP_Maths_Quiz_New.Models;
using UWP_MyCTU_Maths_Quiz;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_Maths_Quiz_New
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Database db;

        public MainPage()
        {
            this.InitializeComponent();
            db = new Database();

            // Add Microsoft ads page to the main page
            MyAdsFrame.Navigate(typeof(MicrosoftAdPage));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void RegisterLoginButton_Click(object sender, RoutedEventArgs e)
        {
            //MySplitView.IsPaneOpen = false;
            MyMainFrame.Navigate(typeof(LoginPage));
            WelcomeMainTextBlock.Text = "";
            WelcomeTextBlock.Text = "";
        }

        private void InformationButton_Click(object sender, RoutedEventArgs e)
        {
            //MySplitView.IsPaneOpen = false;
            MyMainFrame.Navigate(typeof(HomePage));
            WelcomeTextBlock.Text = "";
            WelcomeMainTextBlock.Text = "";
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
    }
}
