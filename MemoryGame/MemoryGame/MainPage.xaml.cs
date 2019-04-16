using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MemoryGame
{
    public partial class MainPage : ContentPage
    {
        
        
        Random random = new Random();
        

        public MainPage()
        {
            InitializeComponent();
            createGrid();
        }
        public void createGrid()
        {
            for (int i = 0; i < 4; i++)
            {
                gameGrid.RowDefinitions.Add(new RowDefinition());
                gameGrid.ColumnDefinitions.Add(new ColumnDefinition());
                gameGrid.BackgroundColor = Color.Blue;

                for (int j = 0; j < 4; j++)           
                {
                   
                    StackLayout sp = new StackLayout();
                    var rnd = new Random();

                    //sp.BackgroundColor = Color.Red;
                    sp.WidthRequest = 400;
                    sp.HeightRequest = 400;
                    var panda = new Image { Source = "Animals/animal1.png" };

                    AnimalObject animal;
                    animal = new AnimalObject()
                    {
                        name = "Panda",
                        source = "Animals/animal1.png"
                  
                    };

                    sp.VerticalOptions = LayoutOptions.Center;
                    sp.HorizontalOptions = LayoutOptions.Center;
                    sp.Children.Add(panda);
                    gameGrid.Children.Add(sp);
                    

                    Grid.SetRow(sp, i);
                    Grid.SetColumn(sp, j);
                    
                }
            }
        }
    }
}
