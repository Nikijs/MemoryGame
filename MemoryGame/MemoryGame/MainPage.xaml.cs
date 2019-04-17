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

        public void loadImages(List<AnimalObject> animalList)
        {
            animalList.Add(new AnimalObject(new Image { Source = "Animals/panda.png" }, "panda"));
            animalList.Add(new AnimalObject(new Image { Source = "Animals/sea-lion.png" }, "sea-lion"));
            animalList.Add(new AnimalObject(new Image { Source = "Animals/lion.png" }, "lion"));
            animalList.Add(new AnimalObject(new Image { Source = "Animals/snow-leopard.png" }, "snow-leopard"));
            animalList.Add(new AnimalObject(new Image { Source = "Animals/penguin.png" }, "penguin"));
            animalList.Add(new AnimalObject(new Image { Source = "Animals/raccoon.png" }, "raccoon"));
            animalList.Add(new AnimalObject(new Image { Source = "Animals/tiger.png" }, "tiger"));
            animalList.Add(new AnimalObject(new Image { Source = "Animals/lemur.png" }, "lemur"));

            animalList.Add(new AnimalObject(new Image { Source = "Animals/panda.png" }, "panda"));
            animalList.Add(new AnimalObject(new Image { Source = "Animals/sea-lion.png" }, "sea-lion"));
            animalList.Add(new AnimalObject(new Image { Source = "Animals/lion.png" }, "lion"));
            animalList.Add(new AnimalObject(new Image { Source = "Animals/snow-leopard.png" }, "snow-leopard"));
            animalList.Add(new AnimalObject(new Image { Source = "Animals/penguin.png" }, "penguin"));
            animalList.Add(new AnimalObject(new Image { Source = "Animals/raccoon.png" }, "raccoon"));
            animalList.Add(new AnimalObject(new Image { Source = "Animals/tiger.png" }, "tiger"));
            animalList.Add(new AnimalObject(new Image { Source = "Animals/lemur.png" }, "lemur"));
        }


        public MainPage()
        {
            InitializeComponent();
            createGrid();
            
        }
        public void createGrid()
        {
            //List<Image> animalList = new List<Image>();
            List<AnimalObject> animalList = new List<AnimalObject>();
            loadImages(animalList);
            for (int i = 0; i < 4; i++)
            {
                gameGrid.RowDefinitions.Add(new RowDefinition());
                gameGrid.ColumnDefinitions.Add(new ColumnDefinition());
                gameGrid.BackgroundColor = Color.Blue;

                for (int j = 0; j < 4; j++)
                {

                    StackLayout sp = new StackLayout { Padding = new Thickness(10, 20) };

                    int randomNumber = random.Next(animalList.Count);

                    sp.WidthRequest = 500;
                    sp.HeightRequest = 500;
                    sp.HorizontalOptions = LayoutOptions.Fill;
                    sp.VerticalOptions = LayoutOptions.Fill;
                    

                    sp.Children.Add(animalList[randomNumber].Image);
                    animalList.RemoveAt(randomNumber);
                    TapGestureRecognizer tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped;
                    tap.NumberOfTapsRequired = 1;
                    sp.GestureRecognizers.Add(tap);

                    gameGrid.Children.Add(sp);


                    Grid.SetRow(sp, i);
                    Grid.SetColumn(sp, j);
                    Thread.Sleep(50);

                }
            }
        }
        public bool game = true;
        public bool firstTurn= true;
        public void startTimer()
        {
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
        private void Tap_Tapped(object sender, EventArgs e)
        {
            if (firstTurn) {
                startTimer();
                firstTurn = false;
            }
            StackLayout sl = (StackLayout)sender;

            Image img = (Image)sl.Children[0];
            string name = img.Source.ToString().Split('/')[1];

            if (animal1 == null)
            {
                animal1 = new AnimalObject(img, name);
                return;
            }

            if (animal1.Image == img)
                return;


            animal2 = new AnimalObject(img, name);

            if (animal1.Name == animal2.Name)
            {
                animal1 = null;
                animal2 = null;
                
                labelVar.Text = "MATCHED: ";
                return;
            }

        }
    }
}
