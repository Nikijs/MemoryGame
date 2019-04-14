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
        public MainPage()
        {
            for (int i = 0; i < 4; i++)
            {
                gdCards.RowDefinitions.Add(new RowDefinition());
                gdCards.ColumnDefinitions.Add(new ColumnDefinition());

                for (int j = 0; j < 4; j++)
                {
                    StackLayout sp = new StackLayout();
                    sp.Width = 100;
                    sp.Height = 100;

                    var rnd = new Random();
                    sp.BackgroundColor = new SolidColorBrush(Color.FromRgba(0xFF,
                    Convert.ToByte(rnd.Next(0, 256)),
                    Convert.ToByte(rnd.Next(0, 256)),
                    Convert.ToByte(rnd.Next(0, 256))));

                    gdCards.Children.Add(sp);
                    Grid.SetRow(sp, i);
                    Grid.SetColumn(sp, j);
                    Thread.Sleep(50);
                }
            }
        }
    }
}
