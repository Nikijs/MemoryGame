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
        private AnimalObject animal1;
        private AnimalObject animal2;

        //load images function, list of animal objects containing its image source and name
        public void loadImages(List<AnimalObject> animalList)
        {
            animalList.Add(new AnimalObject(new Image { Source = "Animals/panda.png", IsVisible = false }, "panda"));
            animalList.Add(new AnimalObject(new Image { Source = "Animals/sea-lion.png", IsVisible = false }, "sea-lion"));
            animalList.Add(new AnimalObject(new Image { Source = "Animals/lion.png", IsVisible = false }, "lion"));
            animalList.Add(new AnimalObject(new Image { Source = "Animals/snow-leopard.png", IsVisible = false }, "snow-leopard"));
            animalList.Add(new AnimalObject(new Image { Source = "Animals/penguin.png", IsVisible = false}, "penguin"));
            animalList.Add(new AnimalObject(new Image { Source = "Animals/raccoon.png", IsVisible = false }, "raccoon"));
            animalList.Add(new AnimalObject(new Image { Source = "Animals/tiger.png", IsVisible = false }, "tiger"));
            animalList.Add(new AnimalObject(new Image { Source = "Animals/lemur.png", IsVisible = false }, "lemur"));

            animalList.Add(new AnimalObject(new Image { Source = "Animals/panda.png", IsVisible = false }, "panda"));
            animalList.Add(new AnimalObject(new Image { Source = "Animals/sea-lion.png", IsVisible = false }, "sea-lion"));
            animalList.Add(new AnimalObject(new Image { Source = "Animals/lion.png", IsVisible = false }, "lion"));
            animalList.Add(new AnimalObject(new Image { Source = "Animals/snow-leopard.png", IsVisible = false }, "snow-leopard"));
            animalList.Add(new AnimalObject(new Image { Source = "Animals/penguin.png", IsVisible = false }, "penguin"));
            animalList.Add(new AnimalObject(new Image { Source = "Animals/raccoon.png", IsVisible = false }, "raccoon"));
            animalList.Add(new AnimalObject(new Image { Source = "Animals/tiger.png", IsVisible = false }, "tiger"));
            animalList.Add(new AnimalObject(new Image { Source = "Animals/lemur.png", IsVisible = false }, "lemur"));
        }


        public MainPage()
        {
            InitializeComponent();
            createGrid();
            
        }
        //create grid function called at app start up
        public void createGrid()
        {
            //create animal object and pupulate calling the fuction 
            List<AnimalObject> animalList = new List<AnimalObject>();
            loadImages(animalList);
            //creating rows and cols for grid
            for (int i = 0; i < 4; i++)
            {
                gameGrid.RowDefinitions.Add(new RowDefinition());
                gameGrid.ColumnDefinitions.Add(new ColumnDefinition());
                gameGrid.BackgroundColor = Color.Blue;

                for (int j = 0; j < 4; j++)
                {

                    StackLayout sp = new StackLayout { Padding = new Thickness(10, 20) };
                    //counts the number of animals in the list and then randomises 
                    int randomNumber = random.Next(animalList.Count);

                    sp.WidthRequest = 500;
                    sp.HeightRequest = 500;
                    sp.HorizontalOptions = LayoutOptions.Fill;
                    sp.VerticalOptions = LayoutOptions.Fill;

                    var hide = new Image { Source = "Animals/index.png" };
                    sp.Children.Add(hide);

                    //adds a random image to the stacklayout
                    sp.Children.Add(animalList[randomNumber].Image);

                    //removes that animal from the list
                    animalList.RemoveAt(randomNumber);
                    //tapped event handler
                    TapGestureRecognizer tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped;
                    tap.NumberOfTapsRequired = 1;

                    sp.GestureRecognizers.Add(tap);

                    gameGrid.Children.Add(sp);

                    //add rows and cols
                    Grid.SetRow(sp, i);
                    Grid.SetColumn(sp, j);
                    //thread set to sleep to load images properly 
                    Thread.Sleep(50);

                }
            }
        }

        public bool game = true;
        public bool firstTurn= true;

        //timer function
        public void startTimer()
        {   
            //increments timer every second
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                labelVar.Text = "Timer: " + timeEllapsed; 
                timeEllapsed++;

                return game; // return true to repeat counting, false to stop timer
            });


            labelVar.TextColor = Color.FromHex("#77d065");
            labelVar.FontSize = 50;
            labelVar.BackgroundColor = Color.DarkBlue;
            labelVar.HorizontalTextAlignment = TextAlignment.Center;
            labelVar.VerticalTextAlignment = TextAlignment.Center;
        }

        //tapped event handler
        private void Tap_Tapped(object sender, EventArgs e)
        {
            //stop from calling timer more than once
            if (firstTurn) {
                startTimer();
                firstTurn = false;
            }
            StackLayout sl = (StackLayout)sender;
            Image hideImg = (Image)sl.Children[0];
            Image animalImg = (Image)sl.Children[1];
            //gets image clicked and splits the string to get the name
            //Image img = (Image)sl.Children[0];
            string name = animalImg.Source.ToString().Split('/')[1];

            //if not cliked create new animal obj
            if (animal1 == null)
            {
                hideImg.IsVisible = false;
                animalImg.IsVisible = true;
                animal1 = new AnimalObject(animalImg, name);
                return;
            }

            //animal cant be clicked twice
            if (animal1.Image == animalImg)
                return;

            hideImg.IsVisible = false;
            animalImg.IsVisible = true;
            
            //create second animal obj to compare
            animal2 = new AnimalObject(animalImg, name);

            //check if animals compare
            if (animal1.Name == animal2.Name)
            {
                animal1 = null;
                animal2 = null;
                
                labelVar.Text = "MATCHED";
                return;
            }

        }
    }
}
