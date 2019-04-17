using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MemoryGame
{
    public partial class MainPage : ContentPage
    {
          
        Random random = new Random();
        int timeEllapsed = 1;
        

        public void loadImages(List<Image> animalList)
        {
            animalList.Add(new Image { Source = "Animals/panda.png" });
            animalList.Add(new Image { Source = "Animals/sea-lion.png" });
            animalList.Add(new Image { Source = "Animals/lion.png" });
            animalList.Add(new Image { Source = "Animals/snow-leopard.png" });
            animalList.Add(new Image { Source = "Animals/penguin.png" });
            animalList.Add(new Image { Source = "Animals/raccoon.png" });
            animalList.Add(new Image { Source = "Animals/tiger.png" });
            animalList.Add(new Image { Source = "Animals/lemur.png" });

            animalList.Add(new Image { Source = "Animals/panda.png" });
            animalList.Add(new Image { Source = "Animals/sea-lion.png" });
            animalList.Add(new Image { Source = "Animals/lion.png" });
            animalList.Add(new Image { Source = "Animals/snow-leopard.png" });
            animalList.Add(new Image { Source = "Animals/penguin.png" });
            animalList.Add(new Image { Source = "Animals/raccoon.png" });
            animalList.Add(new Image { Source = "Animals/tiger.png" });
            animalList.Add(new Image { Source = "Animals/lemur.png" });
        }


        public MainPage()
        {
            InitializeComponent();
            createGrid();
            startTimer();
        }
        public void createGrid()
        {
            //List<Image> animalList = new List<Image>();
            List<Image> animalList = new List<Image>();
            loadImages(animalList);
            for (int i = 0; i < 4; i++)
            {
                gameGrid.RowDefinitions.Add(new RowDefinition());
                gameGrid.ColumnDefinitions.Add(new ColumnDefinition());
                gameGrid.BackgroundColor = Color.Blue;

                for (int j = 0; j < 4; j++)           
                {

                    StackLayout sp = new StackLayout { Padding = new Thickness(5, 10) };

                    int randomNumber = random.Next(animalList.Count);
                                       
                    sp.WidthRequest = 500;
                    sp.HeightRequest = 500;
                    sp.HorizontalOptions = LayoutOptions.Fill;
                    sp.VerticalOptions = LayoutOptions.Fill;

                    sp.Children.Add(animalList[randomNumber]);
                    animalList.RemoveAt(randomNumber);

                    gameGrid.Children.Add(sp);
                    

                    Grid.SetRow(sp, i);
                    Grid.SetColumn(sp, j);
                    Thread.Sleep(50);

                }
            }
        }
        public bool game = true;

        public void startTimer()
        {        
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                labelVar.Text = "Timer: " + timeEllapsed;
                timeEllapsed++;

                return game; // return true to repeat counting, false to stop timer
            });


            labelVar.TextColor = Color.FromHex("#77d065");
            labelVar.FontSize = 20;
    
        }

    }
}
