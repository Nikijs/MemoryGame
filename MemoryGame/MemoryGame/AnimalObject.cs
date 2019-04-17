using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MemoryGame
{
    public class AnimalObject
    {
       

        public AnimalObject(Image image, string name)
        {
            Image = image;
            Name = name;
        }

        public string Name { get; set; }
        public Image Image { get; set; }

    }
}

