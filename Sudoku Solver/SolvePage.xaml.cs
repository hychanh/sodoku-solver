using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using ImageTools.IO.Gif;
using ImageTools;
using Microsoft.Phone.Tasks;
using Sudoku_Solver.Resources;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using System.IO;
using System.Windows.Resources;

namespace Sudoku_Solver
{
    public partial class SolvePage : PhoneApplicationPage
    {
       public int[,] ArrayA= new int[10,10];
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Background_Sound.Stop();
            Background_Sound.Play();
        }
      public SolvePage()
        {
            InitializeComponent();
            Processing.Visibility = Visibility.Collapsed;
            ButtonToArray();            
        }
      
        //Colors building
        private SolidColorBrush BlackBrush = new SolidColorBrush(Colors.Black);
        private SolidColorBrush RedBrush = new SolidColorBrush(Colors.Red);
        private SolidColorBrush WhiteBrush = new SolidColorBrush(Colors.White);
        private SolidColorBrush TransBrush = new SolidColorBrush(Colors.Transparent);
        private SolidColorBrush BlueBrush = new SolidColorBrush(Colors.Blue);
        private SolidColorBrush GrayBrush = new SolidColorBrush(Colors.DarkGray);
        private SolidColorBrush GreenBrush = new SolidColorBrush(Colors.Green);
        private void Cell_click(object sender, RoutedEventArgs e)
        {
            
            if (SelectedNum == 0)
            {
                string Temp1 = (sender as Button).Name.ToString();

                Temp1 = Temp1.Remove(0, 4);

                string Temp2 = Temp1.Remove(0, 2);
                Temp1 = Temp1.Remove(1, 2);

                int k = Int32.Parse((sender as Button).Content.ToString()) + 1;
                int i = Int32.Parse(Temp1);
                int j = Int32.Parse(Temp2);
                ArrayA[i,j] =0;
                (sender as Button).Content = "0";
                (sender as Button).Background = TransBrush;
            }
            else
            {
                string Temp1 = (sender as Button).Name.ToString();
              
                 Temp1=Temp1.Remove(0, 4);
                 
                 string Temp2 = Temp1.Remove(0, 2);
                 Temp1= Temp1.Remove(1, 2);

                int k = SelectedNum;
                 int i = Int32.Parse(Temp1);
                 int j = Int32.Parse(Temp2);

                      if (ArrayTest(i, j, k))
                         {
                            
                            ArrayA[i, j] = k;
                            (sender as Button).Content = (k.ToString());
                            (sender as Button).Background = GrayBrush;
                            Status_Text.Text = "";
                }
                        else
                         {
                         Status_Text.Foreground = RedBrush;
                         Status_Text.Text = "ERROR NUMBER";
                        }
                      
            }
            
        }

      

        private void Clean_Button_Click(object sender, RoutedEventArgs e)
        {
            ButtonClean();
            Status_Text.Foreground=WhiteBrush;
            Status_Text.Text = "Insert a number";
        }

        int SelectedNum = 0;
        private async void Solve_clicked(object sender, RoutedEventArgs e)
        {
          
            Build();
            if (M == 81) Status_Text.Text = "Cells are empty!";
            else
            {
                ImageTools.IO.Decoders.AddDecoder<GifDecoder>();
                Processing.Source = new ExtendedImage() { UriSource = new Uri("/Pics/Processing.gif", UriKind.Relative) };
                Processing.Visibility = Visibility.Visible;
                Processing.Start();
                Clean_Button.Visibility = Visibility.Collapsed;
                NumBar.Visibility = Visibility.Collapsed;
                Solve_Button.Visibility = Visibility.Collapsed;
                await System.Threading.Tasks.Task.Delay(1000);
                Solve();
                Processing.Stop();
                Processing.Visibility = Visibility.Collapsed;
                Status_Text.Foreground = GreenBrush;
                Status_Text.Text = "COMPLETED !";
                
            }

        }
        private void NumButRemoveBackground()
        {
            Num0_Button.Background = TransBrush;
            Num1_Button.Background = TransBrush;
            Num2_Button.Background = TransBrush;
            Num3_Button.Background = TransBrush;
            Num4_Button.Background = TransBrush;
            Num5_Button.Background = TransBrush;
            Num6_Button.Background = TransBrush;
            Num7_Button.Background = TransBrush;
            Num8_Button.Background = TransBrush;
            Num9_Button.Background = TransBrush;
        }
            private void NumBut_click(object sender, RoutedEventArgs e)
        {
           
            string Temp = (sender as Button).Content.ToString();
            SelectedNum = Int32.Parse(Temp);
            NumButRemoveBackground();
            (sender as Button).Background = BlueBrush;
        }

        private void Reset_Button_Click(object sender, EventArgs e)
        {
       
            ButtonClean();
            Processing.Visibility = Visibility.Collapsed;
            Solve_Button.Visibility = Visibility.Visible;
            NumBar.Visibility = Visibility.Visible;
            Clean_Button.Visibility = Visibility.Visible;
            Status_Text.Foreground = WhiteBrush;
            Status_Text.Text = "Insert a number";
          
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            if (this.NavigationService.CanGoBack) NavigationService.GoBack();
        }

     
        private void Snowdream_MediaEnded(object sender, RoutedEventArgs e)
        {
            Background_Sound.Play();
        }

      
    }
}