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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP_MyCTU_Maths_Quiz
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OptionsPage : Page
    {
        public OptionsPage()
        {
            this.InitializeComponent();
        }

        private void Grade4Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Grade4Page));
        }

        private void Grade3Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Grade3Page));
        }

        private void Grade2Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Grade2Page));
        }

        private void Grade1Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Grade1Page));
        }
    }
}
