using System;
using Microsoft.Phone.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Sudoku_Solver.Resources;
using ImageTools.IO.Gif;
using ImageTools;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using System.IO;
using System.Windows.Resources;
namespace Sudoku_Solver
{
  
    public partial class MainPage : PhoneApplicationPage
    {   
        // Constructor
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Ghost_Background.Play();
            Ghost2.Opacity = 0;
            Ghost2.Visibility = Visibility.Collapsed;
        }
        
       
        public MainPage()
        {
            InitializeComponent();
          // Sample code to localize the ApplicationBar
          // BuildLocalizedApplicationBar();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Ghost2.Visibility = Visibility.Visible;
            Ghost_Background.Pause();
            Ghost2_Ef.Begin();
            Ghost_Sound.Stop();
            Ghost_Sound.Play();
        
        }

      
    

    private void Exit_button_clicked(object sender, EventArgs e)
        {
            Application.Current.Terminate();
        }

        private async void Like_Button_Clicked(object sender, EventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-windows-store:reviewapp?appid=" + Windows.ApplicationModel.Package.Current.Id.Name));
        }

      private void Ghost_Background_MediaEnded(object sender, RoutedEventArgs e)
        {
           Ghost_Background.Play();
       }

       

      
        
        private void Ghost_Sound_Ef_Completed(object sender, EventArgs e)
        {
            Ghost_Sound_Ef_2.Begin();
        }

        private void Ghost_Sound_Ef_2_Completed(object sender, EventArgs e)
        {
            Ghost_Background.Play();
        }

        private void Ghost2_Ef_Completed(object sender, EventArgs e)
        {
            Ghost_Background.Stop();
            Ghost_Sound.Stop();
            NavigationService.Navigate(new Uri("/SolvePage.xaml", UriKind.Relative));
        }

        private void OK_Button_Click(object sender, RoutedEventArgs e)
        {
            Button_Clicked_Sound.Stop();
            Button_Clicked_Sound.Play();
            About_Ef_Out.Begin();
            
        }
  
        private void About_Ef_Out_Completed(object sender, EventArgs e)
        {
            About_Grid.Visibility = Visibility.Collapsed;
        }

        private void About_Button_Click(object sender, RoutedEventArgs e)
        {
            Ghost_Background.Pause();
            Button_Clicked_Sound.Stop();
            Button_Clicked_Sound.Play();
            About_Grid.Visibility = Visibility.Visible;
            About_Ef_In.Begin();
        }

        public WebBrowserTask TATWeb = new WebBrowserTask();

        private void Visit_Button_Click(object sender, RoutedEventArgs e)
        {
            TATWeb.Uri = new Uri("https://www.facebook.com/TrollAndroidTeam", UriKind.Absolute);
            TATWeb.Show();

        }

        private void Ghost1_ManipulationStarted(object sender, System.Windows.Input.ManipulationStartedEventArgs e)
        {
            Ghost_Sound.Stop();
            Ghost_Sound.Play();
            Ghost_Sound_Ef.Begin();
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