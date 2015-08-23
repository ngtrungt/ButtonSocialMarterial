using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ButtonSocialMarterial.Resources;

namespace ButtonSocialMarterial
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private bool _isOpen;
        private void BtnSocial_OnClick(object sender, RoutedEventArgs e)
        {
            if (!_isOpen)
            {
                GridWarnStoryboard.Begin();
                GridWarnStoryboard.Completed += GridWarnStoryboard_Completed;
                GridSocicalChild.Visibility = Visibility.Visible;
                ImgSocial.Source = new BitmapImage(new Uri("Assets/close.png", UriKind.Relative));
                _isOpen = true;
            }
            else
            {
                SetOpacity();
                GridSocicalChild.Visibility = Visibility.Collapsed;
                ImgSocial.Source = new BitmapImage(new Uri("Assets/social.png", UriKind.Relative));
                _isOpen = false;
            }
        }

        void SetOpacity()
        {
            GridWarn.Opacity = 0;
            GridShare.Opacity = 0;
            GridCall.Opacity = 0;
            GridMsg.Opacity = 0;
            GridWarnStoryboard.Stop();
            GridShareStoryboard.Stop();
            GridCallStoryboard.Stop();
            GridMsgStoryboard.Stop();
        }

        void GridWarnStoryboard_Completed(object sender, EventArgs e)
        {
            GridShareStoryboard.Begin();
            GridShareStoryboard.Completed += GridShareStoryboard_Completed;
        }

        void GridShareStoryboard_Completed(object sender, EventArgs e)
        {
            GridCallStoryboard.Begin();
            GridCallStoryboard.Completed += GridCallStoryboard_Completed;
        }

        void GridCallStoryboard_Completed(object sender, EventArgs e)
        {
            GridMsgStoryboard.Begin();
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}